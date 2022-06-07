using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class VidyoDosyaMdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EgitimId",
                table: "Vidyo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vidyo_EgitimId",
                table: "Vidyo",
                column: "EgitimId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vidyo_Egitim_EgitimId",
                table: "Vidyo",
                column: "EgitimId",
                principalTable: "Egitim",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vidyo_Egitim_EgitimId",
                table: "Vidyo");

            migrationBuilder.DropIndex(
                name: "IX_Vidyo_EgitimId",
                table: "Vidyo");

            migrationBuilder.DropColumn(
                name: "EgitimId",
                table: "Vidyo");
        }
    }
}
