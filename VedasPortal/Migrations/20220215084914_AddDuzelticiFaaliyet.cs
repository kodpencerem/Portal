using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class AddDuzelticiFaaliyet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DuzelticiFaaliyet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaaliyetGurupAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IstekFaaliyetKonusu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    BildirimTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResimId = table.Column<int>(type: "int", nullable: true),
                    KonuEtiketi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LokasyonBilgisi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KaydedenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuzelticiFaaliyet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuzelticiFaaliyet_Dosya_ResimId",
                        column: x => x.ResimId,
                        principalTable: "Dosya",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DuzelticiFaaliyet_ResimId",
                table: "DuzelticiFaaliyet",
                column: "ResimId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DuzelticiFaaliyet");
        }
    }
}
