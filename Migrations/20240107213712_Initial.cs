using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace A1.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "companies",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name_ar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    slug = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    name_ar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address_ar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    solar = table.Column<bool>(type: "bit", nullable: false),
                    fuel80 = table.Column<bool>(type: "bit", nullable: false),
                    fuel92 = table.Column<bool>(type: "bit", nullable: false),
                    fuel95 = table.Column<bool>(type: "bit", nullable: false),
                    fuel98 = table.Column<bool>(type: "bit", nullable: false),
                    ev_charge = table.Column<bool>(type: "bit", nullable: false),
                    natural_gaz = table.Column<bool>(type: "bit", nullable: false),
                    layout = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    invest_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    company_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    more_services = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    conditions_ar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    conditions_en = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_stations_company_id",
                table: "stations",
                column: "company_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "stations");

            migrationBuilder.DropTable(
                name: "companies");
        }
    }
}
