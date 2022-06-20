using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class UserTableMdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
