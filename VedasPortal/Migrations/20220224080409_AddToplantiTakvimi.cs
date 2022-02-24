using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class AddToplantiTakvimi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToplantiTakvimi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaslamaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BitisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Konu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Renk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AktifPasif = table.Column<bool>(type: "bit", nullable: false),
                    AnaSayfadaGoster = table.Column<bool>(type: "bit", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KaydedenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToplantiTakvimi", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToplantiTakvimi");
        }
    }
}
