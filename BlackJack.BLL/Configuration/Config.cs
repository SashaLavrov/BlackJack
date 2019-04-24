using BlackJack.BLL.Interfaces;
using BlackJack.BLL.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace BlackJack.BLL.Configuration
{
    public static class Config
    {
        public static IServiceCollection AddEF(this IServiceCollection services, string connectionString)
        {
            services.AddEF(connectionString);
            services.AddTransient<IStartGameService, StartGameService>();

            return services;
        }
    }
}
