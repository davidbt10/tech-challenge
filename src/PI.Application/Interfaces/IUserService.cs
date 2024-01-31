using PI.Application.Models.Requests;
using PI.Application.Models.Responses;
using PI.Domain.Entity;

namespace PI.Application.Interfaces
{
    public interface IUserService
    {
        Task<CreateUserRes> CreateUser(CreateUserRequest request);

        Task<User> ValidateUser(ValidateUserRequest request);

        Task<GetAllActiveUsersResponse> GetAllActiveUsers();
    }
}
