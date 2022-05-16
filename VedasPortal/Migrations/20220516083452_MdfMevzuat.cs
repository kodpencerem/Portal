using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class MdfMevzuat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mevzuat_Mevzuat_MevzuatId",
                table: "Mevzuat");

            migrationBuilder.DropIndex(
                name: "IX_Mevzuat_MevzuatId",
                table: "Mevzuat");

            migrationBuilder.DropColumn(
                name: "MevzuatId",
                table: "Mevzuat");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MevzuatId",
                table: "Mevzuat",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mevzuat_MevzuatId",
                table: "Mevzuat",
                column: "MevzuatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mevzuat_Mevzuat_MevzuatId",
                table: "Mevzuat",
                column: "MevzuatId",
                principalTable: "Mevzuat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
