using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class UpdateToplantiTable3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Toplanti_ToplantiMerkezi_ToplantiMerkeziId",
                table: "Toplanti");

            migrationBuilder.DropForeignKey(
                name: "FK_ToplantiNotu_ToplantiMerkezi_ToplantiMerkeziId",
                table: "ToplantiNotu");

            migrationBuilder.DropForeignKey(
                name: "FK_ToplantiOdasi_ToplantiMerkezi_ToplantiMerkeziId",
                table: "ToplantiOdasi");

            migrationBuilder.DropTable(
                name: "ToplantiMerkezi");

            migrationBuilder.DropIndex(
                name: "IX_ToplantiOdasi_ToplantiMerkeziId",
                table: "ToplantiOdasi");

            migrationBuilder.DropIndex(
                name: "IX_ToplantiNotu_ToplantiMerkeziId",
                table: "ToplantiNotu");

            migrationBuilder.DropIndex(
                name: "IX_Toplanti_ToplantiMerkeziId",
                table: "Toplanti");

            migrationBuilder.DropColumn(
                name: "ToplantiMerkeziId",
                table: "ToplantiOdasi");

            migrationBuilder.DropColumn(
                name: "ToplantiMerkeziId",
                table: "ToplantiNotu");

            migrationBuilder.DropColumn(
                name: "ToplantiMerkeziId",
                table: "Toplanti");

            migrationBuilder.AddColumn<int>(
                name: "ToplantiMerkezi",
                table: "ToplantiOdasi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ToplantiMerkezi",
                table: "ToplantiNotu",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ToplantiMerkezi",
                table: "Toplanti",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ToplantiMerkezi",
                table: "ToplantiOdasi");

            migrationBuilder.DropColumn(
                name: "ToplantiMerkezi",
                table: "ToplantiNotu");

            migrationBuilder.DropColumn(
                name: "ToplantiMerkezi",
                table: "Toplanti");

            migrationBuilder.AddColumn<int>(
                name: "ToplantiMerkeziId",
                table: "ToplantiOdasi",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ToplantiMerkeziId",
                table: "ToplantiNotu",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ToplantiMerkeziId",
                table: "Toplanti",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ToplantiMerkezi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aciklama = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Adi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AktifPasif = table.Column<bool>(type: "bit", nullable: false),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kapasite = table.Column<int>(type: "int", nullable: false),
                    KaydedenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RezervDurumu = table.Column<bool>(type: "bit", nullable: false),
                    SilenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VideoKonferansMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToplantiMerkezi", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToplantiOdasi_ToplantiMerkeziId",
                table: "ToplantiOdasi",
                column: "ToplantiMerkeziId");

            migrationBuilder.CreateIndex(
                name: "IX_ToplantiNotu_ToplantiMerkeziId",
                table: "ToplantiNotu",
                column: "ToplantiMerkeziId");

            migrationBuilder.CreateIndex(
                name: "IX_Toplanti_ToplantiMerkeziId",
                table: "Toplanti",
                column: "ToplantiMerkeziId");

            migrationBuilder.AddForeignKey(
                name: "FK_Toplanti_ToplantiMerkezi_ToplantiMerkeziId",
                table: "Toplanti",
                column: "ToplantiMerkeziId",
                principalTable: "ToplantiMerkezi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ToplantiNotu_ToplantiMerkezi_ToplantiMerkeziId",
                table: "ToplantiNotu",
                column: "ToplantiMerkeziId",
                principalTable: "ToplantiMerkezi",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ToplantiOdasi_ToplantiMerkezi_ToplantiMerkeziId",
                table: "ToplantiOdasi",
                column: "ToplantiMerkeziId",
                principalTable: "ToplantiMerkezi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
