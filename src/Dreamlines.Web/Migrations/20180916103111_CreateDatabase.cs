using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dreamlines.Web.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "currency",
                columns: table => new
                {
                    currency_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 50, nullable: false),
                    symbol = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_currency", x => x.currency_id);
                });

            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    country_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    currency_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_country", x => x.country_id);
                    table.ForeignKey(
                        name: "FK_country_currency_currency_id",
                        column: x => x.currency_id,
                        principalTable: "currency",
                        principalColumn: "currency_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sales_unit",
                columns: table => new
                {
                    sales_unit_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    country_id = table.Column<int>(nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sales_unit", x => x.sales_unit_id);
                    table.ForeignKey(
                        name: "FK_sales_unit_country_country_id",
                        column: x => x.country_id,
                        principalTable: "country",
                        principalColumn: "country_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ship",
                columns: table => new
                {
                    ship_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    sales_unit_id = table.Column<int>(nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ship", x => x.ship_id);
                    table.ForeignKey(
                        name: "FK_ship_sales_unit_sales_unit_id",
                        column: x => x.sales_unit_id,
                        principalTable: "sales_unit",
                        principalColumn: "sales_unit_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "booking",
                columns: table => new
                {
                    booking_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ship_id = table.Column<int>(nullable: false),
                    booking_date = table.Column<DateTime>(nullable: false),
                    price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_booking", x => x.booking_id);
                    table.ForeignKey(
                        name: "FK_booking_ship_ship_id",
                        column: x => x.ship_id,
                        principalTable: "ship",
                        principalColumn: "ship_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "currency",
                columns: new[] { "currency_id", "name", "symbol" },
                values: new object[,]
                {
                    { 1, "Euro", "€" },
                    { 2, "Brazilian real", "R$" },
                    { 3, "Australian dollar", "AU$" },
                    { 4, "Russian ruble", "RUB" },
                    { 5, "Renminbi", "¥" }
                });

            migrationBuilder.InsertData(
                table: "country",
                columns: new[] { "country_id", "currency_id", "name" },
                values: new object[,]
                {
                    { 1, 1, "Germany" },
                    { 3, 1, "Italy" },
                    { 4, 1, "France" },
                    { 7, 1, "Netherlands" },
                    { 2, 2, "Brazil" },
                    { 5, 3, "Australia" },
                    { 6, 4, "Russia" },
                    { 8, 5, "China" }
                });

            migrationBuilder.InsertData(
                table: "sales_unit",
                columns: new[] { "sales_unit_id", "country_id", "name" },
                values: new object[,]
                {
                    { 1, 1, "dreamlines.de" },
                    { 3, 3, "dreamlines.it" },
                    { 4, 4, "dreamlines.fr" },
                    { 7, 7, "dreamlines.nl" },
                    { 2, 2, "dreamlines.com.br" },
                    { 5, 5, "dreamlines.com.au" },
                    { 6, 6, "dreamlines.ru" },
                    { 8, 8, "soyoulun.com" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_booking_date",
                table: "booking",
                column: "booking_date");

            migrationBuilder.CreateIndex(
                name: "IX_booking_ship_id",
                table: "booking",
                column: "ship_id");

            migrationBuilder.CreateIndex(
                name: "IX_country_currency_id",
                table: "country",
                column: "currency_id");

            migrationBuilder.CreateIndex(
                name: "ix_currency_name",
                table: "currency",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sales_unit_country_id",
                table: "sales_unit",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "ix_sales_unit_name",
                table: "sales_unit",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_sales_unit_id",
                table: "ship",
                column: "sales_unit_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "booking");

            migrationBuilder.DropTable(
                name: "ship");

            migrationBuilder.DropTable(
                name: "sales_unit");

            migrationBuilder.DropTable(
                name: "country");

            migrationBuilder.DropTable(
                name: "currency");
        }
    }
}
