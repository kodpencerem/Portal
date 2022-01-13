using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class AddUpdateEtkinlikTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EtkinlikBaslangicTarihi",
                table: "EtkinlikDurumlari",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EtkinlikBitisTarihi",
                table: "EtkinlikDurumlari",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EtkinlikNo",
                table: "EtkinlikDurumlari",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EtkinlikBaslangicTarihi",
                table: "EtkinlikDurumlari");

            migrationBuilder.DropColumn(
                name: "EtkinlikBitisTarihi",
                table: "EtkinlikDurumlari");

            migrationBuilder.DropColumn(
                name: "EtkinlikNo",
                table: "EtkinlikDurumlari");
        }
    }
}
