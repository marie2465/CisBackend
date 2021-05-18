using Microsoft.EntityFrameworkCore.Migrations;

namespace Cis_part2.Migrations
{
    public partial class SectionRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SkillsId",
                table: "Sections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sections_SkillsId",
                table: "Sections",
                column: "SkillsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Skills_SkillsId",
                table: "Sections",
                column: "SkillsId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Skills_SkillsId",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Sections_SkillsId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "SkillsId",
                table: "Sections");
        }
    }
}
