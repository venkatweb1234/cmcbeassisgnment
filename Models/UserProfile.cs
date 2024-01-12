using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace cmcmarketsbetask.Models
{
    /// <summary>
    /// Represents a user profile in the application.
    /// </summary>
    public class UserProfile
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user profile.
        /// </summary>
        [JsonIgnore]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the username associated with the user profile.
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the email address associated with the user profile.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the password associated with the user profile.
        /// </summary>
        public string Password { get; set; }= string.Empty;

        /// <summary>
        /// Gets or sets the role key associated with the user profile.
        /// </summary>
        [Column("RoleKey")]
        public string RoleKey { get; set; }
    }
}
