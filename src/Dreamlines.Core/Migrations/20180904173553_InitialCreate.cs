using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dreamlines.Web.Migrations
{
    public partial class InitialCreate : Migration
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
                    symbol = table.Column<string>(maxLength: 10, nullable: false),
                    created_on = table.Column<DateTime>(nullable: false)
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
                    currency_id = table.Column<int>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false)
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
                    created_on = table.Column<DateTime>(nullable: false)
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
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
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
                    price = table.Column<int>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false)
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
                columns: new[] { "currency_id", "created_on", "name", "symbol" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 9, 4, 17, 35, 53, 538, DateTimeKind.Utc), "Euro", "€" },
                    { 2, new DateTime(2018, 9, 4, 17, 35, 53, 539, DateTimeKind.Utc), "Brazilian real", "R$" },
                    { 3, new DateTime(2018, 9, 4, 17, 35, 53, 539, DateTimeKind.Utc), "Australian dollar", "AU$" },
                    { 4, new DateTime(2018, 9, 4, 17, 35, 53, 539, DateTimeKind.Utc), "Russian ruble", "RUB" },
                    { 5, new DateTime(2018, 9, 4, 17, 35, 53, 539, DateTimeKind.Utc), "Renminbi", "¥" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_booking_date",
                table: "booking",
                column: "booking_date",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_booking_ship_id",
                table: "booking",
                column: "ship_id");

            migrationBuilder.CreateIndex(
                name: "IX_country_currency_id",
                table: "country",
                column: "currency_id");

            migrationBuilder.CreateIndex(
                name: "ix_country_name",
                table: "country",
                column: "name",
                unique: true);

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
                name: "ix_sales_unit_id",
                table: "ship",
                column: "sales_unit_id",
                unique: true);
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
