using PI.Application.Models.DTOs;

namespace PI.Application.Models.Responses
{
    public class GetAllActiveUsersResponse
    {
        public IList<UserDTO>? Data { get; set; }
    }
}
