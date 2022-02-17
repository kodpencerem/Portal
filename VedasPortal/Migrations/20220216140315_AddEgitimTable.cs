using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class AddEgitimTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Egitim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KapakId = table.Column<int>(type: "int", nullable: true),
                    VideoId = table.Column<int>(type: "int", nullable: true),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gereksinim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Egitmen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AktifPasif = table.Column<bool>(type: "bit", nullable: false),
                    IzlenmeDurumu = table.Column<bool>(type: "bit", nullable: false),
                    ToplamIzlenme = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TamamlandiMi = table.Column<bool>(type: "bit", nullable: false),
                    Sertifika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Basliklar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToplamUzunluk = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KimlereUygun = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KKategori = table.Column<int>(type: "int", nullable: false),
                    Kategori = table.Column<int>(type: "int", nullable: false),
                    Birimler = table.Column<int>(type: "int", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KaydedenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Egitim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Egitim_Dosya_KapakId",
                        column: x => x.KapakId,
                        principalTable: "Dosya",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Egitim_Video_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Video",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Egitim_KapakId",
                table: "Egitim",
                column: "KapakId");

            migrationBuilder.CreateIndex(
                name: "IX_Egitim_VideoId",
                table: "Egitim",
                column: "VideoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Egitim");
        }
    }
}
