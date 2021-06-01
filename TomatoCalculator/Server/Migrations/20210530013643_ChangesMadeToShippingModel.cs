using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TomatoCalculator.Server.Migrations
{
    public partial class ChangesMadeToShippingModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DriverInformations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DriverNumber = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverInformations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RouteInformations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartureLocation = table.Column<int>(type: "int", nullable: false),
                    ArrivalLocation = table.Column<int>(type: "int", nullable: false),
                    ApproximateMileage = table.Column<float>(type: "real", nullable: false),
                    MapImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteInformations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShippingLoads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DriverNumber = table.Column<int>(type: "int", nullable: false),
                    DriverFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TomatoType = table.Column<int>(type: "int", nullable: false),
                    PricePerPound = table.Column<float>(type: "real", nullable: false),
                    ExpectedLosePerMile = table.Column<float>(type: "real", nullable: false),
                    DepartureLocation = table.Column<int>(type: "int", nullable: false),
                    ArrivalLocation = table.Column<int>(type: "int", nullable: false),
                    ApproximateMileage = table.Column<float>(type: "real", nullable: false),
                    DepartureWeight = table.Column<float>(type: "real", nullable: false),
                    UnloadWeight = table.Column<float>(type: "real", nullable: false),
                    ExpectedLossTrip = table.Column<float>(type: "real", nullable: false),
                    ActualLossTrip = table.Column<float>(type: "real", nullable: false),
                    TotalLoadValue = table.Column<float>(type: "real", nullable: false),
                    ExpectedLoadValue = table.Column<float>(type: "real", nullable: false),
                    AdjustedLoadValue = table.Column<float>(type: "real", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UnloadDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingLoads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tomatoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    PricePerPound = table.Column<float>(type: "real", nullable: false),
                    ExpectedWastePerPound = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tomatoes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriverInformations");

            migrationBuilder.DropTable(
                name: "RouteInformations");

            migrationBuilder.DropTable(
                name: "ShippingLoads");

            migrationBuilder.DropTable(
                name: "Tomatoes");
        }
    }
}
