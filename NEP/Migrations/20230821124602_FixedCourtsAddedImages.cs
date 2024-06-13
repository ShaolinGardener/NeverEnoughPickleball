using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NEP.Migrations
{
    /// <inheritdoc />
    public partial class FixedCourtsAddedImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Court_Facilities_FacilityId",
                table: "Court");

            migrationBuilder.DropForeignKey(
                name: "FK_CourtColors_Court_CourtId",
                table: "CourtColors");

            migrationBuilder.DropForeignKey(
                name: "FK_HoursOfPlay_Court_CourtId",
                table: "HoursOfPlay");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Court",
                table: "Court");

            migrationBuilder.RenameTable(
                name: "Court",
                newName: "Courts");

            migrationBuilder.RenameIndex(
                name: "IX_Court_FacilityId",
                table: "Courts",
                newName: "IX_Courts_FacilityId");

            migrationBuilder.AlterColumn<int>(
                name: "FacilityCourtIconImage",
                table: "Facilities",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourtImage5",
                table: "Facilities",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourtImage4",
                table: "Facilities",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourtImage3",
                table: "Facilities",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourtImage2",
                table: "Facilities",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourtImage1",
                table: "Facilities",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourtIconImage",
                table: "Facilities",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courts",
                table: "Courts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CourtColors_Courts_CourtId",
                table: "CourtColors",
                column: "CourtId",
                principalTable: "Courts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courts_Facilities_FacilityId",
                table: "Courts",
                column: "FacilityId",
                principalTable: "Facilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HoursOfPlay_Courts_CourtId",
                table: "HoursOfPlay",
                column: "CourtId",
                principalTable: "Courts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourtColors_Courts_CourtId",
                table: "CourtColors");

            migrationBuilder.DropForeignKey(
                name: "FK_Courts_Facilities_FacilityId",
                table: "Courts");

            migrationBuilder.DropForeignKey(
                name: "FK_HoursOfPlay_Courts_CourtId",
                table: "HoursOfPlay");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courts",
                table: "Courts");

            migrationBuilder.RenameTable(
                name: "Courts",
                newName: "Court");

            migrationBuilder.RenameIndex(
                name: "IX_Courts_FacilityId",
                table: "Court",
                newName: "IX_Court_FacilityId");

            migrationBuilder.AlterColumn<string>(
                name: "FacilityCourtIconImage",
                table: "Facilities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CourtImage5",
                table: "Facilities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CourtImage4",
                table: "Facilities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CourtImage3",
                table: "Facilities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CourtImage2",
                table: "Facilities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CourtImage1",
                table: "Facilities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CourtIconImage",
                table: "Facilities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Court",
                table: "Court",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Court_Facilities_FacilityId",
                table: "Court",
                column: "FacilityId",
                principalTable: "Facilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourtColors_Court_CourtId",
                table: "CourtColors",
                column: "CourtId",
                principalTable: "Court",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HoursOfPlay_Court_CourtId",
                table: "HoursOfPlay",
                column: "CourtId",
                principalTable: "Court",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
