using AtsAssessment.Application.Interfaces;
using AtsAssessment.Domain.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtsAssessment.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("token")]
        public IActionResult GenerateToken([FromBody] JwtRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Username))
                return BadRequest("Invalid request.");

            try
            {
                var token = _service.GenerateToken(request);
                return Ok(token);
            }
            catch
            {
                return Unauthorized(new { error = "Invalid username or password." });
            }
        }
    }
}
