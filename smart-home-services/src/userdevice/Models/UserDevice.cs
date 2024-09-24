
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartHomeSystem.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    [Table("UserDevice")]
    public partial class UserDevice : IEquatable<UserDevice>
    { 
        /// <summary>
        /// the user id
        /// </summary>
        /// <value>the user id</value>
        [Required]
        [DataMember(Name="userId")]
        public Guid? UserId { get; set; }

        /// <summary>
        /// the device id
        /// </summary>
        /// <value>the device id</value>
        [Required]
        [DataMember(Name = "deviceId")]
        public Int64? DeviceId { get; set; }

        /// <summary>
        /// the user device id
        /// </summary>
        /// <value>the user device id</value>
        [Required]
        [DataMember(Name="userDeviceId")]
        public Int64? UserDeviceId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UserDevice {\n");
            sb.Append("  UserId: ").Append(UserId).Append("\n");
            sb.Append("  DeviceId: ").Append(DeviceId).Append("\n");
            sb.Append("  UserDeviceId: ").Append(UserDeviceId).Append("\n");
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
            return obj.GetType() == GetType() && Equals((UserDevice)obj);
        }

        /// <summary>
        /// Returns true if UserDevice instances are equal
        /// </summary>
        /// <param name="other">Instance of UserDevice to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UserDevice other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    UserId == other.UserId ||
                    UserId != null &&
                    UserId.Equals(other.UserId)
                ) &&
                (
                    DeviceId == other.DeviceId ||
                    DeviceId != null &&
                    DeviceId.Equals(other.DeviceId)
                ) &&
                (
                    UserDeviceId == other.UserDeviceId ||
                    UserDeviceId != null &&
                    UserDeviceId.Equals(other.UserDeviceId)
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
                if (UserId != null)
                    hashCode = hashCode * 59 + UserId.GetHashCode();
                if (DeviceId != null)
                    hashCode = hashCode * 59 + DeviceId.GetHashCode();
                if (UserDeviceId != null)
                    hashCode = hashCode * 59 + UserDeviceId.GetHashCode();

                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(UserDevice left, UserDevice right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UserDevice left, UserDevice right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
