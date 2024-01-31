namespace PI.Application.Models.Requests
{
    public class CashDepositRequest
    {
        public int Account { get; set; }
        public decimal CashValue { get; set; }
    }
}
