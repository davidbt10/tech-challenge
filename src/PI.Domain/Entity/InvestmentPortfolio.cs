using PI.Domain.Core.Models;

namespace PI.Domain.Entity
{
    public class InvestmentPortfolio : BaseEntity
    {
        public List<InvestmentPosition> Positions { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
