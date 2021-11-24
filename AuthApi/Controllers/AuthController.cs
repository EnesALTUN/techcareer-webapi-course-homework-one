using AuthApi.Infrastructure;
using AuthApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;
        public AuthController(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [HttpGet]
        public IActionResult Login(UserCredential user)
        {
            if (user.Email.Equals("ensalt_1998@hotmail.com") && user.Password.Equals("123"))
            {
                return Ok(_jwtAuthenticationManager.TokenHandler(user.Email));
            }
            else
                return Unauthorized();
        }
    }
}