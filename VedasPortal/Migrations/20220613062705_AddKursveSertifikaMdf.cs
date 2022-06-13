using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class AddKursveSertifikaMdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "KursVeSertifika",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "KursVeSertifika",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KursVeSertifika_ApplicationUserId1",
                table: "KursVeSertifika",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_KursVeSertifika_AspNetUsers_ApplicationUserId1",
                table: "KursVeSertifika",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KursVeSertifika_AspNetUsers_ApplicationUserId1",
                table: "KursVeSertifika");

            migrationBuilder.DropIndex(
                name: "IX_KursVeSertifika_ApplicationUserId1",
                table: "KursVeSertifika");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "KursVeSertifika");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "KursVeSertifika");
        }
    }
}
