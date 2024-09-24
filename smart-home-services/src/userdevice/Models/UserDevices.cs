
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace SmartHomeSystem.Model
{
    /// <summary>
    /// array of user devices
    /// </summary>
    [DataContract]
    public partial class UserDevices : List<UserDevice>, IEquatable<UserDevices>
    { 
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UserDevices {\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public  new string ToJson()
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
            return obj.GetType() == GetType() && Equals((UserDevices)obj);
        }

        /// <summary>
        /// Returns true if UserDevices instances are equal
        /// </summary>
        /// <param name="other">Instance of UserDevices to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UserDevices other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return false && base.Equals(other);
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
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(UserDevices left, UserDevices right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UserDevices left, UserDevices right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
