using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class ToplantiTablesMdf2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Dosya_ToplantiNotuId",
                table: "Dosya");

            migrationBuilder.AddColumn<int>(
                name: "DosyaId",
                table: "ToplantiNotu",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ToplantiId",
                table: "ToplantiNotu",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ToplantiNotu_ToplantiId",
                table: "ToplantiNotu",
                column: "ToplantiId");

            migrationBuilder.CreateIndex(
                name: "IX_Dosya_ToplantiNotuId",
                table: "Dosya",
                column: "ToplantiNotuId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToplantiNotu_Toplanti_ToplantiId",
                table: "ToplantiNotu",
                column: "ToplantiId",
                principalTable: "Toplanti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToplantiNotu_Toplanti_ToplantiId",
                table: "ToplantiNotu");

            migrationBuilder.DropIndex(
                name: "IX_ToplantiNotu_ToplantiId",
                table: "ToplantiNotu");

            migrationBuilder.DropIndex(
                name: "IX_Dosya_ToplantiNotuId",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "DosyaId",
                table: "ToplantiNotu");

            migrationBuilder.DropColumn(
                name: "ToplantiId",
                table: "ToplantiNotu");

            migrationBuilder.CreateIndex(
                name: "IX_Dosya_ToplantiNotuId",
                table: "Dosya",
                column: "ToplantiNotuId",
                unique: true,
                filter: "[ToplantiNotuId] IS NOT NULL");
        }
    }
}
