using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class AddDosyaVeYayin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IzinTalepFormu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rehber",
                table: "Rehber");

            migrationBuilder.RenameTable(
                name: "Rehber",
                newName: "PersonelRehber");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "PersonelRehber",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TelefonNo",
                table: "PersonelRehber",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonelRehber",
                table: "PersonelRehber",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DosyaKategorileri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DosyaKategoriBilgisi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KaydedenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DosyaKategorileri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DosyaYuklemeleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VarsayilanDosyaDegeri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DosyaTipi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DosyaAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DosyaYolu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DosyaKategoriId = table.Column<int>(type: "int", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KaydedenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DosyaYuklemeleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DosyaYuklemeleri_DosyaKategorileri_DosyaKategoriId",
                        column: x => x.DosyaKategoriId,
                        principalTable: "DosyaKategorileri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Yayinlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    No = table.Column<long>(type: "bigint", nullable: false),
                    Adi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    AltBaslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DosyaId = table.Column<int>(type: "int", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KaydedenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yayinlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Yayinlar_DosyaYuklemeleri_DosyaId",
                        column: x => x.DosyaId,
                        principalTable: "DosyaYuklemeleri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DosyaYuklemeleri_DosyaKategoriId",
                table: "DosyaYuklemeleri",
                column: "DosyaKategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Yayinlar_DosyaId",
                table: "Yayinlar",
                column: "DosyaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Yayinlar");

            migrationBuilder.DropTable(
                name: "DosyaYuklemeleri");

            migrationBuilder.DropTable(
                name: "DosyaKategorileri");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonelRehber",
                table: "PersonelRehber");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "PersonelRehber");

            migrationBuilder.DropColumn(
                name: "TelefonNo",
                table: "PersonelRehber");

            migrationBuilder.RenameTable(
                name: "PersonelRehber",
                newName: "Rehber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rehber",
                table: "Rehber",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "IzinTalepFormu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KaydedenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IzinTalepFormu", x => x.Id);
                });
        }
    }
}
