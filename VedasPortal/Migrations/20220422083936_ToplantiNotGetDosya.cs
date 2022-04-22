using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class ToplantiNotGetDosya : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "ToplantiNotuId",
                table: "Dosya",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dosya_ToplantiNotuId",
                table: "Dosya",
                column: "ToplantiNotuId",
                unique: true,
                filter: "[ToplantiNotuId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_ToplantiNotu_ToplantiNotuId",
                table: "Dosya",
                column: "ToplantiNotuId",
                principalTable: "ToplantiNotu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_ToplantiNotu_ToplantiNotuId",
                table: "Dosya");

            migrationBuilder.DropIndex(
                name: "IX_Dosya_ToplantiNotuId",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "ToplantiNotuId",
                table: "Dosya");

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
    }
}
