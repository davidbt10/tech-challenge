using Microsoft.EntityFrameworkCore;
using PI.Domain.Core.Repositories;
using PI.Domain.Entity;
using PI.Infrastructure.Data;

namespace PI.Infrastructure.Repositories
{
    public class BankAccountRepository : BaseRepositoryAsync<BankAccount>, IBankAccountRepository
    {
        public BankAccountRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public Task<BankAccount?> GetBankAccountByUser(int userId)
        {
            return _dbSet.FirstOrDefaultAsync(x => x.UserId == userId);
        }
    }
}
