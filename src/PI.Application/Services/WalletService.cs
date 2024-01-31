using Microsoft.Extensions.Logging;
using PI.Application.Interfaces;
using PI.Application.Models.Responses;
using PI.Domain.Core.Repositories;

namespace PI.Application.Services
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _walletRepository;
        private readonly ILogger<WalletService> _logger;

        public WalletService(IWalletRepository walletRepository,
            ILogger<WalletService> logger)
        {
            _walletRepository = walletRepository;
            _logger = logger;
        }

        public async Task<WalletSummaryResponse> GetWalletSummaryByUserId(int userId)
        {
            var positions = _walletRepository.GetWalletSummaryByUserId(userId);

            if (positions == null || !positions.Any())
            {
                var message = "Wallet not found";
                _logger.LogInformation(message);
                throw new Exception(message);
            }

            return new WalletSummaryResponse(positions);
        }
    }
}
