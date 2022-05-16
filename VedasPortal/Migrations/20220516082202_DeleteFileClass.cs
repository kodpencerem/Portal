using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class DeleteFileClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileClass");

            migrationBuilder.AddColumn<int>(
                name: "MevzuatId",
                table: "Mevzuat",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mevzuat_MevzuatId",
                table: "Mevzuat",
                column: "MevzuatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mevzuat_Mevzuat_MevzuatId",
                table: "Mevzuat",
                column: "MevzuatId",
                principalTable: "Mevzuat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mevzuat_Mevzuat_MevzuatId",
                table: "Mevzuat");

            migrationBuilder.DropIndex(
                name: "IX_Mevzuat_MevzuatId",
                table: "Mevzuat");

            migrationBuilder.DropColumn(
                name: "MevzuatId",
                table: "Mevzuat");

            migrationBuilder.CreateTable(
                name: "FileClass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileClassId = table.Column<int>(type: "int", nullable: true),
                    FileId = table.Column<int>(type: "int", nullable: false),
                    KaydedenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SilenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileClass", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileClass_FileClass_FileClassId",
                        column: x => x.FileClassId,
                        principalTable: "FileClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileClass_FileClassId",
                table: "FileClass",
                column: "FileClassId");
        }
    }
}
