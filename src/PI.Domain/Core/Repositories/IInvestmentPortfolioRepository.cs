using PI.Domain.Entity;

namespace PI.Domain.Core.Repositories
{
    public interface IInvestmentPortfolioRepository : IBaseRepositoryAsync<InvestmentPortfolio>
    {
        InvestmentPortfolio GetOrCreatePortfolio(int userId);
    }
}
