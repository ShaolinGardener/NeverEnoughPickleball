using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NEP.Migrations
{
    /// <inheritdoc />
    public partial class initialCreationforTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "City",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "CompanyOrOrganization",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "DuprRating",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Email",
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
                name: "Phone",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "PlayType",
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
                name: "ScreenName",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "UnofficialRating",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "UtprRating",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "VolunteerInterest",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Zip",
                table: "Members");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "City",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Members",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DuprRating",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
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
                name: "Phone",
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
                name: "ScreenName",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UnofficialRating",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UtprRating",
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

            migrationBuilder.AddColumn<string>(
                name: "Zip",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
