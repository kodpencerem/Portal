using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class ToplantiOdasiMdfd5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToplantiOdasi_Toplanti_ToplantiTakvimiId",
                table: "ToplantiOdasi");

            migrationBuilder.RenameColumn(
                name: "ToplantiTakvimiId",
                table: "ToplantiOdasi",
                newName: "ToplantiId");

            migrationBuilder.RenameIndex(
                name: "IX_ToplantiOdasi_ToplantiTakvimiId",
                table: "ToplantiOdasi",
                newName: "IX_ToplantiOdasi_ToplantiId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToplantiOdasi_Toplanti_ToplantiId",
                table: "ToplantiOdasi",
                column: "ToplantiId",
                principalTable: "Toplanti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToplantiOdasi_Toplanti_ToplantiId",
                table: "ToplantiOdasi");

            migrationBuilder.RenameColumn(
                name: "ToplantiId",
                table: "ToplantiOdasi",
                newName: "ToplantiTakvimiId");

            migrationBuilder.RenameIndex(
                name: "IX_ToplantiOdasi_ToplantiId",
                table: "ToplantiOdasi",
                newName: "IX_ToplantiOdasi_ToplantiTakvimiId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToplantiOdasi_Toplanti_ToplantiTakvimiId",
                table: "ToplantiOdasi",
                column: "ToplantiTakvimiId",
                principalTable: "Toplanti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
