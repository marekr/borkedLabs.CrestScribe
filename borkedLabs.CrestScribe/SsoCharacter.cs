﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eZet.EveLib.DynamicCrest;
using MySql.Data.MySqlClient;
using Dapper;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace borkedLabs.CrestScribe
{
    public class SsoCharacter
    {
        #region SQLFields

        private string _accessToken;
        public string AccessToken
        {
            get
            {
                return _accessToken;
            }
            set
            {
                _accessToken = value;
                _crest.AccessToken = _accessToken;
            }
        }

        private string _refreshToken { get; set; }
        public string RefreshToken
        {
            get
            {
                return _refreshToken;
            }
            set
            {
                _refreshToken = value;
                _crest.RefreshToken = _refreshToken;
            }
        }

        public uint UserId { get; set; }

        public string CharacterOwnerHash { get; set; }

        public UInt64 CharacterId { get; set; }

        public bool AlwaysTrackLocation { get; set; }

        private DateTime _tokenExpiration;
        public DateTime TokenExpiration
        {
            get
            {
                return _tokenExpiration;
            }
            set
            {
                _tokenExpiration = DateTime.SpecifyKind(value, DateTimeKind.Utc);
            }
        }

        private DateTime _createdAt;
        public DateTime CreatedAt
        {
            get
            {
                return _createdAt;
            }
            set
            {
                _createdAt = DateTime.SpecifyKind(value, DateTimeKind.Utc);
            }
        }

        private DateTime _updatedAt;
        public DateTime UpdatedAt
        {
            get
            {
                return _updatedAt;
            }
            set
            {
                _updatedAt = DateTime.SpecifyKind(value, DateTimeKind.Utc);
            }
        }

        public bool Valid { get; set; }
        #endregion

        private DynamicCrest _crest;
        private Expando _characterCrest;

        public DateTime LastLocationQueryAt { get; set; }
        public TimeSpan PollInterval { get; set; }
        private Timer _pollTimer;
        public BlockingCollection<SsoCharacter> QueryQueue
        {
            get;set;
        }

        public SsoCharacter()
        {
            _crest = new DynamicCrest(AccessToken);
            _crest.EncodedKey = ScribeSettings.Settings.Sso.EncodedKey;
            _crest.RefreshToken = RefreshToken;
            _crest.EnableAutomaticTokenRefresh = false;
            LastLocationQueryAt = DateTime.MinValue;

            _pollTimer = null;
        }
        
        private void _pollTimerCallback(object state)
        {
            _pollTimer.Dispose();

            QueryQueue.Add(this);
        }
        /// <summary>
        /// Attempts to refresh the tokens. Failure of token refresh (bad tokens) may set the valid flag to false.
        /// </summary>
        /// <returns>Whether or not a database update is possible. Valid flag may change instead of Tokens on failure.</returns>
        public async Task<bool> RefreshAccess()
        {
            try
            {
                var response = await _crest.RefreshAccessTokenAsync();

                if (response.TokenType == "Bearer")
                {
                    AccessToken = response.AccessToken;
                    RefreshToken = response.RefreshToken;
                    TokenExpiration = DateTime.UtcNow.AddSeconds(response.ExpiresIn);

                    return true;
                }
            }
            catch (eZet.EveLib.EveAuthModule.EveAuthException e)
            {
                //unforunately we want to be a little effiecient determining key status
                //so see if we got a 400 error
                //we are ignoring other errors because god knows what fuckups can happen by CCP and
                //we dont want to invalidate all our keys
                var webResponse = e.WebException.Response as HttpWebResponse;

                if(webResponse != null)
                {
                    if(webResponse.StatusCode == HttpStatusCode.BadRequest ||
                        webResponse.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        Valid = false;
                        return true;
                    }
                }

                return false;
            }
            catch
            {
                return false;
            }

            return false;
        }

        public async Task<bool> GetLocation()
        {
            if(_characterCrest == null)
            {
                throw new InvalidOperationException("Character CREST data not fetched");
            }

            try
            {
                var location = await _characterCrest.GetAsync(r => r.location);

                LastLocationQueryAt = DateTime.UtcNow;

                if (location.Properties.ContainsKey("solarSystem"))
                {
                    ulong locationId = (ulong)location["solarSystem"].id;
                    var loc = new CharacterLocation()
                    {
                        CharacterId = CharacterId,
                        SystemId = locationId
                    };

                    loc.Save();
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Save()
        {
            using (MySqlConnection sql = Database.GetConnection())
            {
                UpdatedAt = DateTime.UtcNow;
                string q = @"UPDATE user_ssocharacter SET refresh_token = @RefreshToken, 
                                    access_token = @AccessToken, 
                                    access_token_expiration = @TokenExpiration,
                                    updated_at = @UpdatedAt,
                                    valid = @Valid
                                WHERE character_owner_hash = @CharacterOwnerHash AND user_id = @UserId";

                var count = sql.Execute(q, this);
                return count > 0;
            }
        }

        public bool ShouldGetLocation()
        {
            return Valid && (LastLocationQueryAt < DateTime.UtcNow.AddSeconds(ScribeSettings.Settings.CrestLocation.Interval));
        }
      
        public async Task Poll()
        {
            if (!Valid)
            {
                return;
            }

            var session = Session.Find(CharacterId, UserId);

            if(session == null || (!AlwaysTrackLocation && session.UpdatedAt.AddMinutes(1) < DateTime.UtcNow ) )
            {
                //not an active session, dont poll as often but also dont continue
                _pollTimer = new Timer(new TimerCallback(_pollTimerCallback), null, 20*1000, Timeout.Infinite);

                return;
            }

            if (TokenExpiration < DateTime.UtcNow)
            {
                bool changed = await RefreshAccess();
                if (changed)
                {
                    Save();
                }

                if(!Valid)
                {
                    return;
                }
            }

            // CREST may not return anything when the server is down :/
            if(_characterCrest == null)
            {
                try
                {
                    _characterCrest = await (await (await _crest.GetAsync(_crest.Host)).GetAsync(r => r.decode)).GetAsync(r => r.character);
                }
                catch
                {
                    _characterCrest = null;
                }
            }

            if ( _characterCrest != null &&
                ShouldGetLocation())
            {
                if(!await GetLocation())
                {
                    //not an active char or CREST is having issues, slow down
                    _pollTimer = new Timer(new TimerCallback(_pollTimerCallback), null, 20 * 1000, Timeout.Infinite);

                    return;
                }
            }

            _pollTimer = new Timer(new TimerCallback(_pollTimerCallback), null, ScribeSettings.Settings.CrestLocation.Interval * 1000, Timeout.Infinite);
        }
    }
}
