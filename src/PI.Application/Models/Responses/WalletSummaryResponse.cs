using PI.Domain.Entity;

namespace PI.Application.Models.Responses
{
    public class WalletSummaryResponse
    {
        public WalletSummaryResponse(IEnumerable<InvestmentPosition> positions)
        {
            foreach (var position in positions)
            {
                Stocks.Add(new Stock()
                {
                    Name = position.Asset.Name,
                    Symbol = position.Asset.Symbol,
                    AveragePrice = position.AveragePrice,
                    Quantity = position.Quantity,
                    BuyOn = position.CreatedOn

                });
            }
        }

        public List<Stock> Stocks { get; set; } = new List<Stock>();

        public class Stock
        {
            public string Name { get; set; }
            public string Symbol { get; set; }
            public decimal AveragePrice { get; set; }
            public decimal Quantity { get; set; }
            public DateTimeOffset BuyOn { get; set; }
        }
    }
}
