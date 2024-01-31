using Microsoft.Extensions.Logging;
using PI.Application.Core.Models;
using PI.Application.Core.Services;
using PI.Application.Interfaces;
using PI.Application.Models.Requests;
using PI.Application.Models.Responses;
using PI.Domain.Core.Repositories;
using PI.Domain.Entity;

namespace PI.Application.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly IEmailService _emailService;
        private readonly IInvestmentPortfolioRepository _investmentPortfolioRepository;
        
        private readonly ILogger<UserService> _logger;

        public StockService(IStockRepository stockRepository,
            ILogger<UserService> logger,
            IBankAccountRepository bankAccountRepository,
            IInvestmentPortfolioRepository investmentPortfolioRepository,
            IEmailService emailService)
        {
            _stockRepository = stockRepository;
            _logger = logger;
            _bankAccountRepository = bankAccountRepository;
            _investmentPortfolioRepository = investmentPortfolioRepository;
            _emailService = emailService;
        }

        public GetAllAssetsResponse GetAllAssets()
        {
            return new GetAllAssetsResponse(_stockRepository.GetAllAssets());
        }

        public async Task<BuyStockResponse> BuyStock(BuyStockRequest request)
        {
            var stock = GetAssetBySymbol(request.Symbol);
            var account = await GetAccountByUserId(request.UserId);

            var totalPrice = request.Amount * stock.Price;

            if (account.GetBalance() < totalPrice)
            {
                var message = "Insufficient balance";

                _logger.LogInformation(message);
                return new BuyStockResponse(false, message);
            }

            account.SubtractBalance(totalPrice);
            _bankAccountRepository.Update(account);

            var portifolio = _investmentPortfolioRepository.GetOrCreatePortfolio(request.UserId);

            portifolio.Positions.Add(new InvestmentPosition()
            {
                AssetId = stock.Id,
                AveragePrice = stock.Price,
                Quantity = request.Amount,
                CreatedOn = DateTime.Now,
                LastModifiedOn = DateTime.Now,
                InvestmentPortfolioId = portifolio.Id
            });

            _investmentPortfolioRepository.Update(portifolio);
            SendEmail(stock.Name);

            return new BuyStockResponse(true, "Success");
        }

        private Asset GetAssetBySymbol(string symbol)
        {
            var stock = _stockRepository.GetAssetBySymbol(symbol);

            if (stock != null)
                return stock;

            var message = "Stock not found";
            _logger.LogInformation(message);
            throw new Exception(message);
        }

        private async Task<BankAccount> GetAccountByUserId(int userId)
        {
            var account = await _bankAccountRepository.GetBankAccountByUser(userId);

            if (account != null)
                return account;

            var message = "Account not found";
            _logger.LogInformation(message);
            throw new Exception(message);
        }

        private void SendEmail(string stock)
        {
            _emailService.SendEmail(new Email()
            {
                Subject = "david@gmail.com",
                From = "pxinvestimentos@gmail.com",
                Body = $"Compra do ativo {stock}, executado com sucesso"
            });
        }
    }
}
