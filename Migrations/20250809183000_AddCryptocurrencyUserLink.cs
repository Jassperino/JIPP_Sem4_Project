using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JIPP_Projekt_Sem4.Migrations
{
    /// <inheritdoc />
    public partial class AddCryptocurrencyUserLink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Cryptocurrencies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cryptocurrencies_UserId",
                table: "Cryptocurrencies",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cryptocurrencies_Users_UserId",
                table: "Cryptocurrencies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cryptocurrencies_Users_UserId",
                table: "Cryptocurrencies");

            migrationBuilder.DropIndex(
                name: "IX_Cryptocurrencies_UserId",
                table: "Cryptocurrencies");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Cryptocurrencies");
        }
    }
}