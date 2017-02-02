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
    /// item object
    /// </summary>
    [DataContract]
    public partial class GetKillmailsKillmailIdKillmailHashItem1 :  IEquatable<GetKillmailsKillmailIdKillmailHashItem1>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetKillmailsKillmailIdKillmailHashItem1" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected GetKillmailsKillmailIdKillmailHashItem1() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetKillmailsKillmailIdKillmailHashItem1" /> class.
        /// </summary>
        /// <param name="Flag">Flag for the location of the item  (required).</param>
        /// <param name="ItemTypeId">item_type_id integer (required).</param>
        /// <param name="Items">items array.</param>
        /// <param name="QuantityDestroyed">How many of the item were destroyed if any .</param>
        /// <param name="QuantityDropped">How many of the item were dropped if any .</param>
        /// <param name="Singleton">singleton integer (required).</param>
        public GetKillmailsKillmailIdKillmailHashItem1(int? Flag = default(int?), int? ItemTypeId = default(int?), List<GetKillmailsKillmailIdKillmailHashItem> Items = default(List<GetKillmailsKillmailIdKillmailHashItem>), long? QuantityDestroyed = default(long?), long? QuantityDropped = default(long?), int? Singleton = default(int?))
        {
            // to ensure "Flag" is required (not null)
            if (Flag == null)
            {
                throw new InvalidDataException("Flag is a required property for GetKillmailsKillmailIdKillmailHashItem1 and cannot be null");
            }
            else
            {
                this.Flag = Flag;
            }
            // to ensure "ItemTypeId" is required (not null)
            if (ItemTypeId == null)
            {
                throw new InvalidDataException("ItemTypeId is a required property for GetKillmailsKillmailIdKillmailHashItem1 and cannot be null");
            }
            else
            {
                this.ItemTypeId = ItemTypeId;
            }
            // to ensure "Singleton" is required (not null)
            if (Singleton == null)
            {
                throw new InvalidDataException("Singleton is a required property for GetKillmailsKillmailIdKillmailHashItem1 and cannot be null");
            }
            else
            {
                this.Singleton = Singleton;
            }
            this.Items = Items;
            this.QuantityDestroyed = QuantityDestroyed;
            this.QuantityDropped = QuantityDropped;
        }
        
        /// <summary>
        /// Flag for the location of the item 
        /// </summary>
        /// <value>Flag for the location of the item </value>
        [DataMember(Name="flag", EmitDefaultValue=false)]
        public int? Flag { get; set; }
        /// <summary>
        /// item_type_id integer
        /// </summary>
        /// <value>item_type_id integer</value>
        [DataMember(Name="item_type_id", EmitDefaultValue=false)]
        public int? ItemTypeId { get; set; }
        /// <summary>
        /// items array
        /// </summary>
        /// <value>items array</value>
        [DataMember(Name="items", EmitDefaultValue=false)]
        public List<GetKillmailsKillmailIdKillmailHashItem> Items { get; set; }
        /// <summary>
        /// How many of the item were destroyed if any 
        /// </summary>
        /// <value>How many of the item were destroyed if any </value>
        [DataMember(Name="quantity_destroyed", EmitDefaultValue=false)]
        public long? QuantityDestroyed { get; set; }
        /// <summary>
        /// How many of the item were dropped if any 
        /// </summary>
        /// <value>How many of the item were dropped if any </value>
        [DataMember(Name="quantity_dropped", EmitDefaultValue=false)]
        public long? QuantityDropped { get; set; }
        /// <summary>
        /// singleton integer
        /// </summary>
        /// <value>singleton integer</value>
        [DataMember(Name="singleton", EmitDefaultValue=false)]
        public int? Singleton { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetKillmailsKillmailIdKillmailHashItem1 {\n");
            sb.Append("  Flag: ").Append(Flag).Append("\n");
            sb.Append("  ItemTypeId: ").Append(ItemTypeId).Append("\n");
            sb.Append("  Items: ").Append(Items).Append("\n");
            sb.Append("  QuantityDestroyed: ").Append(QuantityDestroyed).Append("\n");
            sb.Append("  QuantityDropped: ").Append(QuantityDropped).Append("\n");
            sb.Append("  Singleton: ").Append(Singleton).Append("\n");
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
            return this.Equals(obj as GetKillmailsKillmailIdKillmailHashItem1);
        }

        /// <summary>
        /// Returns true if GetKillmailsKillmailIdKillmailHashItem1 instances are equal
        /// </summary>
        /// <param name="other">Instance of GetKillmailsKillmailIdKillmailHashItem1 to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GetKillmailsKillmailIdKillmailHashItem1 other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Flag == other.Flag ||
                    this.Flag != null &&
                    this.Flag.Equals(other.Flag)
                ) && 
                (
                    this.ItemTypeId == other.ItemTypeId ||
                    this.ItemTypeId != null &&
                    this.ItemTypeId.Equals(other.ItemTypeId)
                ) && 
                (
                    this.Items == other.Items ||
                    this.Items != null &&
                    this.Items.SequenceEqual(other.Items)
                ) && 
                (
                    this.QuantityDestroyed == other.QuantityDestroyed ||
                    this.QuantityDestroyed != null &&
                    this.QuantityDestroyed.Equals(other.QuantityDestroyed)
                ) && 
                (
                    this.QuantityDropped == other.QuantityDropped ||
                    this.QuantityDropped != null &&
                    this.QuantityDropped.Equals(other.QuantityDropped)
                ) && 
                (
                    this.Singleton == other.Singleton ||
                    this.Singleton != null &&
                    this.Singleton.Equals(other.Singleton)
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
                if (this.Flag != null)
                    hash = hash * 59 + this.Flag.GetHashCode();
                if (this.ItemTypeId != null)
                    hash = hash * 59 + this.ItemTypeId.GetHashCode();
                if (this.Items != null)
                    hash = hash * 59 + this.Items.GetHashCode();
                if (this.QuantityDestroyed != null)
                    hash = hash * 59 + this.QuantityDestroyed.GetHashCode();
                if (this.QuantityDropped != null)
                    hash = hash * 59 + this.QuantityDropped.GetHashCode();
                if (this.Singleton != null)
                    hash = hash * 59 + this.Singleton.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}