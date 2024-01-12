
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cmcmarketsbetask.Models;

namespace cmcmarketsbetask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<RolesController> _logger;

        public RolesController(ApplicationDbContext context, ILogger<RolesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/getRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetRole()
        {
            _logger.LogTrace("Get Roles is Started.");
            try
            {
                _logger.LogInformation("Get the Request role data to database.");
                return await _context.Role.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception using log4net
                _logger.LogError($"An error occurred: {ex.Message}", ex);
                // Return a 500 Internal Server Error response with a generic error message
                return StatusCode(500, "An error occurred while getting all roles");
            }
            finally
            {
                _logger.LogTrace("Get Roles is Ended.");
            }
        }

        // POST: api/Roles
        [HttpPost]
        public async Task<ActionResult<Role>> PostRole(Role role)
        {
            _logger.LogTrace("Post Roles is started.");
            try
            {
                _logger.LogInformation("Persisting Requested role data to database.");
                _context.Role.Add(role);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Requested role data has been persisted to database successfully.");
                // return  200 status code with success message
                return Ok(new { Message = "Role has been created successfully" });
            }
            catch (Exception ex)
            {
                // Log the exception using log4net
                _logger.LogError($"An error occurred while persisting requested role data: {ex.Message}", ex);
                // Return a 500 Internal Server Error response with a generic error message
                return StatusCode(500, "An error occurred while persisting requested role data.");
            }
            finally
            {
                _logger.LogTrace("Post Roles is ended.");
            }

        }
    }
}
