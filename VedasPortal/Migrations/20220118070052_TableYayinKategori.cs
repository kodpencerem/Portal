using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class TableYayinKategori : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "YayinKategoriId",
                table: "Yayinlar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "YayinKategorileri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YayinKategoriAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KaydedenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YayinKategorileri", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Yayinlar_YayinKategoriId",
                table: "Yayinlar",
                column: "YayinKategoriId");

            migrationBuilder.AddForeignKey(
                name: "FK_Yayinlar_YayinKategorileri_YayinKategoriId",
                table: "Yayinlar",
                column: "YayinKategoriId",
                principalTable: "YayinKategorileri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Yayinlar_YayinKategorileri_YayinKategoriId",
                table: "Yayinlar");

            migrationBuilder.DropTable(
                name: "YayinKategorileri");

            migrationBuilder.DropIndex(
                name: "IX_Yayinlar_YayinKategoriId",
                table: "Yayinlar");

            migrationBuilder.DropColumn(
                name: "YayinKategoriId",
                table: "Yayinlar");
        }
    }
}
