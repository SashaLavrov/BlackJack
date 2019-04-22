using BlackJack.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.DAL.DataEF
{
    class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Card> Cards { get; set; }
        public DbSet<Combination> Combinations { get; set; }
        public DbSet<ComboCard> ComboCards { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Game> Games { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}

