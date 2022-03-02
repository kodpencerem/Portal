using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class ToplantiTakvimiAddModified2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Aciklama",
                table: "ToplantiTakvimi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Adi",
                table: "ToplantiTakvimi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BeklenenKatilimSayisi",
                table: "ToplantiTakvimi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Kod",
                table: "ToplantiTakvimi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ToplantiOdasiId",
                table: "ToplantiTakvimi",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "VideoKonferansMi",
                table: "ToplantiTakvimi",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ToplantiMerkezi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kapasite = table.Column<int>(type: "int", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KaydedenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToplantiMerkezi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToplantiOdasi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kapasite = table.Column<int>(type: "int", nullable: false),
                    VideoKonferansMi = table.Column<bool>(type: "bit", nullable: false),
                    ToplantiMerkeziId = table.Column<int>(type: "int", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KaydedenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToplantiOdasi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToplantiOdasi_ToplantiMerkezi_ToplantiMerkeziId",
                        column: x => x.ToplantiMerkeziId,
                        principalTable: "ToplantiMerkezi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToplantiTakvimi_ToplantiOdasiId",
                table: "ToplantiTakvimi",
                column: "ToplantiOdasiId");

            migrationBuilder.CreateIndex(
                name: "IX_ToplantiOdasi_ToplantiMerkeziId",
                table: "ToplantiOdasi",
                column: "ToplantiMerkeziId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToplantiTakvimi_ToplantiOdasi_ToplantiOdasiId",
                table: "ToplantiTakvimi",
                column: "ToplantiOdasiId",
                principalTable: "ToplantiOdasi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToplantiTakvimi_ToplantiOdasi_ToplantiOdasiId",
                table: "ToplantiTakvimi");

            migrationBuilder.DropTable(
                name: "ToplantiOdasi");

            migrationBuilder.DropTable(
                name: "ToplantiMerkezi");

            migrationBuilder.DropIndex(
                name: "IX_ToplantiTakvimi_ToplantiOdasiId",
                table: "ToplantiTakvimi");

            migrationBuilder.DropColumn(
                name: "Aciklama",
                table: "ToplantiTakvimi");

            migrationBuilder.DropColumn(
                name: "Adi",
                table: "ToplantiTakvimi");

            migrationBuilder.DropColumn(
                name: "BeklenenKatilimSayisi",
                table: "ToplantiTakvimi");

            migrationBuilder.DropColumn(
                name: "Kod",
                table: "ToplantiTakvimi");

            migrationBuilder.DropColumn(
                name: "ToplantiOdasiId",
                table: "ToplantiTakvimi");

            migrationBuilder.DropColumn(
                name: "VideoKonferansMi",
                table: "ToplantiTakvimi");
        }
    }
}
