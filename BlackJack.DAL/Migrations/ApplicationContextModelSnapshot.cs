﻿// <auto-generated />
using System;
using BlackJack.DAL.DataEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlackJack.DAL.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlackJack.DAL.Entities.Card", b =>
                {
                    b.Property<int>("CardId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Suit");

                    b.Property<string>("Type");

                    b.Property<int>("Value");

                    b.HasKey("CardId");

                    b.ToTable("Cards");

                    b.HasData(
                        new
                        {
                            CardId = 2,
                            Suit = "Hearts",
                            Type = "ace",
                            Value = 11
                        },
                        new
                        {
                            CardId = 3,
                            Suit = "Diamonds",
                            Type = "ace",
                            Value = 11
                        },
                        new
                        {
                            CardId = 4,
                            Suit = "Clubs",
                            Type = "ace",
                            Value = 11
                        },
                        new
                        {
                            CardId = 5,
                            Suit = "Spades",
                            Type = "ace",
                            Value = 11
                        },
                        new
                        {
                            CardId = 6,
                            Suit = "Hearts",
                            Type = "two",
                            Value = 2
                        },
                        new
                        {
                            CardId = 7,
                            Suit = "Hearts",
                            Type = "three",
                            Value = 3
                        },
                        new
                        {
                            CardId = 8,
                            Suit = "Hearts",
                            Type = "four",
                            Value = 4
                        },
                        new
                        {
                            CardId = 9,
                            Suit = "Hearts",
                            Type = "five",
                            Value = 5
                        },
                        new
                        {
                            CardId = 10,
                            Suit = "Hearts",
                            Type = "six",
                            Value = 6
                        },
                        new
                        {
                            CardId = 11,
                            Suit = "Hearts",
                            Type = "seven",
                            Value = 7
                        },
                        new
                        {
                            CardId = 12,
                            Suit = "Hearts",
                            Type = "eight",
                            Value = 8
                        },
                        new
                        {
                            CardId = 13,
                            Suit = "Hearts",
                            Type = "nine",
                            Value = 9
                        },
                        new
                        {
                            CardId = 14,
                            Suit = "Hearts",
                            Type = "ten",
                            Value = 10
                        },
                        new
                        {
                            CardId = 15,
                            Suit = "Hearts",
                            Type = "jack",
                            Value = 10
                        },
                        new
                        {
                            CardId = 16,
                            Suit = "Hearts",
                            Type = "queen",
                            Value = 10
                        },
                        new
                        {
                            CardId = 17,
                            Suit = "Hearts",
                            Type = "king",
                            Value = 10
                        },
                        new
                        {
                            CardId = 18,
                            Suit = "Diamonds ",
                            Type = "two",
                            Value = 2
                        },
                        new
                        {
                            CardId = 19,
                            Suit = "Diamonds ",
                            Type = "three",
                            Value = 3
                        },
                        new
                        {
                            CardId = 20,
                            Suit = "Diamonds ",
                            Type = "four",
                            Value = 4
                        },
                        new
                        {
                            CardId = 21,
                            Suit = "Diamonds ",
                            Type = "five",
                            Value = 5
                        },
                        new
                        {
                            CardId = 22,
                            Suit = "Diamonds ",
                            Type = "six",
                            Value = 6
                        },
                        new
                        {
                            CardId = 23,
                            Suit = "Diamonds ",
                            Type = "seven",
                            Value = 7
                        },
                        new
                        {
                            CardId = 24,
                            Suit = "Diamonds ",
                            Type = "eight",
                            Value = 8
                        },
                        new
                        {
                            CardId = 25,
                            Suit = "Diamonds ",
                            Type = "nine",
                            Value = 9
                        },
                        new
                        {
                            CardId = 26,
                            Suit = "Diamonds ",
                            Type = "ten",
                            Value = 10
                        },
                        new
                        {
                            CardId = 27,
                            Suit = "Diamonds ",
                            Type = "jack",
                            Value = 10
                        },
                        new
                        {
                            CardId = 28,
                            Suit = "Diamonds ",
                            Type = "queen",
                            Value = 10
                        },
                        new
                        {
                            CardId = 29,
                            Suit = "Diamonds ",
                            Type = "king",
                            Value = 10
                        },
                        new
                        {
                            CardId = 30,
                            Suit = "Clubs",
                            Type = "two",
                            Value = 2
                        },
                        new
                        {
                            CardId = 31,
                            Suit = "Clubs",
                            Type = "three",
                            Value = 3
                        },
                        new
                        {
                            CardId = 32,
                            Suit = "Clubs",
                            Type = "four",
                            Value = 4
                        },
                        new
                        {
                            CardId = 33,
                            Suit = "Clubs",
                            Type = "five",
                            Value = 5
                        },
                        new
                        {
                            CardId = 34,
                            Suit = "Clubs",
                            Type = "six",
                            Value = 6
                        },
                        new
                        {
                            CardId = 35,
                            Suit = "Clubs",
                            Type = "seven",
                            Value = 7
                        },
                        new
                        {
                            CardId = 36,
                            Suit = "Clubs",
                            Type = "eight",
                            Value = 8
                        },
                        new
                        {
                            CardId = 37,
                            Suit = "Clubs",
                            Type = "nine",
                            Value = 9
                        },
                        new
                        {
                            CardId = 38,
                            Suit = "Clubs",
                            Type = "ten",
                            Value = 10
                        },
                        new
                        {
                            CardId = 39,
                            Suit = "Clubs",
                            Type = "jack",
                            Value = 10
                        },
                        new
                        {
                            CardId = 40,
                            Suit = "Clubs",
                            Type = "queen",
                            Value = 10
                        },
                        new
                        {
                            CardId = 41,
                            Suit = "Clubs",
                            Type = "king",
                            Value = 10
                        },
                        new
                        {
                            CardId = 42,
                            Suit = "Spades",
                            Type = "two",
                            Value = 2
                        },
                        new
                        {
                            CardId = 43,
                            Suit = "Spades",
                            Type = "three",
                            Value = 3
                        },
                        new
                        {
                            CardId = 44,
                            Suit = "Spades",
                            Type = "four",
                            Value = 4
                        },
                        new
                        {
                            CardId = 45,
                            Suit = "Spades",
                            Type = "five",
                            Value = 5
                        },
                        new
                        {
                            CardId = 46,
                            Suit = "Spades",
                            Type = "six",
                            Value = 6
                        },
                        new
                        {
                            CardId = 47,
                            Suit = "Spades",
                            Type = "seven",
                            Value = 7
                        },
                        new
                        {
                            CardId = 48,
                            Suit = "Spades",
                            Type = "eight",
                            Value = 8
                        },
                        new
                        {
                            CardId = 49,
                            Suit = "Spades",
                            Type = "nine",
                            Value = 9
                        },
                        new
                        {
                            CardId = 50,
                            Suit = "Spades",
                            Type = "ten",
                            Value = 10
                        },
                        new
                        {
                            CardId = 51,
                            Suit = "Spades",
                            Type = "jack",
                            Value = 10
                        },
                        new
                        {
                            CardId = 52,
                            Suit = "Spades",
                            Type = "queen",
                            Value = 10
                        },
                        new
                        {
                            CardId = 53,
                            Suit = "Spades",
                            Type = "king",
                            Value = 10
                        });
                });

            modelBuilder.Entity("BlackJack.DAL.Entities.Combination", b =>
                {
                    b.Property<int>("CombinationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoundId");

                    b.Property<int>("UserId");

                    b.HasKey("CombinationId");

                    b.HasIndex("RoundId");

                    b.HasIndex("UserId");

                    b.ToTable("Combinations");
                });

            modelBuilder.Entity("BlackJack.DAL.Entities.ComboCard", b =>
                {
                    b.Property<int>("ComboCardId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CardId");

                    b.Property<int>("CombinationId");

                    b.HasKey("ComboCardId");

                    b.HasIndex("CardId");

                    b.HasIndex("CombinationId");

                    b.ToTable("ComboCards");
                });

            modelBuilder.Entity("BlackJack.DAL.Entities.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("GameDate");

                    b.HasKey("GameId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("BlackJack.DAL.Entities.Round", b =>
                {
                    b.Property<int>("RoundId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GameId");

                    b.Property<int>("RoundNumber");

                    b.HasKey("RoundId");

                    b.HasIndex("GameId");

                    b.ToTable("Rounds");
                });

            modelBuilder.Entity("BlackJack.DAL.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsBot");

                    b.Property<string>("Nickname");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            IsBot = false,
                            Nickname = "Dealer"
                        },
                        new
                        {
                            UserId = 2,
                            IsBot = true,
                            Nickname = "Bot_1"
                        },
                        new
                        {
                            UserId = 3,
                            IsBot = true,
                            Nickname = "Bot_2"
                        },
                        new
                        {
                            UserId = 4,
                            IsBot = true,
                            Nickname = "Bot_3"
                        },
                        new
                        {
                            UserId = 5,
                            IsBot = true,
                            Nickname = "Bot_4"
                        },
                        new
                        {
                            UserId = 6,
                            IsBot = true,
                            Nickname = "Bot_5"
                        },
                        new
                        {
                            UserId = 7,
                            IsBot = true,
                            Nickname = "Bot_6"
                        });
                });

            modelBuilder.Entity("BlackJack.DAL.Entities.Combination", b =>
                {
                    b.HasOne("BlackJack.DAL.Entities.Round", "Round")
                        .WithMany("Combinations")
                        .HasForeignKey("RoundId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BlackJack.DAL.Entities.User", "User")
                        .WithMany("Combinations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BlackJack.DAL.Entities.ComboCard", b =>
                {
                    b.HasOne("BlackJack.DAL.Entities.Card", "Card")
                        .WithMany("ComboCards")
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BlackJack.DAL.Entities.Combination", "Combination")
                        .WithMany()
                        .HasForeignKey("CombinationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BlackJack.DAL.Entities.Round", b =>
                {
                    b.HasOne("BlackJack.DAL.Entities.Game", "Game")
                        .WithMany("Rounds")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}