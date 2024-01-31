namespace PI.Application.Models.Requests
{
    public class BuyStockRequest
    {
        public int Amount { get; set; }
        public string Symbol { get; set; }
        public int UserId { get; set; }
    }
}
