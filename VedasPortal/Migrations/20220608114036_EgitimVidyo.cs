using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class EgitimVidyo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_Egitim_EgitimId",
                table: "Dosya");

            migrationBuilder.DropIndex(
                name: "IX_Dosya_EgitimId",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "EgitimId",
                table: "Dosya");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EgitimId",
                table: "Dosya",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dosya_EgitimId",
                table: "Dosya",
                column: "EgitimId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_Egitim_EgitimId",
                table: "Dosya",
                column: "EgitimId",
                principalTable: "Egitim",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
