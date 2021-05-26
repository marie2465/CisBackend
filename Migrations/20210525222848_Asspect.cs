using Microsoft.EntityFrameworkCore.Migrations;

namespace Cis_part2.Migrations
{
    public partial class Asspect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SubCriteries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Letter",
                table: "SubCriteries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "TypeAsspect",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeAsspect", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Asspect",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mark = table.Column<double>(type: "float", nullable: false),
                    SectionsId = table.Column<int>(type: "int", nullable: true),
                    TypeAsspectId = table.Column<int>(type: "int", nullable: true),
                    SubCriteriesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asspect", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asspect_Sections_SectionsId",
                        column: x => x.SectionsId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Asspect_SubCriteries_SubCriteriesId",
                        column: x => x.SubCriteriesId,
                        principalTable: "SubCriteries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Asspect_TypeAsspect_TypeAsspectId",
                        column: x => x.TypeAsspectId,
                        principalTable: "TypeAsspect",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asspect_SectionsId",
                table: "Asspect",
                column: "SectionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Asspect_SubCriteriesId",
                table: "Asspect",
                column: "SubCriteriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Asspect_TypeAsspectId",
                table: "Asspect",
                column: "TypeAsspectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asspect");

            migrationBuilder.DropTable(
                name: "TypeAsspect");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SubCriteries",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Letter",
                table: "SubCriteries",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
