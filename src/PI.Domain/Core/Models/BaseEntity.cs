using System.ComponentModel.DataAnnotations;

namespace PI.Domain.Core.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
