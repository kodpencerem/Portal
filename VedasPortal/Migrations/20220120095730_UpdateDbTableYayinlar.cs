using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class UpdateDbTableYayinlar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DuyurudaOlsunMu",
                table: "DosyaYuklemeleri");

            migrationBuilder.DropColumn(
                name: "HaberdeOlsunMu",
                table: "DosyaYuklemeleri");

            migrationBuilder.AddColumn<bool>(
                name: "DuyuruKutusundaOlsunMu",
                table: "Yayinlar",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SlideraEklensinMi",
                table: "Yayinlar",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DuyuruKutusundaOlsunMu",
                table: "Yayinlar");

            migrationBuilder.DropColumn(
                name: "SlideraEklensinMi",
                table: "Yayinlar");

            migrationBuilder.AddColumn<bool>(
                name: "DuyurudaOlsunMu",
                table: "DosyaYuklemeleri",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HaberdeOlsunMu",
                table: "DosyaYuklemeleri",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
