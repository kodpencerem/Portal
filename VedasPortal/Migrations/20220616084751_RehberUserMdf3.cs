using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class RehberUserMdf3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "AnketSecenek",
                type: "int",
                nullable: false,
                defaultValue: 0);
          
            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "Anket",
                type: "int",
                nullable: false,
                defaultValue: 0);
            
            migrationBuilder.CreateIndex(
                name: "IX_AnketSecenek_ApplicationUserId",
                table: "AnketSecenek",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Anket_ApplicationUserId",
                table: "Anket",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Anket_AspNetUsers_ApplicationUserId",
                table: "Anket",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AnketSecenek_AspNetUsers_ApplicationUserId",
                table: "AnketSecenek",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anket_AspNetUsers_ApplicationUserId1",
                table: "Anket");

            migrationBuilder.DropForeignKey(
                name: "FK_AnketSecenek_AspNetUsers_ApplicationUserId1",
                table: "AnketSecenek");

            migrationBuilder.DropIndex(
                name: "IX_AnketSecenek_ApplicationUserId1",
                table: "AnketSecenek");

            migrationBuilder.DropIndex(
                name: "IX_Anket_ApplicationUserId1",
                table: "Anket");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "AnketSecenek");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "AnketSecenek");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Anket");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Anket");
        }
    }
}
