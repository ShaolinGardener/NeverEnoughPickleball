using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NEP.Migrations
{
    /// <inheritdoc />
    public partial class AddAvailabilitiesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessHours",
                table: "Coaches");

            migrationBuilder.DropColumn(
                name: "CoachingHoursOption",
                table: "Coaches");

            migrationBuilder.DropColumn(
                name: "FacilitiesContactEmail",
                table: "Coaches");

            migrationBuilder.DropColumn(
                name: "FacilitiesName",
                table: "Coaches");

            migrationBuilder.DropColumn(
                name: "HolidayDate",
                table: "Coaches");

            migrationBuilder.DropColumn(
                name: "HolidayHours",
                table: "Coaches");

            migrationBuilder.DropColumn(
                name: "HolidayName",
                table: "Coaches");

            migrationBuilder.DropColumn(
                name: "Locations",
                table: "Coaches");

            migrationBuilder.DropColumn(
                name: "ScheduledHolidays",
                table: "Coaches");

            migrationBuilder.CreateTable(
                name: "Availabilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoachId = table.Column<int>(type: "int", nullable: false),
                    FacilityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacilityContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MondayHours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TuesdayHours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WednesdayHours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThursdayHours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FridayHours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SaturdayHours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SundayHours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HolidayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HolidayHours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScheduledHolidays = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalNotes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Availabilities", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Availabilities");

            migrationBuilder.AddColumn<string>(
                name: "BusinessHours",
                table: "Coaches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CoachingHoursOption",
                table: "Coaches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FacilitiesContactEmail",
                table: "Coaches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FacilitiesName",
                table: "Coaches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "HolidayDate",
                table: "Coaches",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HolidayHours",
                table: "Coaches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HolidayName",
                table: "Coaches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Locations",
                table: "Coaches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ScheduledHolidays",
                table: "Coaches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
