using Microsoft.EntityFrameworkCore;
using PI.Domain.Core.Repositories;
using PI.Domain.Entity;
using PI.Domain.Enum;
using PI.Infrastructure.Data;

namespace PI.Infrastructure.Repositories
{
    public class UserRepository : BaseRepositoryAsync<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public Task<User> GetUserByEmailAndPassword(string email, string password)
        {
            return _dbSet.FirstOrDefaultAsync(x => x.Email.Equals(email) && x.Password.Equals(password));
        }

        public IEnumerable<User> GetAllActiveUsers()
        {
            return _dbSet.Where(x => x.Status == UserStatus.Active);
        }
    }
}
