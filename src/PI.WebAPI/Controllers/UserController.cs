using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PI.Application.Interfaces;
using PI.Application.Models.Requests;
using PI.Application.Models.Responses;
using PI.Domain.Enum;

namespace PI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CreateUserRes>> CreateUser(CreateUserRequest user)
        {
            var result = await _userService.CreateUser(user);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = Permissions.Administrator)]
        public async Task<ActionResult<ValidateUserResponse>> ValidateUser(ValidateUserRequest req)
        {
            var result = await _userService.ValidateUser(req);
            return Ok(result);
        }

        [HttpGet]
        [Authorize(Roles = $"{Permissions.Administrator}, {Permissions.Analist}")]
        public async Task<ActionResult<GetAllActiveUsersResponse>> GetAllActiveUsers()
        {
            var result = await _userService.GetAllActiveUsers();
            return Ok(result);
        }
    }
}
