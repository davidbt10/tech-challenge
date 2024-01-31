using PI.Application.Models.Requests;
using PI.Application.Models.Responses;

namespace PI.Application.Interfaces
{
    public interface IBankAccountService
    {
        Task<string> CashDeposit(CashDepositRequest request);
        Task<CashWithdrawalResponse> CashWithdrawal(CashDepositRequest request);
    }
}
