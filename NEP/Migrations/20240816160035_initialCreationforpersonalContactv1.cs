using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NEP.Migrations
{
    /// <inheritdoc />
    public partial class initialCreationforpersonalContactv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AptSuiteNumber",
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
                name: "Email",
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
                name: "Zip",
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
                name: "City",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "CompanyOrOrganization",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Phone",
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
                name: "Zip",
                table: "Members");
        }
    }
}
