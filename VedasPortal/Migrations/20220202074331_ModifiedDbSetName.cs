using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class ModifiedDbSetName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_Yayin_HaberDuyuruId",
                table: "Dosya");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Yayin",
                table: "Yayin");

            migrationBuilder.RenameTable(
                name: "Yayin",
                newName: "HaberDuyuru");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HaberDuyuru",
                table: "HaberDuyuru",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_HaberDuyuru_HaberDuyuruId",
                table: "Dosya",
                column: "HaberDuyuruId",
                principalTable: "HaberDuyuru",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_HaberDuyuru_HaberDuyuruId",
                table: "Dosya");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HaberDuyuru",
                table: "HaberDuyuru");

            migrationBuilder.RenameTable(
                name: "HaberDuyuru",
                newName: "Yayin");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Yayin",
                table: "Yayin",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_Yayin_HaberDuyuruId",
                table: "Dosya",
                column: "HaberDuyuruId",
                principalTable: "Yayin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
