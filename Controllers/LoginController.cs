using cmcmarketsbetask.Models;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<LoginController> _logger;

    public LoginController(ApplicationDbContext context, ILogger<LoginController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        // Validate loginDto, authenticate user, etc.
        _logger.LogTrace("Login Task Started.");
        try
        {
            _logger.LogInformation("Getting user from the Database based on the request body.");

            // Retrieve user from the database based on the provided credentials
            var user = await _context.UserProfile
                .FirstOrDefaultAsync(u => u.UserName == loginDto.UserName && u.Password == loginDto.Password && u.RoleKey == "Admin");

            if (user != null)
            {
                _logger.LogInformation("User logged in successfully.");
                // Authentication successful
                return Ok(new { Message = "Login successful" });
            }
            else
            {
                _logger.LogInformation("User is unauthorized.");
                // Authentication failed
                return Unauthorized(new { Message = "Unauthorized" });
            }
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
            _logger.LogTrace("Login Task Ended.");
        }
    }
}
