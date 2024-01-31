using PI.Domain.Entity;

namespace PI.Domain.Core.Repositories
{
    public interface IWalletRepository
    {
        IEnumerable<InvestmentPosition> GetWalletSummaryByUserId(int userId);
    }
}
