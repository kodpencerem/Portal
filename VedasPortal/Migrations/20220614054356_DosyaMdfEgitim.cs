using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class DosyaMdfEgitim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DosyaId",
                table: "Dosya",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EgitimId",
                table: "Dosya",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FileId",
                table: "Dosya",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Dosya_DosyaId",
                table: "Dosya",
                column: "DosyaId");

            migrationBuilder.CreateIndex(
                name: "IX_Dosya_EgitimId",
                table: "Dosya",
                column: "EgitimId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_Dosya_DosyaId",
                table: "Dosya",
                column: "DosyaId",
                principalTable: "Dosya",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_Egitim_EgitimId",
                table: "Dosya",
                column: "EgitimId",
                principalTable: "Egitim",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_Dosya_DosyaId",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_Egitim_EgitimId",
                table: "Dosya");

            migrationBuilder.DropIndex(
                name: "IX_Dosya_DosyaId",
                table: "Dosya");

            migrationBuilder.DropIndex(
                name: "IX_Dosya_EgitimId",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "DosyaId",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "EgitimId",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "Dosya");
        }
    }
}
