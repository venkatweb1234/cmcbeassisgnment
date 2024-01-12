using Microsoft.EntityFrameworkCore;

namespace cmcmarketsbetask.Models
{
    /// <summary>
    /// Represents the database context for the application.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Gets or sets the DbSet for storing tasks in the database.
        /// </summary>
        public DbSet<Task> Tasks { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for storing user profiles in the database.
        /// </summary>
        public DbSet<UserProfile> UserProfile { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for storing roles in the database.
        /// </summary>
        public DbSet<Role> Role { get; set; }

        // Add other DbSet properties as needed for your application.

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="options">The options for configuring the DbContext.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
