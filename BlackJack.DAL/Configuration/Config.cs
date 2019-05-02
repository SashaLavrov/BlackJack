using BlackJack.DAL.DapperRepositories;
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

        public static IServiceCollection AddDALServicesWithDapper(this IServiceCollection services, string connectionString)
        {
            services.AddTransient<IRepository<Round>, RoundRepositoryDapper>(provider => new RoundRepositoryDapper(connectionString));
            services.AddTransient<IRepository<Game>, GameRepositoryDapper>(provider => new GameRepositoryDapper(connectionString));
            services.AddTransient<IRepository<ComboCard>, ComboCardRepositoryDapper>(provider => new ComboCardRepositoryDapper(connectionString));
            services.AddTransient<IRepository<Combination>, CombinationRepositoryDapper>(provider => new CombinationRepositoryDapper(connectionString));
            services.AddTransient<IUserRepository, UserRepositoryDapper>(provider => new UserRepositoryDapper(connectionString));
            services.AddTransient<ICardRepository, CardRepositoryDapper>(provider => new CardRepositoryDapper(connectionString));

            return services;
        }
    }
}
