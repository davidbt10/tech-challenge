using System.ComponentModel.DataAnnotations;

namespace PI.Application.Models.Requests
{
    public class ValidateUserRequest
    {
        [Required]
        [MaxLength(30)]
        public string Email { get; set; }

        [Required]
        [MaxLength(8)]
        public string Password { get; set; }
    }
}
