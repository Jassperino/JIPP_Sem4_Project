using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JIPP_Projekt_Sem4.Migrations
{
    /// <inheritdoc />
    public partial class AddCryptocurrencyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cryptocurrencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bitcoin = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ethereum = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tether = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ZCash = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cryptocurrencies", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cryptocurrencies");
        }
    }
}