using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class ModifiedDbTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "No",
                table: "Yayinlar",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<string>(
                name: "DosyaYolu",
                table: "Yayinlar",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DosyaYolu",
                table: "Yayinlar");

            migrationBuilder.DropColumn(
                name: "DuyurudaOlsunMu",
                table: "DosyaYuklemeleri");

            migrationBuilder.DropColumn(
                name: "HaberdeOlsunMu",
                table: "DosyaYuklemeleri");

            migrationBuilder.AlterColumn<long>(
                name: "No",
                table: "Yayinlar",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
