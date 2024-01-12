namespace cmcmarketsbetask.Models
{
    /// <summary>
    /// Represents a task in the application.
    /// </summary>
    public class Task
    {
        /// <summary>
        /// Gets or sets the unique identifier for the task.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the task.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether the task is completed.
        /// </summary>
        public bool IsCompleted { get; set; }

        /// <summary>
        /// Gets or sets the due date for the task.
        /// </summary>
        public DateTime DueDate { get; set; }
    }
}
