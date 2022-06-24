using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class AppUserAnketAnketSecenekMdf4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anket_AspNetUsers_ApplicationUserId",
                table: "Anket");

            migrationBuilder.DropForeignKey(
                name: "FK_AnketSecenek_AspNetUsers_ApplicationUserId",
                table: "AnketSecenek");

            migrationBuilder.DropIndex(
                name: "IX_AnketSecenek_ApplicationUserId",
                table: "AnketSecenek");

            migrationBuilder.DropIndex(
                name: "IX_Anket_ApplicationUserId",
                table: "Anket");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "AnketSecenek");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Anket");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "AnketSecenek",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Anket",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "AnketSecenek");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Anket");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "AnketSecenek",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Anket",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnketSecenek_ApplicationUserId",
                table: "AnketSecenek",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Anket_ApplicationUserId",
                table: "Anket",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Anket_AspNetUsers_ApplicationUserId",
                table: "Anket",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AnketSecenek_AspNetUsers_ApplicationUserId",
                table: "AnketSecenek",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
