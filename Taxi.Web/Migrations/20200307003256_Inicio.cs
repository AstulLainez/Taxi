using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Taxi.Web.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaxiEntities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Plaque = table.Column<string>(maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxiEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TripEntities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    Source = table.Column<string>(maxLength: 500, nullable: true),
                    Target = table.Column<string>(maxLength: 500, nullable: true),
                    Qualification = table.Column<float>(nullable: false),
                    SourceLatitude = table.Column<double>(nullable: false),
                    SourceLongitude = table.Column<double>(nullable: false),
                    TargetLatitude = table.Column<double>(nullable: false),
                    TargetLongitude = table.Column<double>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    TaxiId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripEntities_TaxiEntities_TaxiId",
                        column: x => x.TaxiId,
                        principalTable: "TaxiEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TripDetailEntities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    TripId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripDetailEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripDetailEntities_TripEntities_TripId",
                        column: x => x.TripId,
                        principalTable: "TripEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TripDetailEntities_TripId",
                table: "TripDetailEntities",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_TripEntities_TaxiId",
                table: "TripEntities",
                column: "TaxiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TripDetailEntities");

            migrationBuilder.DropTable(
                name: "TripEntities");

            migrationBuilder.DropTable(
                name: "TaxiEntities");
        }
    }
}
