namespace cmcmarketsbetask.Models
{
    /// <summary>
    /// Data Transfer Object (DTO) for user login information.
    /// </summary>
    public class LoginDto
    {
        /// <summary>
        /// Gets or sets the username for login.
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the password for login.
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
}
