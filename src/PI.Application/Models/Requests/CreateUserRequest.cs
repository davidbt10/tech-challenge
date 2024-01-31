using System.ComponentModel.DataAnnotations;

namespace PI.Application.Models.Requests
{
    public class CreateUserRequest
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(30)]
        public string Email { get; set; }

        [Required]
        public int PermissionId { get; set; }

        [Required]
        [MaxLength(8)]
        public string Password { get; set; }
    }
}
