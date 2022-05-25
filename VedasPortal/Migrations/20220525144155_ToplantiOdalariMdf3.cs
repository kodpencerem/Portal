using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class ToplantiOdalariMdf3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
