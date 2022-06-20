using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class AppUserAndAnket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Anket_AnketId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AnketSecenek_AnketSecenekId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AnketId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AnketSecenekId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AnketId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AnketSecenekId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "AnketSecenek",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "AnketSecenek",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "Anket",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Anket",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnketSecenek_ApplicationUserId1",
                table: "AnketSecenek",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Anket_ApplicationUserId1",
                table: "Anket",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Anket_AspNetUsers_ApplicationUserId1",
                table: "Anket",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AnketSecenek_AspNetUsers_ApplicationUserId1",
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

            migrationBuilder.AddColumn<int>(
                name: "AnketId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AnketSecenekId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AnketId",
                table: "AspNetUsers",
                column: "AnketId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AnketSecenekId",
                table: "AspNetUsers",
                column: "AnketSecenekId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Anket_AnketId",
                table: "AspNetUsers",
                column: "AnketId",
                principalTable: "Anket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AnketSecenek_AnketSecenekId",
                table: "AspNetUsers",
                column: "AnketSecenekId",
                principalTable: "AnketSecenek",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
