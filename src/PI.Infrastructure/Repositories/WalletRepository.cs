using Microsoft.EntityFrameworkCore;
using PI.Domain.Core.Repositories;
using PI.Domain.Entity;
using PI.Infrastructure.Data;

namespace PI.Infrastructure.Repositories
{
    public class WalletRepository : BaseRepositoryAsync<InvestmentPortfolio>, IWalletRepository
    {
        public WalletRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<InvestmentPosition> GetWalletSummaryByUserId(int userId)
        {
            return _dbSet.Where(ip => ip.UserId == userId)
                .SelectMany(ip => ip.Positions).Include(x => x.Asset);
        }
    }
}
