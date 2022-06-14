using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class UzmnAlanMdfUser3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
