using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class ToplantiTablesMdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Toplanti_Merkez_ToplantiMerkeziId",
                table: "Toplanti");

            migrationBuilder.DropIndex(
                name: "IX_Toplanti_ToplantiMerkeziId",
                table: "Toplanti");

            migrationBuilder.DropColumn(
                name: "ToplantiMerkeziId",
                table: "Toplanti");

            migrationBuilder.AddColumn<int>(
                name: "ToplantiId",
                table: "Merkez",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Merkez_ToplantiId",
                table: "Merkez",
                column: "ToplantiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Merkez_Toplanti_ToplantiId",
                table: "Merkez",
                column: "ToplantiId",
                principalTable: "Toplanti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Merkez_Toplanti_ToplantiId",
                table: "Merkez");

            migrationBuilder.DropIndex(
                name: "IX_Merkez_ToplantiId",
                table: "Merkez");

            migrationBuilder.DropColumn(
                name: "ToplantiId",
                table: "Merkez");

            migrationBuilder.AddColumn<int>(
                name: "ToplantiMerkeziId",
                table: "Toplanti",
                type: "int",
                nullable: true);

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
        }
    }
}
