using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class VideoDosyaClasMdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Yorum_VideoClass_VideoClassId",
                table: "Yorum");

            migrationBuilder.DropTable(
                name: "VideoClass");

            migrationBuilder.AlterColumn<DateTime>(
                name: "KayitTarihi",
                table: "Dosya",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Adi",
                table: "Dosya",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "Dosya",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AltBaslik",
                table: "Dosya",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Birimler",
                table: "Dosya",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IzlenmeDurumu",
                table: "Dosya",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "VideoKategori",
                table: "Dosya",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "VideoUzunluk",
                table: "Dosya",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_Yorum_Dosya_VideoClassId",
                table: "Yorum",
                column: "VideoClassId",
                principalTable: "Dosya",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Yorum_Dosya_VideoClassId",
                table: "Yorum");

            migrationBuilder.DropColumn(
                name: "AltBaslik",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "Birimler",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "IzlenmeDurumu",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "VideoKategori",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "VideoUzunluk",
                table: "Dosya");

            migrationBuilder.AlterColumn<DateTime>(
                name: "KayitTarihi",
                table: "Dosya",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<string>(
                name: "Adi",
                table: "Dosya",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "Dosya",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "VideoClass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aciklama = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AktifPasif = table.Column<bool>(type: "bit", nullable: false),
                    AltBaslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birimler = table.Column<int>(type: "int", nullable: false),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EgitimId = table.Column<int>(type: "int", nullable: true),
                    EtkinlikId = table.Column<int>(type: "int", nullable: true),
                    HaberDuyuruId = table.Column<int>(type: "int", nullable: true),
                    IzlenmeDurumu = table.Column<bool>(type: "bit", nullable: false),
                    Kategori = table.Column<int>(type: "int", nullable: false),
                    KaydedenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    SilenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Uzanti = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uzunluk = table.Column<long>(type: "bigint", nullable: false),
                    Yolu = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
    }
}
