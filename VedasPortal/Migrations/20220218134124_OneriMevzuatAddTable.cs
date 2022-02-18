using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class OneriMevzuatAddTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IzlenmeDurumu",
                table: "Egitim");

            migrationBuilder.AddColumn<string>(
                name: "Aciklama",
                table: "Video",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AktifPasif",
                table: "Video",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "AltBaslik",
                table: "Video",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Birimler",
                table: "Video",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IzlenmeDurumu",
                table: "Video",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Kategori",
                table: "Video",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Uzunluk",
                table: "Video",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ProfilResmiId",
                table: "Rehber",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Unvani",
                table: "Rehber",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Oneri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OneriDosyaId = table.Column<int>(type: "int", nullable: true),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AktifPasif = table.Column<bool>(type: "bit", nullable: false),
                    KabulDurum = table.Column<bool>(type: "bit", nullable: false),
                    RedNedeni = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YapanAdiSoyadı = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EPosta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Derece = table.Column<int>(type: "int", nullable: false),
                    Odul = table.Column<int>(type: "int", nullable: false),
                    Kategori = table.Column<int>(type: "int", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KaydedenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oneri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oneri_Dosya_OneriDosyaId",
                        column: x => x.OneriDosyaId,
                        principalTable: "Dosya",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rehber_ProfilResmiId",
                table: "Rehber",
                column: "ProfilResmiId");

            migrationBuilder.CreateIndex(
                name: "IX_Oneri_OneriDosyaId",
                table: "Oneri",
                column: "OneriDosyaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rehber_Dosya_ProfilResmiId",
                table: "Rehber",
                column: "ProfilResmiId",
                principalTable: "Dosya",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rehber_Dosya_ProfilResmiId",
                table: "Rehber");

            migrationBuilder.DropTable(
                name: "Oneri");

            migrationBuilder.DropIndex(
                name: "IX_Rehber_ProfilResmiId",
                table: "Rehber");

            migrationBuilder.DropColumn(
                name: "Aciklama",
                table: "Video");

            migrationBuilder.DropColumn(
                name: "AktifPasif",
                table: "Video");

            migrationBuilder.DropColumn(
                name: "AltBaslik",
                table: "Video");

            migrationBuilder.DropColumn(
                name: "Birimler",
                table: "Video");

            migrationBuilder.DropColumn(
                name: "IzlenmeDurumu",
                table: "Video");

            migrationBuilder.DropColumn(
                name: "Kategori",
                table: "Video");

            migrationBuilder.DropColumn(
                name: "Uzunluk",
                table: "Video");

            migrationBuilder.DropColumn(
                name: "ProfilResmiId",
                table: "Rehber");

            migrationBuilder.DropColumn(
                name: "Unvani",
                table: "Rehber");

            migrationBuilder.AddColumn<bool>(
                name: "IzlenmeDurumu",
                table: "Egitim",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
