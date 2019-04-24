using BlackJack.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.DAL.DataEF
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }
        public DbSet<Combination> Combinations { get; set; }
        public DbSet<ComboCard> ComboCards { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<User> Users { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Card>().HasData(
            new Card[]
            {
                new Card {CardId=2, Suit="Hearts", Value=11, Type="ace"},
                new Card {CardId=3, Suit="Diamonds", Value=11, Type="ace"},
                new Card {CardId=4, Suit="Clubs", Value=11, Type="ace"},
                new Card {CardId=5, Suit="Spades", Value=11, Type="ace"},

                new Card {CardId=6, Suit="Hearts", Value=2, Type="two"},
                new Card {CardId=7, Suit="Hearts", Value=3, Type="three"},
                new Card {CardId=8, Suit="Hearts", Value=4, Type="four"},
                new Card {CardId=9, Suit="Hearts", Value=5, Type="five"},
                new Card {CardId=10, Suit="Hearts", Value=6, Type="six"},
                new Card {CardId=11, Suit="Hearts", Value=7, Type="seven"},
                new Card {CardId=12, Suit="Hearts", Value=8, Type="eight"},
                new Card {CardId=13, Suit="Hearts", Value=9, Type="nine"},
                new Card {CardId=14, Suit="Hearts", Value=10, Type="ten"},
                new Card {CardId=15, Suit="Hearts", Value=10, Type="jack"},
                new Card {CardId=16, Suit="Hearts", Value=10, Type="queen"},
                new Card {CardId=17, Suit="Hearts", Value=10, Type="king"},

                new Card {CardId=18, Suit="Diamonds ", Value=2, Type="two"},
                new Card {CardId=19, Suit="Diamonds ", Value=3, Type="three"},
                new Card {CardId=20, Suit="Diamonds ", Value=4, Type="four"},
                new Card {CardId=21, Suit="Diamonds ", Value=5, Type="five"},
                new Card {CardId=22, Suit="Diamonds ", Value=6, Type="six"},
                new Card {CardId=23, Suit="Diamonds ", Value=7, Type="seven"},
                new Card {CardId=24, Suit="Diamonds ", Value=8, Type="eight"},
                new Card {CardId=25, Suit="Diamonds ", Value=9, Type="nine"},
                new Card {CardId=26, Suit="Diamonds ", Value=10, Type="ten"},
                new Card {CardId=27, Suit="Diamonds ", Value=10, Type="jack"},
                new Card {CardId=28, Suit="Diamonds ", Value=10, Type="queen"},
                new Card {CardId=29, Suit="Diamonds ", Value=10, Type="king"},

                new Card {CardId=30, Suit="Clubs", Value=2, Type="two"},
                new Card {CardId=31, Suit="Clubs", Value=3, Type="three"},
                new Card {CardId=32, Suit="Clubs", Value=4, Type="four"},
                new Card {CardId=33, Suit="Clubs", Value=5, Type="five"},
                new Card {CardId=34, Suit="Clubs", Value=6, Type="six"},
                new Card {CardId=35, Suit="Clubs", Value=7, Type="seven"},
                new Card {CardId=36, Suit="Clubs", Value=8, Type="eight"},
                new Card {CardId=37, Suit="Clubs", Value=9, Type="nine"},
                new Card {CardId=38, Suit="Clubs", Value=10, Type="ten"},
                new Card {CardId=39, Suit="Clubs", Value=10, Type="jack"},
                new Card {CardId=40, Suit="Clubs", Value=10, Type="queen"},
                new Card {CardId=41, Suit="Clubs", Value=10, Type="king"},

                new Card {CardId=42, Suit="Spades", Value=2, Type="two"},
                new Card {CardId=43, Suit="Spades", Value=3, Type="three"},
                new Card {CardId=44, Suit="Spades", Value=4, Type="four"},
                new Card {CardId=45, Suit="Spades", Value=5, Type="five"},
                new Card {CardId=46, Suit="Spades", Value=6, Type="six"},
                new Card {CardId=47, Suit="Spades", Value=7, Type="seven"},
                new Card {CardId=48, Suit="Spades", Value=8, Type="eight"},
                new Card {CardId=49, Suit="Spades", Value=9, Type="nine"},
                new Card {CardId=50, Suit="Spades", Value=10, Type="ten"},
                new Card {CardId=51, Suit="Spades", Value=10, Type="jack"},
                new Card {CardId=52, Suit="Spades", Value=10, Type="queen"},
                new Card {CardId=53, Suit="Spades", Value=10, Type="king"},
            });
            base.OnModelCreating(builder);
        }
    }
}

