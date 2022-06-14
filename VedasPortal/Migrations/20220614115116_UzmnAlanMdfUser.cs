using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class UzmnAlanMdfUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UzmanlikAlaniId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UzmanlikAlaniId",
                table: "AspNetUsers",
                column: "UzmanlikAlaniId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UzmanlikAlani_UzmanlikAlaniId",
                table: "AspNetUsers",
                column: "UzmanlikAlaniId",
                principalTable: "UzmanlikAlani",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UzmanlikAlani_UzmanlikAlaniId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UzmanlikAlaniId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UzmanlikAlaniId",
                table: "AspNetUsers");
        }
    }
}
