/* 
 * EVE Swagger Interface
 *
 * An OpenAPI for EVE Online
 *
 * OpenAPI spec version: 0.3.9
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace ESI.Model
{
    /// <summary>
    /// 200 ok object
    /// </summary>
    [DataContract]
    public partial class GetCharactersCharacterIdContacts200Ok :  IEquatable<GetCharactersCharacterIdContacts200Ok>, IValidatableObject
    {
        /// <summary>
        /// contact_type string
        /// </summary>
        /// <value>contact_type string</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ContactTypeEnum
        {
            
            /// <summary>
            /// Enum Character for "character"
            /// </summary>
            [EnumMember(Value = "character")]
            Character,
            
            /// <summary>
            /// Enum Corporation for "corporation"
            /// </summary>
            [EnumMember(Value = "corporation")]
            Corporation,
            
            /// <summary>
            /// Enum Alliance for "alliance"
            /// </summary>
            [EnumMember(Value = "alliance")]
            Alliance,
            
            /// <summary>
            /// Enum Faction for "faction"
            /// </summary>
            [EnumMember(Value = "faction")]
            Faction
        }

        /// <summary>
        /// contact_type string
        /// </summary>
        /// <value>contact_type string</value>
        [DataMember(Name="contact_type", EmitDefaultValue=false)]
        public ContactTypeEnum? ContactType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCharactersCharacterIdContacts200Ok" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected GetCharactersCharacterIdContacts200Ok() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCharactersCharacterIdContacts200Ok" /> class.
        /// </summary>
        /// <param name="ContactId">contact_id integer (required).</param>
        /// <param name="ContactType">contact_type string (required).</param>
        /// <param name="IsBlocked">Whether this contact is in the blocked list. Note a missing value denotes unknown, not true or false.</param>
        /// <param name="IsWatched">Whether this contact is being watched.</param>
        /// <param name="LabelId">Custom label of the contact.</param>
        /// <param name="Standing">Standing of the contact (required).</param>
        public GetCharactersCharacterIdContacts200Ok(int? ContactId = default(int?), ContactTypeEnum? ContactType = default(ContactTypeEnum?), bool? IsBlocked = default(bool?), bool? IsWatched = default(bool?), long? LabelId = default(long?), float? Standing = default(float?))
        {
            // to ensure "ContactId" is required (not null)
            if (ContactId == null)
            {
                throw new InvalidDataException("ContactId is a required property for GetCharactersCharacterIdContacts200Ok and cannot be null");
            }
            else
            {
                this.ContactId = ContactId;
            }
            // to ensure "ContactType" is required (not null)
            if (ContactType == null)
            {
                throw new InvalidDataException("ContactType is a required property for GetCharactersCharacterIdContacts200Ok and cannot be null");
            }
            else
            {
                this.ContactType = ContactType;
            }
            // to ensure "Standing" is required (not null)
            if (Standing == null)
            {
                throw new InvalidDataException("Standing is a required property for GetCharactersCharacterIdContacts200Ok and cannot be null");
            }
            else
            {
                this.Standing = Standing;
            }
            this.IsBlocked = IsBlocked;
            this.IsWatched = IsWatched;
            this.LabelId = LabelId;
        }
        
        /// <summary>
        /// contact_id integer
        /// </summary>
        /// <value>contact_id integer</value>
        [DataMember(Name="contact_id", EmitDefaultValue=false)]
        public int? ContactId { get; set; }
        /// <summary>
        /// Whether this contact is in the blocked list. Note a missing value denotes unknown, not true or false
        /// </summary>
        /// <value>Whether this contact is in the blocked list. Note a missing value denotes unknown, not true or false</value>
        [DataMember(Name="is_blocked", EmitDefaultValue=false)]
        public bool? IsBlocked { get; set; }
        /// <summary>
        /// Whether this contact is being watched
        /// </summary>
        /// <value>Whether this contact is being watched</value>
        [DataMember(Name="is_watched", EmitDefaultValue=false)]
        public bool? IsWatched { get; set; }
        /// <summary>
        /// Custom label of the contact
        /// </summary>
        /// <value>Custom label of the contact</value>
        [DataMember(Name="label_id", EmitDefaultValue=false)]
        public long? LabelId { get; set; }
        /// <summary>
        /// Standing of the contact
        /// </summary>
        /// <value>Standing of the contact</value>
        [DataMember(Name="standing", EmitDefaultValue=false)]
        public float? Standing { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetCharactersCharacterIdContacts200Ok {\n");
            sb.Append("  ContactId: ").Append(ContactId).Append("\n");
            sb.Append("  ContactType: ").Append(ContactType).Append("\n");
            sb.Append("  IsBlocked: ").Append(IsBlocked).Append("\n");
            sb.Append("  IsWatched: ").Append(IsWatched).Append("\n");
            sb.Append("  LabelId: ").Append(LabelId).Append("\n");
            sb.Append("  Standing: ").Append(Standing).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            return this.Equals(obj as GetCharactersCharacterIdContacts200Ok);
        }

        /// <summary>
        /// Returns true if GetCharactersCharacterIdContacts200Ok instances are equal
        /// </summary>
        /// <param name="other">Instance of GetCharactersCharacterIdContacts200Ok to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GetCharactersCharacterIdContacts200Ok other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.ContactId == other.ContactId ||
                    this.ContactId != null &&
                    this.ContactId.Equals(other.ContactId)
                ) && 
                (
                    this.ContactType == other.ContactType ||
                    this.ContactType != null &&
                    this.ContactType.Equals(other.ContactType)
                ) && 
                (
                    this.IsBlocked == other.IsBlocked ||
                    this.IsBlocked != null &&
                    this.IsBlocked.Equals(other.IsBlocked)
                ) && 
                (
                    this.IsWatched == other.IsWatched ||
                    this.IsWatched != null &&
                    this.IsWatched.Equals(other.IsWatched)
                ) && 
                (
                    this.LabelId == other.LabelId ||
                    this.LabelId != null &&
                    this.LabelId.Equals(other.LabelId)
                ) && 
                (
                    this.Standing == other.Standing ||
                    this.Standing != null &&
                    this.Standing.Equals(other.Standing)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            // credit: http://stackoverflow.com/a/263416/677735
            unchecked // Overflow is fine, just wrap
            {
                int hash = 41;
                // Suitable nullity checks etc, of course :)
                if (this.ContactId != null)
                    hash = hash * 59 + this.ContactId.GetHashCode();
                if (this.ContactType != null)
                    hash = hash * 59 + this.ContactType.GetHashCode();
                if (this.IsBlocked != null)
                    hash = hash * 59 + this.IsBlocked.GetHashCode();
                if (this.IsWatched != null)
                    hash = hash * 59 + this.IsWatched.GetHashCode();
                if (this.LabelId != null)
                    hash = hash * 59 + this.LabelId.GetHashCode();
                if (this.Standing != null)
                    hash = hash * 59 + this.Standing.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}