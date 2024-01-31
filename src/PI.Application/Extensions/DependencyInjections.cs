using Microsoft.Extensions.DependencyInjection;
using PI.Application.Interfaces;
using PI.Application.Services;

namespace PI.Application.Extensions
{
    public static class DependencyInjections
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IWalletService, WalletService>();
            services.AddScoped<IBankAccountService, BankAccountService>();
            services.AddScoped<IStockService, StockService>();
        }
    }
}
