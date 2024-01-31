using PI.Domain.Entity;

namespace PI.Application.Models.Responses
{
    public class GetAllAssetsResponse
    {
        public GetAllAssetsResponse(IEnumerable<Asset> stocks)
        {
            Stocks = stocks;
        }

        public IEnumerable<Asset> Stocks { get; set; }
    }
}
