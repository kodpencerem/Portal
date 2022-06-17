using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class MevzuatDosyaJoin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MevzuatId",
                table: "Dosya",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dosya_MevzuatId",
                table: "Dosya",
                column: "MevzuatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_Mevzuat_MevzuatId",
                table: "Dosya",
                column: "MevzuatId",
                principalTable: "Mevzuat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_Mevzuat_MevzuatId",
                table: "Dosya");

            migrationBuilder.DropIndex(
                name: "IX_Dosya_MevzuatId",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "MevzuatId",
                table: "Dosya");
        }
    }
}
