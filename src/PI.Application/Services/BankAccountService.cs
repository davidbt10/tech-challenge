using Microsoft.Extensions.Logging;
using PI.Application.Interfaces;
using PI.Application.Models.Requests;
using PI.Application.Models.Responses;
using PI.Domain.Core.Repositories;
using PI.Domain.Entity;

namespace PI.Application.Services
{
    public class BankAccountService : IBankAccountService
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<BankAccountService> _logger;

        public BankAccountService(IBankAccountRepository bankAccountRepository,
            IUserRepository userRepository,
            ILogger<BankAccountService> logger)
        {
            _bankAccountRepository = bankAccountRepository;
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<string> CashDeposit(CashDepositRequest request)
        {
            var account = await _bankAccountRepository.GetBankAccountByUser(request.Account);

            if (account != null)
            {
                account.AddBalance(request.CashValue);
                _bankAccountRepository.Update(account);
                return "Deposit made successfully";
            }
            var user = await _userRepository.GetByIdAsync(request.Account);

            if (user == null)
            {
                var message = $"Bank Account not found: {request.Account}";

                _logger.LogError(message);
                throw new Exception(message);
            }

            await _bankAccountRepository.AddAsync(new BankAccount(request.Account, request.CashValue));
            return "Deposit made successfully";
        }

        public async Task<CashWithdrawalResponse> CashWithdrawal(CashDepositRequest request)
        {
            var account = await _bankAccountRepository.GetBankAccountByUser(request.Account);

            if (account == null)
            {
                var message = $"Bank Account not found: {request.Account}";
                
                _logger.LogError(message);
                return new CashWithdrawalResponse(false, message);
            }

            if (account.Balance < request.CashValue)
                return new CashWithdrawalResponse(false, "Insufficient funds");
                    
            account.SubtractBalance(request.CashValue);
            _bankAccountRepository.Update(account);

            return new CashWithdrawalResponse(true);
        }
    }
}
