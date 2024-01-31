using PI.Application.Models.Responses;

namespace PI.Application.Interfaces
{
    public interface IWalletService
    {
        Task<WalletSummaryResponse> GetWalletSummaryByUserId(int userId);
    }
}
