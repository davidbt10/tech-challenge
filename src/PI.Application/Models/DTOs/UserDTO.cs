using PI.Domain.Entity;

namespace PI.Application.Models.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Permission { get; set; }
        public int Status { get; set; }

        public UserDTO(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
            Permission = (int)user.Permission;
            Status = (int)user.Status;
        }
    }
}
