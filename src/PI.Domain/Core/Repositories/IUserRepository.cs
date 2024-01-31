using PI.Domain.Entity;

namespace PI.Domain.Core.Repositories
{
    public interface IUserRepository : IBaseRepositoryAsync<User>
    {
        Task<User> GetUserByEmailAndPassword(string email, string password);
        IEnumerable<User> GetAllActiveUsers();
    }
}
