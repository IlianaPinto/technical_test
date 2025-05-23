
using Microsoft.AspNetCore.Mvc;
using service_api.DTOs;
using service_api.Services;

namespace service_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;

        public AuthController(IAuthService auth)
        {
            _auth = auth;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDTO request)
        {
            var result = await _auth.LoginAsync(request);
            if (result == null) return Unauthorized("Incorrect username or password");

            return Ok(result);
        }
    }
}
