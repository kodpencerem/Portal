using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class UpdateDbTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DosyaYolu",
                table: "Yayinlar");

            migrationBuilder.AddColumn<int>(
                name: "DosyaId",
                table: "Yayinlar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DosyaId",
                table: "EtkinlikDurumlari",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "YayinKategoriId",
                table: "EtkinlikDurumlari",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Yayinlar_DosyaId",
                table: "Yayinlar",
                column: "DosyaId");

            migrationBuilder.CreateIndex(
                name: "IX_EtkinlikDurumlari_DosyaId",
                table: "EtkinlikDurumlari",
                column: "DosyaId");

            migrationBuilder.CreateIndex(
                name: "IX_EtkinlikDurumlari_YayinKategoriId",
                table: "EtkinlikDurumlari",
                column: "YayinKategoriId");

            migrationBuilder.AddForeignKey(
                name: "FK_EtkinlikDurumlari_DosyaYuklemeleri_DosyaId",
                table: "EtkinlikDurumlari",
                column: "DosyaId",
                principalTable: "DosyaYuklemeleri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EtkinlikDurumlari_YayinKategorileri_YayinKategoriId",
                table: "EtkinlikDurumlari",
                column: "YayinKategoriId",
                principalTable: "YayinKategorileri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Yayinlar_DosyaYuklemeleri_DosyaId",
                table: "Yayinlar",
                column: "DosyaId",
                principalTable: "DosyaYuklemeleri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EtkinlikDurumlari_DosyaYuklemeleri_DosyaId",
                table: "EtkinlikDurumlari");

            migrationBuilder.DropForeignKey(
                name: "FK_EtkinlikDurumlari_YayinKategorileri_YayinKategoriId",
                table: "EtkinlikDurumlari");

            migrationBuilder.DropForeignKey(
                name: "FK_Yayinlar_DosyaYuklemeleri_DosyaId",
                table: "Yayinlar");

            migrationBuilder.DropIndex(
                name: "IX_Yayinlar_DosyaId",
                table: "Yayinlar");

            migrationBuilder.DropIndex(
                name: "IX_EtkinlikDurumlari_DosyaId",
                table: "EtkinlikDurumlari");

            migrationBuilder.DropIndex(
                name: "IX_EtkinlikDurumlari_YayinKategoriId",
                table: "EtkinlikDurumlari");

            migrationBuilder.DropColumn(
                name: "DosyaId",
                table: "Yayinlar");

            migrationBuilder.DropColumn(
                name: "DosyaId",
                table: "EtkinlikDurumlari");

            migrationBuilder.DropColumn(
                name: "YayinKategoriId",
                table: "EtkinlikDurumlari");

            migrationBuilder.AddColumn<string>(
                name: "DosyaYolu",
                table: "Yayinlar",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
