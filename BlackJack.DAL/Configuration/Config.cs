using BlackJack.DAL.DataEF;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using BlackJack.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace BlackJack.DAL.Configuration
{
    public static class Config
    {
        public static IServiceCollection AddDALServices(this IServiceCollection services, string connectionString)

        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddTransient<ICardRepository, CardRepository>();
            services.AddTransient<IRepository<Game>, GameRepository>();
            services.AddTransient<IRepository<Combination>, CombinationRepository>();
            services.AddTransient<IRepository<ComboCard>, ComboCardRepository>();
            services.AddTransient<IRepository<Round>, RoundRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }
    }
}
