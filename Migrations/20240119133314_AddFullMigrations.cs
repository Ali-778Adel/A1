using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace A1.Migrations
{
    /// <inheritdoc />
    public partial class AddFullMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "companies",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name_ar = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    name_en = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    slug = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", maxLength: 255, nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "stations",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    name_ar = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    name_en = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    slug = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address_ar = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    address_en = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    lat = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    lng = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    solar = table.Column<bool>(type: "bit", nullable: false),
                    fuel80 = table.Column<bool>(type: "bit", nullable: false),
                    fuel92 = table.Column<bool>(type: "bit", nullable: false),
                    fuel95 = table.Column<bool>(type: "bit", nullable: false),
                    fuel98 = table.Column<bool>(type: "bit", nullable: false),
                    ev_charge = table.Column<bool>(type: "bit", nullable: false),
                    natural_gaz = table.Column<bool>(type: "bit", nullable: false),
                    layout = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    invest_number = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    more_services = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    conditions_ar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    conditions_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    company_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stations", x => x.id);
                    table.ForeignKey(
                        name: "FK_stations_companies_company_id",
                        column: x => x.company_id,
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "units",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    code = table.Column<int>(type: "int", nullable: false),
                    size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    note_ar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    note_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    station_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_units", x => x.id);
                    table.ForeignKey(
                        name: "FK_units_stations_station_id",
                        column: x => x.station_id,
                        principalTable: "stations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_stations_company_id",
                table: "stations",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_units_station_id",
                table: "units",
                column: "station_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "units");

            migrationBuilder.DropTable(
                name: "stations");

            migrationBuilder.DropTable(
                name: "companies");
        }
    }
}
