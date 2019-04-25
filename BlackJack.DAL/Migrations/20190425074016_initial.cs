using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackJack.DAL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    CardId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Suit = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.CardId);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GameDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nickname = table.Column<string>(nullable: true),
                    IsBot = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Rounds",
                columns: table => new
                {
                    RoundId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoundNumber = table.Column<int>(nullable: false),
                    GameId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rounds", x => x.RoundId);
                    table.ForeignKey(
                        name: "FK_Rounds_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Combinations",
                columns: table => new
                {
                    CombinationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoundId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combinations", x => x.CombinationId);
                    table.ForeignKey(
                        name: "FK_Combinations_Rounds_RoundId",
                        column: x => x.RoundId,
                        principalTable: "Rounds",
                        principalColumn: "RoundId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Combinations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComboCards",
                columns: table => new
                {
                    ComboCardId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CombinationId = table.Column<int>(nullable: false),
                    CardId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComboCards", x => x.ComboCardId);
                    table.ForeignKey(
                        name: "FK_ComboCards_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "CardId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComboCards_Combinations_CombinationId",
                        column: x => x.CombinationId,
                        principalTable: "Combinations",
                        principalColumn: "CombinationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "CardId", "Suit", "Type", "Value" },
                values: new object[,]
                {
                    { 2, "Hearts", "ace", 11 },
                    { 30, "Clubs", "two", 2 },
                    { 32, "Clubs", "four", 4 },
                    { 33, "Clubs", "five", 5 },
                    { 34, "Clubs", "six", 6 },
                    { 35, "Clubs", "seven", 7 },
                    { 36, "Clubs", "eight", 8 },
                    { 37, "Clubs", "nine", 9 },
                    { 38, "Clubs", "ten", 10 },
                    { 39, "Clubs", "jack", 10 },
                    { 40, "Clubs", "queen", 10 },
                    { 41, "Clubs", "king", 10 },
                    { 42, "Spades", "two", 2 },
                    { 43, "Spades", "three", 3 },
                    { 44, "Spades", "four", 4 },
                    { 45, "Spades", "five", 5 },
                    { 46, "Spades", "six", 6 },
                    { 47, "Spades", "seven", 7 },
                    { 48, "Spades", "eight", 8 },
                    { 49, "Spades", "nine", 9 },
                    { 50, "Spades", "ten", 10 },
                    { 51, "Spades", "jack", 10 },
                    { 52, "Spades", "queen", 10 },
                    { 53, "Spades", "king", 10 },
                    { 29, "Diamonds ", "king", 10 },
                    { 28, "Diamonds ", "queen", 10 },
                    { 31, "Clubs", "three", 3 },
                    { 26, "Diamonds ", "ten", 10 },
                    { 3, "Diamonds", "ace", 11 },
                    { 4, "Clubs", "ace", 11 },
                    { 5, "Spades", "ace", 11 },
                    { 6, "Hearts", "two", 2 },
                    { 7, "Hearts", "three", 3 },
                    { 8, "Hearts", "four", 4 },
                    { 9, "Hearts", "five", 5 },
                    { 10, "Hearts", "six", 6 },
                    { 11, "Hearts", "seven", 7 },
                    { 27, "Diamonds ", "jack", 10 },
                    { 13, "Hearts", "nine", 9 },
                    { 14, "Hearts", "ten", 10 },
                    { 12, "Hearts", "eight", 8 },
                    { 16, "Hearts", "queen", 10 },
                    { 25, "Diamonds ", "nine", 9 },
                    { 15, "Hearts", "jack", 10 },
                    { 23, "Diamonds ", "seven", 7 },
                    { 22, "Diamonds ", "six", 6 },
                    { 24, "Diamonds ", "eight", 8 },
                    { 20, "Diamonds ", "four", 4 },
                    { 19, "Diamonds ", "three", 3 },
                    { 18, "Diamonds ", "two", 2 },
                    { 17, "Hearts", "king", 10 },
                    { 21, "Diamonds ", "five", 5 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "IsBot", "Nickname" },
                values: new object[,]
                {
                    { 6, true, "Bot_5" },
                    { 1, false, "Dealer" },
                    { 2, true, "Bot_1" },
                    { 3, true, "Bot_2" },
                    { 4, true, "Bot_3" },
                    { 5, true, "Bot_4" },
                    { 7, true, "Bot_6" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Combinations_RoundId",
                table: "Combinations",
                column: "RoundId");

            migrationBuilder.CreateIndex(
                name: "IX_Combinations_UserId",
                table: "Combinations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboCards_CardId",
                table: "ComboCards",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboCards_CombinationId",
                table: "ComboCards",
                column: "CombinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_GameId",
                table: "Rounds",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComboCards");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Combinations");

            migrationBuilder.DropTable(
                name: "Rounds");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
