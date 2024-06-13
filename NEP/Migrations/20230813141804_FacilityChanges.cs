using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NEP.Migrations
{
    /// <inheritdoc />
    public partial class FacilityChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "BeverageOther",
                table: "Facilities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Beverages",
                table: "Facilities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CourtIconImage",
                table: "Facilities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourtImage1",
                table: "Facilities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourtImage2",
                table: "Facilities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourtImage3",
                table: "Facilities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourtImage4",
                table: "Facilities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourtImage5",
                table: "Facilities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DropIns",
                table: "Facilities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "FacilityCourtIconImage",
                table: "Facilities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Fee",
                table: "Facilities",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasProShop",
                table: "Facilities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsFree",
                table: "Facilities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Facilities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockerRooms",
                table: "Facilities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "MembershipDiscountFee",
                table: "Facilities",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MembershipFee",
                table: "Facilities",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Memberships",
                table: "Facilities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "NEPMembershipDiscount",
                table: "Facilities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "NEPPartner",
                table: "Facilities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ProShopId",
                table: "Facilities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Reservations",
                table: "Facilities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RestRooms",
                table: "Facilities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Showers",
                table: "Facilities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Snacks",
                table: "Facilities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "WaterFountain",
                table: "Facilities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "hasCorporateRetreats",
                table: "Facilities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "hasLeaguePlay",
                table: "Facilities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "hasPartyBooking",
                table: "Facilities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "hasSpecialEvents",
                table: "Facilities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "hasTournaments",
                table: "Facilities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Court",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacilityId = table.Column<int>(type: "int", nullable: false),
                    IsIndoor = table.Column<bool>(type: "bit", nullable: false),
                    Surface = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nets = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lines = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Court", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Court_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiningFacilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiningFacilityType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DineIn = table.Column<bool>(type: "bit", nullable: false),
                    Delivery = table.Column<bool>(type: "bit", nullable: false),
                    BeerAndWine = table.Column<bool>(type: "bit", nullable: false),
                    FullLiquor = table.Column<bool>(type: "bit", nullable: false),
                    Reservations = table.Column<bool>(type: "bit", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacilityId = table.Column<int>(type: "int", nullable: false),
                    Menu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image3 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiningFacilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiningFacilities_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProShops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MembershipDiscount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NEPMembershipDiscount = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProShops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HoursOfPlay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeekDay = table.Column<int>(type: "int", nullable: false),
                    Hours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fee = table.Column<double>(type: "float", nullable: false),
                    CourtId = table.Column<int>(type: "int", nullable: false),
                    UsageType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoursOfPlay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoursOfPlay_Court_CourtId",
                        column: x => x.CourtId,
                        principalTable: "Court",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoursOfDeliveries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeekDay = table.Column<int>(type: "int", nullable: false),
                    HoursOfOperation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfficeHours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiningFacilityId = table.Column<int>(type: "int", nullable: false),
                    Fee = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoursOfDeliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoursOfDeliveries_DiningFacilities_DiningFacilityId",
                        column: x => x.DiningFacilityId,
                        principalTable: "DiningFacilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoursOfFood",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeekDay = table.Column<int>(type: "int", nullable: false),
                    HoursOfOperation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfficeHours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiningFacilityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoursOfFood", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoursOfFood_DiningFacilities_DiningFacilityId",
                        column: x => x.DiningFacilityId,
                        principalTable: "DiningFacilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoursOfProShops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeekDay = table.Column<int>(type: "int", nullable: false),
                    HoursOfOperation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfficeHours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProShopId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoursOfProShops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoursOfProShops_ProShops_ProShopId",
                        column: x => x.ProShopId,
                        principalTable: "ProShops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_ProShopId",
                table: "Facilities",
                column: "ProShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Court_FacilityId",
                table: "Court",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_DiningFacilities_FacilityId",
                table: "DiningFacilities",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_HoursOfDeliveries_DiningFacilityId",
                table: "HoursOfDeliveries",
                column: "DiningFacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_HoursOfFood_DiningFacilityId",
                table: "HoursOfFood",
                column: "DiningFacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_HoursOfPlay_CourtId",
                table: "HoursOfPlay",
                column: "CourtId");

            migrationBuilder.CreateIndex(
                name: "IX_HoursOfProShops_ProShopId",
                table: "HoursOfProShops",
                column: "ProShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Facilities_ProShops_ProShopId",
                table: "Facilities",
                column: "ProShopId",
                principalTable: "ProShops",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facilities_ProShops_ProShopId",
                table: "Facilities");

            migrationBuilder.DropTable(
                name: "HoursOfDeliveries");

            migrationBuilder.DropTable(
                name: "HoursOfFood");

            migrationBuilder.DropTable(
                name: "HoursOfPlay");

            migrationBuilder.DropTable(
                name: "HoursOfProShops");

            migrationBuilder.DropTable(
                name: "DiningFacilities");

            migrationBuilder.DropTable(
                name: "Court");

            migrationBuilder.DropTable(
                name: "ProShops");

            migrationBuilder.DropIndex(
                name: "IX_Facilities_ProShopId",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "BeverageOther",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "Beverages",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "CourtIconImage",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "CourtImage1",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "CourtImage2",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "CourtImage3",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "CourtImage4",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "CourtImage5",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "DropIns",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "FacilityCourtIconImage",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "Fee",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "HasProShop",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "IsFree",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "LockerRooms",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "MembershipDiscountFee",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "MembershipFee",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "Memberships",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "NEPMembershipDiscount",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "NEPPartner",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "ProShopId",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "Reservations",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "RestRooms",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "Showers",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "Snacks",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "WaterFountain",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "hasCorporateRetreats",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "hasLeaguePlay",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "hasPartyBooking",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "hasSpecialEvents",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "hasTournaments",
                table: "Facilities");
        }
    }
}
