using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NEP.Migrations
{
    /// <inheritdoc />
    public partial class UserMailerType2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserMailers",
                table: "UserMailers");

            migrationBuilder.RenameTable(
                name: "UserMailers",
                newName: "UserMailerTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMailerTypes",
                table: "UserMailerTypes",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserMailerTypes",
                table: "UserMailerTypes");

            migrationBuilder.RenameTable(
                name: "UserMailerTypes",
                newName: "UserMailers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMailers",
                table: "UserMailers",
                column: "Id");
        }
    }
}
