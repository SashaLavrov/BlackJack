using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackJack.DAL.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Valye",
                table: "Cards",
                newName: "Value");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Cards",
                newName: "Valye");
        }
    }
}
