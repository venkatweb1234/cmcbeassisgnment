using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cmcmarketsbetask.Models;

namespace cmcmarketsbetask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfilesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<UserProfilesController> _logger;

        public UserProfilesController(ApplicationDbContext context, ILogger<UserProfilesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/UserProfiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserProfile>>> GetUserProfile()
        {
            _logger.LogTrace("Get Userprofiles  is Started.");
            try
            {
                _logger.LogInformation("Geting all users info from data base");
                // returning all users info from database
                return await _context.UserProfile.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception using log4net
                _logger.LogError($"An error occurred while getting all users info from Database: {ex.Message}", ex);
                // Return a 500 Internal Server Error response with a generic error message
                return StatusCode(500, "An error occurred while getting users");
            }
            finally
            {
                _logger.LogTrace("\"Get Userprofiles is Ended.");
            }
        }

        // POST: api/UserProfiles
        [HttpPost]
        public async Task<ActionResult<UserProfile>> PostUserProfile(UserProfile userProfile)
        {
            _logger.LogTrace("Post User Profile Data is Started.");
            try
            {
                _logger.LogInformation("Persisting Requested UserProfile data to database.");

                _context.UserProfile.Add(userProfile);

                await _context.SaveChangesAsync();
                _logger.LogInformation("Requested UserProfile data has been persisted to database successfully.");
                // return  200 status code with success message
                return Ok(new { Message = "User has been created successfully" });
            }
            catch (Exception ex)
            {
                // Log the exception using log4net
                _logger.LogError($"An error occurred while persistig: {ex.Message}", ex);
                // Return a 500 Internal Server Error response with a generic error message
                return StatusCode(500, "An error occurred while persisting requested user data.");
            }
            finally
            {
                _logger.LogTrace("Post User Profile Data is Ended.");
            }
        }
    }
}
