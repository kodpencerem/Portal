using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class DbModfied18052022 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_Videolar_VideoId",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Yorum_Videolar_VideoId",
                table: "Yorum");

            migrationBuilder.DropTable(
                name: "Videolar");

            migrationBuilder.DropIndex(
                name: "IX_Dosya_VideoId",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "VideoId",
                table: "Dosya");

            migrationBuilder.RenameColumn(
                name: "VideoId",
                table: "Yorum",
                newName: "VideoClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Yorum_VideoId",
                table: "Yorum",
                newName: "IX_Yorum_VideoClassId");

            migrationBuilder.CreateTable(
                name: "VideoClass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yolu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uzanti = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AltBaslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uzunluk = table.Column<long>(type: "bigint", nullable: false),
                    AktifPasif = table.Column<bool>(type: "bit", nullable: false),
                    IzlenmeDurumu = table.Column<bool>(type: "bit", nullable: false),
                    Kategori = table.Column<int>(type: "int", nullable: false),
                    Birimler = table.Column<int>(type: "int", nullable: false),
                    HaberDuyuruId = table.Column<int>(type: "int", nullable: true),
                    EtkinlikId = table.Column<int>(type: "int", nullable: true),
                    EgitimId = table.Column<int>(type: "int", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KaydedenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SilenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoClass", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideoClass_Egitim_EgitimId",
                        column: x => x.EgitimId,
                        principalTable: "Egitim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VideoClass_Etkinlik_EtkinlikId",
                        column: x => x.EtkinlikId,
                        principalTable: "Etkinlik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VideoClass_HaberDuyuru_HaberDuyuruId",
                        column: x => x.HaberDuyuruId,
                        principalTable: "HaberDuyuru",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VideoClass_EgitimId",
                table: "VideoClass",
                column: "EgitimId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoClass_EtkinlikId",
                table: "VideoClass",
                column: "EtkinlikId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoClass_HaberDuyuruId",
                table: "VideoClass",
                column: "HaberDuyuruId");

            migrationBuilder.AddForeignKey(
                name: "FK_Yorum_VideoClass_VideoClassId",
                table: "Yorum",
                column: "VideoClassId",
                principalTable: "VideoClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Yorum_VideoClass_VideoClassId",
                table: "Yorum");

            migrationBuilder.DropTable(
                name: "VideoClass");

            migrationBuilder.RenameColumn(
                name: "VideoClassId",
                table: "Yorum",
                newName: "VideoId");

            migrationBuilder.RenameIndex(
                name: "IX_Yorum_VideoClassId",
                table: "Yorum",
                newName: "IX_Yorum_VideoId");

            migrationBuilder.AddColumn<int>(
                name: "VideoId",
                table: "Dosya",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Videolar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AktifPasif = table.Column<bool>(type: "bit", nullable: false),
                    AltBaslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birimler = table.Column<int>(type: "int", nullable: false),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EgitimId = table.Column<int>(type: "int", nullable: true),
                    EtkinlikId = table.Column<int>(type: "int", nullable: true),
                    HaberDuyuruId = table.Column<int>(type: "int", nullable: true),
                    IzlenmeDurumu = table.Column<bool>(type: "bit", nullable: false),
                    Kategori = table.Column<int>(type: "int", nullable: false),
                    KaydedenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SilenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Uzunluk = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videolar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Videolar_Egitim_EgitimId",
                        column: x => x.EgitimId,
                        principalTable: "Egitim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Videolar_Etkinlik_EtkinlikId",
                        column: x => x.EtkinlikId,
                        principalTable: "Etkinlik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Videolar_HaberDuyuru_HaberDuyuruId",
                        column: x => x.HaberDuyuruId,
                        principalTable: "HaberDuyuru",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dosya_VideoId",
                table: "Dosya",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_Videolar_EgitimId",
                table: "Videolar",
                column: "EgitimId");

            migrationBuilder.CreateIndex(
                name: "IX_Videolar_EtkinlikId",
                table: "Videolar",
                column: "EtkinlikId");

            migrationBuilder.CreateIndex(
                name: "IX_Videolar_HaberDuyuruId",
                table: "Videolar",
                column: "HaberDuyuruId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_Videolar_VideoId",
                table: "Dosya",
                column: "VideoId",
                principalTable: "Videolar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Yorum_Videolar_VideoId",
                table: "Yorum",
                column: "VideoId",
                principalTable: "Videolar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
