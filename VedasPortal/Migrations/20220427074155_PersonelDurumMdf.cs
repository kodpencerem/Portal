using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class PersonelDurumMdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AktifEdilsinMi",
                table: "PersonelDurum");

            migrationBuilder.DropColumn(
                name: "VefatTarihi",
                table: "PersonelDurum");

            migrationBuilder.DropColumn(
                name: "YakinlikDerecesi",
                table: "PersonelDurum");

            migrationBuilder.AddColumn<bool>(
                name: "AktifPasif",
                table: "PersonelDurum",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AnasayfadaGoster",
                table: "PersonelDurum",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AktifPasif",
                table: "PersonelDurum");

            migrationBuilder.DropColumn(
                name: "AnasayfadaGoster",
                table: "PersonelDurum");

            migrationBuilder.AddColumn<bool>(
                name: "AktifEdilsinMi",
                table: "PersonelDurum",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VefatTarihi",
                table: "PersonelDurum",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YakinlikDerecesi",
                table: "PersonelDurum",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
