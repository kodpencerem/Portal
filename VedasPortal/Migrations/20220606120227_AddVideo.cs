using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class AddVideo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoUzunluk",
                table: "Dosya");

            migrationBuilder.AddColumn<int>(
                name: "VidyoId",
                table: "Yorum",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Vidyo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AltBaslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yolu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uzanti = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoUzunluk = table.Column<long>(type: "bigint", nullable: false),
                    Boyutu = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Kategori = table.Column<int>(type: "int", nullable: true),
                    AktifPasif = table.Column<bool>(type: "bit", nullable: false),
                    IzlenmeDurumu = table.Column<bool>(type: "bit", nullable: false),
                    VideoKategori = table.Column<int>(type: "int", nullable: true),
                    Birimler = table.Column<int>(type: "int", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KaydedenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SilenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vidyo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Yorum_VidyoId",
                table: "Yorum",
                column: "VidyoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Yorum_Vidyo_VidyoId",
                table: "Yorum",
                column: "VidyoId",
                principalTable: "Vidyo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Yorum_Vidyo_VidyoId",
                table: "Yorum");

            migrationBuilder.DropTable(
                name: "Vidyo");

            migrationBuilder.DropIndex(
                name: "IX_Yorum_VidyoId",
                table: "Yorum");

            migrationBuilder.DropColumn(
                name: "VidyoId",
                table: "Yorum");

            migrationBuilder.AddColumn<long>(
                name: "VideoUzunluk",
                table: "Dosya",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
