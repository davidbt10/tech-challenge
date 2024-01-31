using Microsoft.Extensions.Logging;
using PI.Application.Interfaces;
using PI.Application.Models.DTOs;
using PI.Application.Models.Requests;
using PI.Application.Models.Responses;
using PI.Domain.Core.Repositories;
using PI.Domain.Entity;
using PI.Domain.Enum;

namespace PI.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, 
            ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<CreateUserRes> CreateUser(CreateUserRequest req)
        {
            var user = await _userRepository.AddAsync(new User
            {
                Name = req.Name,
                Email = req.Email,
                Password = req.Password,
                Permission = (PermissionTypes)req.PermissionId,
                Status = UserStatus.Active,
                CreatedOn = DateTime.Now,
                LastModifiedOn = DateTime.Now
            });

            _logger.LogInformation("New user created");

            return new CreateUserRes() { Data = new UserDTO(user) };
        }

        public async Task<User> ValidateUser(ValidateUserRequest request)
        {
            var user = await _userRepository.GetUserByEmailAndPassword(request.Email, request.Password);

            if (user == null)
            {
                var message = "User not found";
                
                _logger.LogError(message);
                throw new Exception(message);
            }

            if (user.Status != UserStatus.Active)
            {
                var message = "User not active";

                _logger.LogError(message);
                throw new Exception(message);
            }

            return user;
        }

        public async Task<GetAllActiveUsersResponse> GetAllActiveUsers()
        {
            var users = _userRepository.GetAllActiveUsers();
            
            _logger.LogInformation("Get all users");

            return new GetAllActiveUsersResponse()
            {
                Data = users?.Select(x => new UserDTO(x)).ToList()
            };
        }
    }
}
