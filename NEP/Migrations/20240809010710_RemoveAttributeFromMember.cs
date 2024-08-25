using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NEP.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAttributeFromMember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePic",
                table: "Members");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfilePic",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
