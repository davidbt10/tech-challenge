using PI.Domain.Core.Repositories;
using PI.Domain.Entity;
using PI.Infrastructure.Data;

namespace PI.Infrastructure.Repositories
{
    public class InvestmentPortfolioRepository : BaseRepositoryAsync<InvestmentPortfolio>, IInvestmentPortfolioRepository
    {
        public InvestmentPortfolioRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public InvestmentPortfolio GetOrCreatePortfolio(int userId)
        {
            var portifolio = _dbSet.FirstOrDefault(x => x.UserId == userId);

            if (portifolio != null)
                return portifolio;

            _dbSet.Add(new InvestmentPortfolio() { UserId = userId });
            return _dbSet.First(x => x.UserId == userId);
        }
    }
}
