using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class UzmnAlanMdfUser2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "UzmanlikAlani",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "UzmanlikAlani",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UzmanlikAlani_ApplicationUserId1",
                table: "UzmanlikAlani",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UzmanlikAlani_AspNetUsers_ApplicationUserId1",
                table: "UzmanlikAlani",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UzmanlikAlani_AspNetUsers_ApplicationUserId1",
                table: "UzmanlikAlani");

            migrationBuilder.DropIndex(
                name: "IX_UzmanlikAlani_ApplicationUserId1",
                table: "UzmanlikAlani");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "UzmanlikAlani");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "UzmanlikAlani");

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
    }
}
