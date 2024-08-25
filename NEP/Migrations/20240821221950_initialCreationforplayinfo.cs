using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NEP.Migrations
{
    /// <inheritdoc />
    public partial class initialCreationforplayinfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DuprRating",
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
                name: "PlayType",
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DuprRating",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "PaddleUsed",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "PlayType",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "UnofficialRating",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "UtprRating",
                table: "Members");
        }
    }
}
