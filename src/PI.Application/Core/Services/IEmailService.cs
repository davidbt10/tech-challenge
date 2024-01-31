using PI.Application.Core.Models;

namespace PI.Application.Core.Services
{
    public interface IEmailService
    {
        void SendEmail(Email email);
    }
}
