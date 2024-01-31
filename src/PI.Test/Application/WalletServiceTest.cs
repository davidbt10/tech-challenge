using Microsoft.Extensions.Logging;
using Moq;
using PI.Application.Services;
using PI.Domain.Core.Repositories;
using PI.Domain.Entity;

namespace PI.Test.Application
{
    public class WalletServiceTest
    {
        private readonly Mock<IWalletRepository> _walletRepository = new Mock<IWalletRepository>();
        private readonly Mock<ILogger<WalletService>> _logger = new Mock<ILogger<WalletService>>();
        private readonly WalletService _walletService;

        public WalletServiceTest()
        {
            _walletService = new WalletService(_walletRepository.Object, _logger.Object);
        }

        [Fact]
        public async void Given_WithValidData_When_GetWallet_Then_SuccessfullySummary()
        {
            // Arrange

            _walletRepository
                .Setup(x => x.GetWalletSummaryByUserId(It.IsAny<int>()))
                .Returns(new List<InvestmentPosition>()
                {
                    new InvestmentPosition()
                    {
                        Asset = new Asset()
                        {
                            Name = "APPLE INC",
                            Symbol = "AAPL"
                        },
                        Quantity = 100,
                        AveragePrice = 100,
                        CreatedOn = DateTime.Now
                    }
                });

            // Act
            var result = await _walletService.GetWalletSummaryByUserId(1);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result.Stocks);
        }

        [Fact]
        public async void Given_WithInValidData_When_InvalidUser_Then_FailureGetWalletSummary()
        {
            // Arrange
            _walletRepository
                .Setup(x => x.GetWalletSummaryByUserId(It.IsAny<int>()));

            // Act
            await Assert.ThrowsAsync<Exception>(async () => await _walletService.GetWalletSummaryByUserId(1));
        }
    }
}
