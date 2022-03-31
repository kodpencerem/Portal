using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class ToplantiOdasiMdfd4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToplantiOdasi_Merkez_MerkezId",
                table: "ToplantiOdasi");

            migrationBuilder.DropColumn(
                name: "ToplantiMerkezi",
                table: "ToplantiOdasi");

            migrationBuilder.DropColumn(
                name: "ToplantiMerkezi",
                table: "ToplantiNotu");

            migrationBuilder.DropColumn(
                name: "ToplantiMerkezi",
                table: "Toplanti");

            migrationBuilder.RenameColumn(
                name: "MerkezId",
                table: "ToplantiOdasi",
                newName: "ToplantiMerkeziId");

            migrationBuilder.RenameIndex(
                name: "IX_ToplantiOdasi_MerkezId",
                table: "ToplantiOdasi",
                newName: "IX_ToplantiOdasi_ToplantiMerkeziId");

            migrationBuilder.AddColumn<int>(
                name: "ToplantiMerkeziId",
                table: "ToplantiNotu",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ToplantiMerkeziId",
                table: "Toplanti",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ToplantiNotu_ToplantiMerkeziId",
                table: "ToplantiNotu",
                column: "ToplantiMerkeziId");

            migrationBuilder.CreateIndex(
                name: "IX_Toplanti_ToplantiMerkeziId",
                table: "Toplanti",
                column: "ToplantiMerkeziId");

            migrationBuilder.AddForeignKey(
                name: "FK_Toplanti_Merkez_ToplantiMerkeziId",
                table: "Toplanti",
                column: "ToplantiMerkeziId",
                principalTable: "Merkez",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ToplantiNotu_Merkez_ToplantiMerkeziId",
                table: "ToplantiNotu",
                column: "ToplantiMerkeziId",
                principalTable: "Merkez",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ToplantiOdasi_Merkez_ToplantiMerkeziId",
                table: "ToplantiOdasi",
                column: "ToplantiMerkeziId",
                principalTable: "Merkez",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Toplanti_Merkez_ToplantiMerkeziId",
                table: "Toplanti");

            migrationBuilder.DropForeignKey(
                name: "FK_ToplantiNotu_Merkez_ToplantiMerkeziId",
                table: "ToplantiNotu");

            migrationBuilder.DropForeignKey(
                name: "FK_ToplantiOdasi_Merkez_ToplantiMerkeziId",
                table: "ToplantiOdasi");

            migrationBuilder.DropIndex(
                name: "IX_ToplantiNotu_ToplantiMerkeziId",
                table: "ToplantiNotu");

            migrationBuilder.DropIndex(
                name: "IX_Toplanti_ToplantiMerkeziId",
                table: "Toplanti");

            migrationBuilder.DropColumn(
                name: "ToplantiMerkeziId",
                table: "ToplantiNotu");

            migrationBuilder.DropColumn(
                name: "ToplantiMerkeziId",
                table: "Toplanti");

            migrationBuilder.RenameColumn(
                name: "ToplantiMerkeziId",
                table: "ToplantiOdasi",
                newName: "MerkezId");

            migrationBuilder.RenameIndex(
                name: "IX_ToplantiOdasi_ToplantiMerkeziId",
                table: "ToplantiOdasi",
                newName: "IX_ToplantiOdasi_MerkezId");

            migrationBuilder.AddColumn<int>(
                name: "ToplantiMerkezi",
                table: "ToplantiOdasi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ToplantiMerkezi",
                table: "ToplantiNotu",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ToplantiMerkezi",
                table: "Toplanti",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ToplantiOdasi_Merkez_MerkezId",
                table: "ToplantiOdasi",
                column: "MerkezId",
                principalTable: "Merkez",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
