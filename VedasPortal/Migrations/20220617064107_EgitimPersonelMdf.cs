using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class EgitimPersonelMdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonelDurumId",
                table: "Egitim",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Egitim_PersonelDurumId",
                table: "Egitim",
                column: "PersonelDurumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Egitim_PersonelDurum_PersonelDurumId",
                table: "Egitim",
                column: "PersonelDurumId",
                principalTable: "PersonelDurum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Egitim_PersonelDurum_PersonelDurumId",
                table: "Egitim");

            migrationBuilder.DropIndex(
                name: "IX_Egitim_PersonelDurumId",
                table: "Egitim");

            migrationBuilder.DropColumn(
                name: "PersonelDurumId",
                table: "Egitim");
        }
    }
}
