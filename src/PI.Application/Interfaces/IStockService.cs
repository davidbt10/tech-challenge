using PI.Application.Models.Requests;
using PI.Application.Models.Responses;

namespace PI.Application.Interfaces
{
    public interface IStockService
    {
        GetAllAssetsResponse GetAllAssets();
        Task<BuyStockResponse> BuyStock(BuyStockRequest request);
    }
}
