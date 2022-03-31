using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class ToplantiOdasiMdfd2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MerkezId",
                table: "ToplantiOdasi",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Merkez",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KaydedenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SilenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merkez", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToplantiOdasi_MerkezId",
                table: "ToplantiOdasi",
                column: "MerkezId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToplantiOdasi_Merkez_MerkezId",
                table: "ToplantiOdasi",
                column: "MerkezId",
                principalTable: "Merkez",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToplantiOdasi_Merkez_MerkezId",
                table: "ToplantiOdasi");

            migrationBuilder.DropTable(
                name: "Merkez");

            migrationBuilder.DropIndex(
                name: "IX_ToplantiOdasi_MerkezId",
                table: "ToplantiOdasi");

            migrationBuilder.DropColumn(
                name: "MerkezId",
                table: "ToplantiOdasi");
        }
    }
}
