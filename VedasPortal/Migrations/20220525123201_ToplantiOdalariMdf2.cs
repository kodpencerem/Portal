using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class ToplantiOdalariMdf2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToplantiOdasi_Toplanti_ToplantiId",
                table: "ToplantiOdasi");

            migrationBuilder.DropIndex(
                name: "IX_ToplantiOdasi_ToplantiId",
                table: "ToplantiOdasi");

            migrationBuilder.DropColumn(
                name: "ToplantiId",
                table: "ToplantiOdasi");

            migrationBuilder.AddColumn<int>(
                name: "ToplantiOdasiId",
                table: "Toplanti",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Toplanti_ToplantiOdasiId",
                table: "Toplanti",
                column: "ToplantiOdasiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Toplanti_ToplantiOdasi_ToplantiOdasiId",
                table: "Toplanti",
                column: "ToplantiOdasiId",
                principalTable: "ToplantiOdasi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Toplanti_ToplantiOdasi_ToplantiOdasiId",
                table: "Toplanti");

            migrationBuilder.DropIndex(
                name: "IX_Toplanti_ToplantiOdasiId",
                table: "Toplanti");

            migrationBuilder.DropColumn(
                name: "ToplantiOdasiId",
                table: "Toplanti");

            migrationBuilder.AddColumn<int>(
                name: "ToplantiId",
                table: "ToplantiOdasi",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ToplantiOdasi_ToplantiId",
                table: "ToplantiOdasi",
                column: "ToplantiId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToplantiOdasi_Toplanti_ToplantiId",
                table: "ToplantiOdasi",
                column: "ToplantiId",
                principalTable: "Toplanti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
