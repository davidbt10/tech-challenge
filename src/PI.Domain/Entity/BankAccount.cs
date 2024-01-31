using PI.Domain.Core.Models;

namespace PI.Domain.Entity
{
    public class BankAccount : BaseEntity, IAuditableEntity
    {
        public BankAccount(int userId, decimal balance)
        {
            UserId = userId;
            Balance = balance;
        }

        public decimal Balance { get; private set; }
        public int UserId { get; set; }

        public decimal GetBalance()
        {
            return Balance;
        }

        public void AddBalance(decimal value)
        {
            Balance += value;
            LastModifiedOn = DateTime.Now;
        }

        public void SubtractBalance(decimal value)
        {
            Balance -= value;
            LastModifiedOn = DateTime.Now;
        }

        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? LastModifiedOn { get; set; }

        public User User { get; set; }
    }
}
