using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PI.Application.Core.Models;
using PI.Application.Core.Services;
using PI.Domain.Core.Repositories;
using PI.Infrastructure.Data;
using PI.Infrastructure.Providers;
using PI.Infrastructure.Repositories;
using PI.Infrastructure.Services;

namespace PI.Infrastructure.Extensions
{
    public static class DependencyInjections
    {
        public static void ConfigureServices(IServiceCollection services, ILoggingBuilder logging, IConfiguration Configuration)
        {
            services.AddDbContext<ApplicationDbContext>(ServiceLifetime.Scoped);
            services.AddScoped(typeof(IBaseRepositoryAsync<>), typeof(BaseRepositoryAsync<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBankAccountRepository, BankAccountRepository>();
            services.AddScoped<IWalletRepository, WalletRepository>();
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<IInvestmentPortfolioRepository, InvestmentPortfolioRepository>();
            services.AddScoped<IEmailService, EmailService>();
            
            logging.ClearProviders();
            logging.AddProvider(new CustomLoggerProvider(new CustomLoggerProviderConfiguration(){LogLevel = LogLevel.Information}));
        }
    }
}
