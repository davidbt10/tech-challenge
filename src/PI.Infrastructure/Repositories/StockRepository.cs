using PI.Domain.Core.Repositories;
using PI.Domain.Entity;
using PI.Infrastructure.Data;

namespace PI.Infrastructure.Repositories
{
    public class StockRepository : BaseRepositoryAsync<InvestmentPosition>, IStockRepository
    {
        public StockRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Asset> GetAllAssets()
        {
            return _dbContext.Set<Asset>().ToList();
        }

        public Asset? GetAssetBySymbol(string symbol)
        {
            return _dbContext.Set<Asset>().FirstOrDefault(x => x.Symbol.Equals(symbol));
        }
    }
}
