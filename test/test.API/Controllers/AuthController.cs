using Microsoft.AspNetCore.Mvc;
using test.API.Models.DTO;
using test.API.Repositories;

namespace test.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly ITokenHandler tokenHandler;

        public AuthController(IUserRepository userRepository, ITokenHandler tokenHandler)
        {
            this.userRepository = userRepository;
            this.tokenHandler = tokenHandler;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(LoginRequest loginRequest)
        {
            var user = await userRepository.AuthenticateAsync(loginRequest.Username, loginRequest.Password);
            if (user != null)
            {
                // Generate a JWT
                var token = await tokenHandler.CreateTokenAsync(user);
                return Ok(token);
            }

            return BadRequest("Username or password is incorrect.");
        }
    }
}
