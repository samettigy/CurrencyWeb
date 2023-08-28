using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CurrencyWeb.DAL.Migrations
{
    /// <inheritdoc />
    public partial class test13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoneyRates_Currencies_CurrencyId",
                table: "MoneyRates");

            migrationBuilder.DropIndex(
                name: "IX_MoneyRates_CurrencyId",
                table: "MoneyRates");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MoneyRates_CurrencyId",
                table: "MoneyRates",
                column: "CurrencyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MoneyRates_Currencies_CurrencyId",
                table: "MoneyRates",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
