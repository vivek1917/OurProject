using Microsoft.AspNetCore.Mvc;
using OurProject.Services;

namespace OurProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthenticationService _authService;

        public AuthenticationController(AuthenticationService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var user = await _authService.AuthenticateUser(loginRequest.Email, loginRequest.Password);
            if (user == null)
            {
                return Unauthorized(new { message = "Invalid email or password" });
            }
            return Ok(user);
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
