using Microsoft.Extensions.Logging;
using Moq;
using PI.Application.Models.Requests;
using PI.Application.Services;
using PI.Domain.Core.Repositories;
using PI.Domain.Entity;
using PI.Domain.Enum;

namespace PI.Test.Application
{
    public class BankAccountServiceTest
    {
        private readonly Mock<IBankAccountRepository> _bankAccountRepository = new Mock<IBankAccountRepository>();
        private readonly Mock<IUserRepository> _userRepository = new Mock<IUserRepository>();
        private readonly Mock<ILogger<BankAccountService>> _logger = new Mock<ILogger<BankAccountService>>();
        private readonly BankAccountService _bankAccountService;

        public BankAccountServiceTest()
        {
            _bankAccountService = new BankAccountService(_bankAccountRepository.Object, _userRepository.Object, _logger.Object);

        }

        [Fact]
        public async void Given_WithValidData_When_CashDeposit_Then_SuccessfullyCashDeposit()
        {
            // Arrange
            CashDepositRequest req = new CashDepositRequest()
            {
                Account = 1,
                CashValue = 100
            };

            _bankAccountRepository
                .Setup(x => x.GetBankAccountByUser(It.IsAny<int>()))
                .ReturnsAsync(new BankAccount(1,100));

            // Act
            var result = await _bankAccountService.CashDeposit(req);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Deposit made successfully", result);
        }

        [Fact]
        public async void Given_WithValidData_When_NewAccount_Then_SuccessfullyCashDeposit()
        {
            // Arrange
            CashDepositRequest req = new CashDepositRequest()
            {
                Account = 1,
                CashValue = 100
            };

            _bankAccountRepository
                .Setup(x => x.GetBankAccountByUser(It.IsAny<int>()));

            _userRepository
                .Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(new User()
                {
                    Id = 1,
                    Status = UserStatus.Active
                });

            _bankAccountRepository.Setup(x => x.AddAsync(It.IsAny<BankAccount>()));

            // Act
            var result = await _bankAccountService.CashDeposit(req);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Deposit made successfully", result);
        }

        [Fact]
        public async void Given_WithInValidData_When_InvalidUser_Then_FailureCashDeposit()
        {
            // Arrange
            CashDepositRequest req = new CashDepositRequest()
            {
                Account = 2,
                CashValue = 10000
            };

            _bankAccountRepository
                .Setup(x => x.GetBankAccountByUser(It.IsAny<int>()));

            _userRepository
                .Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((User)null);

            // Act
            await Assert.ThrowsAsync<Exception>(async () => await _bankAccountService.CashDeposit(req));
        }
    }
}
