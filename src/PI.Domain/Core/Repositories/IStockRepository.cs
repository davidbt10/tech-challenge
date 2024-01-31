using PI.Domain.Entity;

namespace PI.Domain.Core.Repositories
{
    public interface IStockRepository : IBaseRepositoryAsync<InvestmentPosition>
    {
        IEnumerable<Asset> GetAllAssets();
        Asset? GetAssetBySymbol(string symbol);
    }
}
