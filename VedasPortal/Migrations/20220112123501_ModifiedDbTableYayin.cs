using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class ModifiedDbTableYayin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Yayinlar_DosyaYuklemeleri_DosyaId",
                table: "Yayinlar");

            migrationBuilder.DropIndex(
                name: "IX_Yayinlar_DosyaId",
                table: "Yayinlar");

            migrationBuilder.DropColumn(
                name: "DosyaId",
                table: "Yayinlar");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DosyaId",
                table: "Yayinlar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Yayinlar_DosyaId",
                table: "Yayinlar",
                column: "DosyaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Yayinlar_DosyaYuklemeleri_DosyaId",
                table: "Yayinlar",
                column: "DosyaId",
                principalTable: "DosyaYuklemeleri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
