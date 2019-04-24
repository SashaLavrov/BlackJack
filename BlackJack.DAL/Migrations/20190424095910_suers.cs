using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackJack.DAL.Migrations
{
    public partial class suers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Combinations_AspNetUsers_ApplicationUserId",
                table: "Combinations");

            migrationBuilder.DropIndex(
                name: "IX_Combinations_ApplicationUserId",
                table: "Combinations");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Combinations");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Combinations",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Combinations_UserId",
                table: "Combinations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Combinations_AspNetUsers_UserId",
                table: "Combinations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Combinations_AspNetUsers_UserId",
                table: "Combinations");

            migrationBuilder.DropIndex(
                name: "IX_Combinations_UserId",
                table: "Combinations");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Combinations",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Combinations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Combinations_ApplicationUserId",
                table: "Combinations",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Combinations_AspNetUsers_ApplicationUserId",
                table: "Combinations",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
