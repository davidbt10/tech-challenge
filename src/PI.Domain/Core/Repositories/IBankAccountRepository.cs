using PI.Domain.Entity;

namespace PI.Domain.Core.Repositories
{
    public interface IBankAccountRepository : IBaseRepositoryAsync<BankAccount>
    {
        Task<BankAccount?> GetBankAccountByUser(int userId);
    }
}
