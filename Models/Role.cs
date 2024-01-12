using System.Text.Json.Serialization;

namespace cmcmarketsbetask.Models
{
    /// <summary>
    /// Represents a role in the application.
    /// </summary>
    public class Role
    {
        /// <summary>
        /// Gets or sets the unique identifier for the role.
        /// </summary>
        [JsonIgnore]
        public int RoleId { get; set; }

        /// <summary>
        /// Gets or sets the key associated with the role.
        /// </summary>
        public string RoleKey { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of the role.
        /// </summary>
        public string RoleName { get; set; } = string.Empty;
    }
}
