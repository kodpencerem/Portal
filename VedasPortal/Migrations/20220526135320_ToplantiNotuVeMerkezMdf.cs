using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class ToplantiNotuVeMerkezMdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DosyaId",
                table: "ToplantiNotu",
                newName: "ToplantiOdasiId");

            migrationBuilder.AddColumn<int>(
                name: "ToplantiMerkeziId",
                table: "ToplantiNotu",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ToplantiNotu_ToplantiMerkeziId",
                table: "ToplantiNotu",
                column: "ToplantiMerkeziId");

            migrationBuilder.CreateIndex(
                name: "IX_ToplantiNotu_ToplantiOdasiId",
                table: "ToplantiNotu",
                column: "ToplantiOdasiId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToplantiNotu_Merkez_ToplantiMerkeziId",
                table: "ToplantiNotu",
                column: "ToplantiMerkeziId",
                principalTable: "Merkez",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ToplantiNotu_ToplantiOdasi_ToplantiOdasiId",
                table: "ToplantiNotu",
                column: "ToplantiOdasiId",
                principalTable: "ToplantiOdasi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToplantiNotu_Merkez_ToplantiMerkeziId",
                table: "ToplantiNotu");

            migrationBuilder.DropForeignKey(
                name: "FK_ToplantiNotu_ToplantiOdasi_ToplantiOdasiId",
                table: "ToplantiNotu");

            migrationBuilder.DropIndex(
                name: "IX_ToplantiNotu_ToplantiMerkeziId",
                table: "ToplantiNotu");

            migrationBuilder.DropIndex(
                name: "IX_ToplantiNotu_ToplantiOdasiId",
                table: "ToplantiNotu");

            migrationBuilder.DropColumn(
                name: "ToplantiMerkeziId",
                table: "ToplantiNotu");

            migrationBuilder.RenameColumn(
                name: "ToplantiOdasiId",
                table: "ToplantiNotu",
                newName: "DosyaId");
        }
    }
}
