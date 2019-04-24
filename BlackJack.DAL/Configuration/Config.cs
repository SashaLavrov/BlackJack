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
        public static IServiceCollection AddEF(this IServiceCollection services, string connectionString)

        {
            services.AddTransient<DbConnection>(provider => new SqlConnection(connectionString));

            services.AddDbContext<ApplicationContext>(c => c.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

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
