using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NEP.Migrations
{
    /// <inheritdoc />
    public partial class becomememberinitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Members",
                newName: "Zip");

            migrationBuilder.RenameColumn(
                name: "Relationship",
                table: "Members",
                newName: "VolunteerInterest");

            migrationBuilder.RenameColumn(
                name: "ParentGuardian",
                table: "Members",
                newName: "UtprRating");

            migrationBuilder.RenameColumn(
                name: "OccupationDetails",
                table: "Members",
                newName: "UnofficialRating");

            migrationBuilder.RenameColumn(
                name: "Occupation",
                table: "Members",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "Languages",
                table: "Members",
                newName: "ScreenName");

            migrationBuilder.RenameColumn(
                name: "HearAboutUs",
                table: "Members",
                newName: "ProfilePic");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Members",
                newName: "PlayedState");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Members",
                newName: "PlayedParkFacility");

            migrationBuilder.AddColumn<string>(
                name: "AptSuiteNumber",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AvailableFacilityContactEmail",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AvailableFacilityName",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompanyOrOrganization",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DuprRating",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HearAboutNEP",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InfoInterest",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NEPSuggestions",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PaddleUsed",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PersonalBio",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PlayType",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PlayedCity",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AptSuiteNumber",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "AvailableFacilityContactEmail",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "AvailableFacilityName",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "CompanyOrOrganization",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "DuprRating",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "HearAboutNEP",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "InfoInterest",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "NEPSuggestions",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "PaddleUsed",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "PersonalBio",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "PlayType",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "PlayedCity",
                table: "Members");

            migrationBuilder.RenameColumn(
                name: "Zip",
                table: "Members",
                newName: "ZipCode");

            migrationBuilder.RenameColumn(
                name: "VolunteerInterest",
                table: "Members",
                newName: "Relationship");

            migrationBuilder.RenameColumn(
                name: "UtprRating",
                table: "Members",
                newName: "ParentGuardian");

            migrationBuilder.RenameColumn(
                name: "UnofficialRating",
                table: "Members",
                newName: "OccupationDetails");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Members",
                newName: "Occupation");

            migrationBuilder.RenameColumn(
                name: "ScreenName",
                table: "Members",
                newName: "Languages");

            migrationBuilder.RenameColumn(
                name: "ProfilePic",
                table: "Members",
                newName: "HearAboutUs");

            migrationBuilder.RenameColumn(
                name: "PlayedState",
                table: "Members",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "PlayedParkFacility",
                table: "Members",
                newName: "Address");
        }
    }
}
