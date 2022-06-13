using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class AppUserMdf2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KursVeSertifika_AspNetUsers_ApplicationUserId",
                table: "KursVeSertifika");

            migrationBuilder.DropIndex(
                name: "IX_KursVeSertifika_ApplicationUserId",
                table: "KursVeSertifika");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "KursVeSertifika");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "KursVeSertifika",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KursVeSertifika_ApplicationUserId",
                table: "KursVeSertifika",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_KursVeSertifika_AspNetUsers_ApplicationUserId",
                table: "KursVeSertifika",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
