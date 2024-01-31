using PI.Domain.Entity;

namespace PI.Application.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
