using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class AddToplantiNotuModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GetDosyaId",
                table: "ToplantiNotu",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ToplantiNotu_GetDosyaId",
                table: "ToplantiNotu",
                column: "GetDosyaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToplantiNotu_Dosya_GetDosyaId",
                table: "ToplantiNotu",
                column: "GetDosyaId",
                principalTable: "Dosya",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToplantiNotu_Dosya_GetDosyaId",
                table: "ToplantiNotu");

            migrationBuilder.DropIndex(
                name: "IX_ToplantiNotu_GetDosyaId",
                table: "ToplantiNotu");

            migrationBuilder.DropColumn(
                name: "GetDosyaId",
                table: "ToplantiNotu");
        }
    }
}
