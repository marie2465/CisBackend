using Microsoft.EntityFrameworkCore.Migrations;

namespace Cis_part2.Migrations
{
    public partial class Subcritery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubCriteries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Letter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mark = table.Column<double>(type: "float", nullable: false),
                    CriteriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCriteries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCriteries_Criteries_CriteriesId",
                        column: x => x.CriteriesId,
                        principalTable: "Criteries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubCriteries_CriteriesId",
                table: "SubCriteries",
                column: "CriteriesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubCriteries");
        }
    }
}
