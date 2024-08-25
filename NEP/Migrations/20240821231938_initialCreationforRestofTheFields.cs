using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NEP.Migrations
{
    /// <inheritdoc />
    public partial class initialCreationforRestofTheFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AvailableFacilitiesContactEmail",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AvailableFacilitiesName",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HowDidYouHearAboutNEP",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PersonalBio",
                table: "Members",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PlayedCity",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PlayedParkFacility",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PlayedState",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SuggestionsForNEP",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VolunteerInterest",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableFacilitiesContactEmail",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "AvailableFacilitiesName",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "HowDidYouHearAboutNEP",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "PersonalBio",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "PlayedCity",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "PlayedParkFacility",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "PlayedState",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "SuggestionsForNEP",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "VolunteerInterest",
                table: "Members");
        }
    }
}
