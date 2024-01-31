using PI.Domain.Entity;

namespace PI.Application.Models.Requests
{
    public class CreateBankAccountRequest
    {
        public decimal Balance { get; set; }
        public int UserId { get; set; }
    }
}
