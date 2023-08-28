using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CurrencyWeb.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CreateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoneyRates_Currencies_currencyId",
                table: "MoneyRates");

            migrationBuilder.RenameColumn(
                name: "sell",
                table: "MoneyRates",
                newName: "Sell");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "MoneyRates",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "currencyId",
                table: "MoneyRates",
                newName: "CurrencyId");

            migrationBuilder.RenameColumn(
                name: "buy",
                table: "MoneyRates",
                newName: "Buy");

            migrationBuilder.RenameIndex(
                name: "IX_MoneyRates_currencyId",
                table: "MoneyRates",
                newName: "IX_MoneyRates_CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_MoneyRates_Currencies_CurrencyId",
                table: "MoneyRates",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoneyRates_Currencies_CurrencyId",
                table: "MoneyRates");

            migrationBuilder.RenameColumn(
                name: "Sell",
                table: "MoneyRates",
                newName: "sell");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "MoneyRates",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "CurrencyId",
                table: "MoneyRates",
                newName: "currencyId");

            migrationBuilder.RenameColumn(
                name: "Buy",
                table: "MoneyRates",
                newName: "buy");

            migrationBuilder.RenameIndex(
                name: "IX_MoneyRates_CurrencyId",
                table: "MoneyRates",
                newName: "IX_MoneyRates_currencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_MoneyRates_Currencies_currencyId",
                table: "MoneyRates",
                column: "currencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
