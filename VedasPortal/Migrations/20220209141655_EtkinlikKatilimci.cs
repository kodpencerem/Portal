using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class EtkinlikKatilimci : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_HaberDuyuru_HaberDuyuruId",
                table: "Dosya");

            migrationBuilder.DropIndex(
                name: "IX_Dosya_HaberDuyuruId",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "HaberDuyuruId",
                table: "Dosya");

            migrationBuilder.AddColumn<int>(
                name: "KatilimciId",
                table: "Etkinlik",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DosyaHaberDuyuru",
                columns: table => new
                {
                    DosyaId = table.Column<int>(type: "int", nullable: false),
                    HaberDuyuruId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DosyaHaberDuyuru", x => new { x.DosyaId, x.HaberDuyuruId });
                    table.ForeignKey(
                        name: "FK_DosyaHaberDuyuru_Dosya_DosyaId",
                        column: x => x.DosyaId,
                        principalTable: "Dosya",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DosyaHaberDuyuru_HaberDuyuru_HaberDuyuruId",
                        column: x => x.HaberDuyuruId,
                        principalTable: "HaberDuyuru",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Katilimci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KatilisDurumu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KatilisNedeni = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KaydedenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Katilimci", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Etkinlik_KatilimciId",
                table: "Etkinlik",
                column: "KatilimciId");

            migrationBuilder.CreateIndex(
                name: "IX_DosyaHaberDuyuru_HaberDuyuruId",
                table: "DosyaHaberDuyuru",
                column: "HaberDuyuruId");

            migrationBuilder.AddForeignKey(
                name: "FK_Etkinlik_Katilimci_KatilimciId",
                table: "Etkinlik",
                column: "KatilimciId",
                principalTable: "Katilimci",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Etkinlik_Katilimci_KatilimciId",
                table: "Etkinlik");

            migrationBuilder.DropTable(
                name: "DosyaHaberDuyuru");

            migrationBuilder.DropTable(
                name: "Katilimci");

            migrationBuilder.DropIndex(
                name: "IX_Etkinlik_KatilimciId",
                table: "Etkinlik");

            migrationBuilder.DropColumn(
                name: "KatilimciId",
                table: "Etkinlik");

            migrationBuilder.AddColumn<int>(
                name: "HaberDuyuruId",
                table: "Dosya",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dosya_HaberDuyuruId",
                table: "Dosya",
                column: "HaberDuyuruId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_HaberDuyuru_HaberDuyuruId",
                table: "Dosya",
                column: "HaberDuyuruId",
                principalTable: "HaberDuyuru",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
