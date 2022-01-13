using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class AddEtkinlikTableUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "No",
                table: "EtkinlikDurumlari");

            migrationBuilder.AddColumn<string>(
                name: "EtkinlikAciklama",
                table: "EtkinlikDurumlari",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EtkinlikAciklama",
                table: "EtkinlikDurumlari");

            migrationBuilder.AddColumn<Guid>(
                name: "No",
                table: "EtkinlikDurumlari",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
