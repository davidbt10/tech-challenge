using Microsoft.AspNetCore.Mvc;
using PI.Application.Interfaces;
using PI.Application.Models.Requests;

namespace PI.WebAPI.Controllers
{
    [ApiController]
    [Route("login")]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public LoginController(IUserService userService,
            ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<IActionResult> AuthenticateAsync(ValidateUserRequest request)
        {
            var user = await _userService.ValidateUser(request);
            
            if (user == null)
                return NotFound("User not found");

            var token = _tokenService.CreateToken(user);
            user.Password = null;

            return Ok( new
            {
                User = user,
                Token = token,
            });
        }
    }
}
