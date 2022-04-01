using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class AddOneriUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_Oneri_OneriId",
                table: "Dosya");

            migrationBuilder.DropIndex(
                name: "IX_Dosya_OneriId",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "OneriId",
                table: "Dosya");

            migrationBuilder.AddColumn<int>(
                name: "DosyaId",
                table: "Oneri",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Oneri_DosyaId",
                table: "Oneri",
                column: "DosyaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Oneri_Dosya_DosyaId",
                table: "Oneri",
                column: "DosyaId",
                principalTable: "Dosya",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Oneri_Dosya_DosyaId",
                table: "Oneri");

            migrationBuilder.DropIndex(
                name: "IX_Oneri_DosyaId",
                table: "Oneri");

            migrationBuilder.DropColumn(
                name: "DosyaId",
                table: "Oneri");

            migrationBuilder.AddColumn<int>(
                name: "OneriId",
                table: "Dosya",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dosya_OneriId",
                table: "Dosya",
                column: "OneriId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_Oneri_OneriId",
                table: "Dosya",
                column: "OneriId",
                principalTable: "Oneri",
                principalColumn: "Id");
        }
    }
}
