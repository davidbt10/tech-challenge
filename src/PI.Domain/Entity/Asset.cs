using PI.Domain.Core.Models;

namespace PI.Domain.Entity
{
    public class Asset : BaseEntity
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public List<InvestmentPosition> InvestmentPositions { get; set; }
    }
}
