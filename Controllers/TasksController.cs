using cmcmarketsbetask.Models;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cmcmarketsbetask.Controllers
{
    // TasksController.cs
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        private readonly ILogger<TasksController> _logger;
        public TasksController(ApplicationDbContext context, ILogger<TasksController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/tasks/completed-last-7-days
        [HttpGet("completed-last-7-days")]
        public async Task<IActionResult> GetCompletedTasksLast7Days()
        {
            _logger.LogTrace("Tasks started.");
            try
            {
                _logger.LogInformation("Getting  last 7 days info ");
                DateTime sevenDaysAgo = DateTime.UtcNow.AddDays(-7);

                // Use asynchronous database operation
                var completedTasksLast7Days = await _context.Tasks
                    .Where(task => task.IsCompleted && task.DueDate >= sevenDaysAgo)
                    .ToListAsync();
                //returning 7 days tasks
                return Ok(completedTasksLast7Days);
            }
            catch (Exception ex)
            {
                // Log the exception using log4net
                _logger.LogError($"An error occurred: {ex.Message}", ex);
                // Return a 500 Internal Server Error response with a generic error message
                return StatusCode(500, "An error occurred while processing the request.");
            }
            finally
            {
                _logger.LogTrace("Tasks ended.");
            }
        }
    }

}


