using BlackJack.BLL.Interfaces;
using BlackJack.BLL.Services;
using BlackJack.DAL.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlackJack.BLL.Configuration
{
    public static class Config
    {
        public static IServiceCollection AddBLLServices(this IServiceCollection services, string connectionString)
        {
            services.AddDALServices(connectionString);

            services.AddTransient<IStartGameService, StartGameService>();
            services.AddTransient<IStateGameService, StateGameService>();
            services.AddTransient<IGameService, GameService>();
            return services;
        }
    }
}
