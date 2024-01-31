using PI.Domain.Core.Models;
using PI.Domain.Enum;

namespace PI.Domain.Entity
{
    public class User : BaseEntity, IAuditableEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public PermissionTypes Permission { get; set; }
        public UserStatus Status { get; set; }

        public BankAccount BankAccount { get; set; }
        public InvestmentPortfolio InvestmentPortfolio { get; set; }


        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
