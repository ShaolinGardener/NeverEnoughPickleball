using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NEP.Migrations
{
    /// <inheritdoc />
    public partial class MailerType3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Mailers_Users_UserId",
            //    table: "Mailers");

            //migrationBuilder.DropColumn(
            //    name: "UserId",
            //    table: "Mailers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<Guid>(
            //    name: "UserId",
            //    table: "Mailers",
            //    type: "uniqueidentifier",
            //    nullable: true);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Mailers_Users_UserId",
            //    table: "Mailers",
            //    column: "UserId",
            //    principalTable: "Users",
            //    principalColumn: "Id");
        }
    }
}
