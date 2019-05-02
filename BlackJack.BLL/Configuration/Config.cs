using AutoMapper;
using BlackJack.BLL.Interfaces;
using BlackJack.BLL.Mapper;
using BlackJack.BLL.Services;
using BlackJack.DAL.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlackJack.BLL.Configuration
{
    public static class Config
    {
        public static IServiceCollection AddBLLServices(this IServiceCollection services, string connectionString)
        {
            //services.AddDALServices(connectionString);
            services.AddDALServicesWithDapper(connectionString);
            
            services.AddAutoMapper();
            services.AddTransient<IStartGameService, StartGameService>();
            services.AddTransient<IGameStateService, GameStateService>();
            services.AddTransient<IGameService, GameService>();
            return services;
        }
    }
}
