using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartHomeSystem.Model
{
    /// <summary>
    /// the user device telemetry
    /// </summary>
    [DataContract]
    [Table("UserDeviceTelemetry")]
    public partial class UserDeviceTelemetry : IEquatable<UserDeviceTelemetry>
    { 
        /// <summary>
        /// Gets or Sets Id
        /// </summary>

        [DataMember(Name="id")]
        public Int64? Id { get; set; }

        /// <summary>
        /// Gets or Sets UserDeviceId
        /// </summary>

        [DataMember(Name="userdeviceid")]
        public Int64? UserDeviceId { get; set; }

        /// <summary>
        /// the device telemetry type
        /// </summary>
        /// <value>the device telemetry type</value>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum ValueTypeEnum
        {
            /// <summary>
            /// Enum StatusEnum for status
            /// </summary>
            [EnumMember(Value = "status")]
            StatusEnum = 0,
            /// <summary>
            /// Enum HeatEnum for heat
            /// </summary>
            [EnumMember(Value = "heat")]
            HeatEnum = 1,
            /// <summary>
            /// Enum TemperatureEnum for temperature
            /// </summary>
            [EnumMember(Value = "temperature")]
            TemperatureEnum = 2        }

        /// <summary>
        /// the device telemetry type
        /// </summary>
        /// <value>the device telemetry type</value>

        [DataMember(Name="valueType")]
        public ValueTypeEnum? ValueType { get; set; }

        /// <summary>
        /// the device telemetry value
        /// </summary>
        /// <value>the device telemetry value</value>

        [DataMember(Name="value")]
        public decimal? Value { get; set; }

        /// <summary>
        /// a device telemetry modify date and time
        /// </summary>
        /// <value>a device telemetry modify date and time</value>

        [DataMember(Name="createdDateTime")]
        public string CreatedDateTime { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DeviceTelemetry {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  UserDeviceId: ").Append(UserDeviceId).Append("\n");
            sb.Append("  ValueType: ").Append(ValueType).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("  CreatedDateTime: ").Append(CreatedDateTime).Append("\n");
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
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((UserDeviceTelemetry)obj);
        }

        /// <summary>
        /// Returns true if DeviceTelemetry instances are equal
        /// </summary>
        /// <param name="other">Instance of DeviceTelemetry to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UserDeviceTelemetry other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Id == other.Id ||
                    Id != null &&
                    Id.Equals(other.Id)
                ) && 
                (
                    UserDeviceId == other.UserDeviceId ||
                    UserDeviceId != null &&
                    UserDeviceId.Equals(other.UserDeviceId)
                ) && 
                (
                    ValueType == other.ValueType ||
                    ValueType != null &&
                    ValueType.Equals(other.ValueType)
                ) && 
                (
                    Value == other.Value ||
                    Value != null &&
                    Value.Equals(other.Value)
                ) && 
                (
                    CreatedDateTime == other.CreatedDateTime ||
                    CreatedDateTime != null &&
                    CreatedDateTime.Equals(other.CreatedDateTime)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                if (Id != null)
                    hashCode = hashCode * 59 + Id.GetHashCode();
                if (UserDeviceId != null)
                    hashCode = hashCode * 59 + UserDeviceId.GetHashCode();
                if (ValueType != null)
                    hashCode = hashCode * 59 + ValueType.GetHashCode();
                if (Value != null)
                    hashCode = hashCode * 59 + Value.GetHashCode();
                if (CreatedDateTime != null)
                    hashCode = hashCode * 59 + CreatedDateTime.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(UserDeviceTelemetry left, UserDeviceTelemetry right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UserDeviceTelemetry left, UserDeviceTelemetry right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
