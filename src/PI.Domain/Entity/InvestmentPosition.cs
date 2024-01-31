using PI.Domain.Core.Models;

namespace PI.Domain.Entity
{
    public class InvestmentPosition : BaseEntity, IAuditableEntity
    {
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public decimal Quantity { get; set; }
        public decimal AveragePrice { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? LastModifiedOn { get; set; }

        public int InvestmentPortfolioId { get; set; }
        public InvestmentPortfolio InvestmentPortfolio { get; set; }
    }
}
