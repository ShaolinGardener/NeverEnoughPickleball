using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NEP.Migrations
{
    /// <inheritdoc />
    public partial class FacilityDTOItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CarCharge",
                table: "Facilities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Lights",
                table: "Facilities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Parking",
                table: "Facilities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Picnic",
                table: "Facilities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Playground",
                table: "Facilities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CourtColors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourtId = table.Column<int>(type: "int", nullable: false),
                    OBColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourtColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KitchenColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LineColor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourtColors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourtColors_Court_CourtId",
                        column: x => x.CourtId,
                        principalTable: "Court",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourtColors_CourtId",
                table: "CourtColors",
                column: "CourtId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourtColors");

            migrationBuilder.DropColumn(
                name: "CarCharge",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "Lights",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "Parking",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "Picnic",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "Playground",
                table: "Facilities");
        }
    }
}
