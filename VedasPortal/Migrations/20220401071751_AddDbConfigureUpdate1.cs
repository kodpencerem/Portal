using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class AddDbConfigureUpdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_DuzelticiFaaliyet_DuzelticiFaaliyetId",
                table: "Dosya");

            migrationBuilder.DropIndex(
                name: "IX_Dosya_DuzelticiFaaliyetId",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "DuzelticiFaaliyetId",
                table: "Dosya");

            migrationBuilder.AddColumn<int>(
                name: "ResimId",
                table: "DuzelticiFaaliyet",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DuzelticiFaaliyet_ResimId",
                table: "DuzelticiFaaliyet",
                column: "ResimId");

            migrationBuilder.AddForeignKey(
                name: "FK_DuzelticiFaaliyet_Dosya_ResimId",
                table: "DuzelticiFaaliyet",
                column: "ResimId",
                principalTable: "Dosya",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DuzelticiFaaliyet_Dosya_ResimId",
                table: "DuzelticiFaaliyet");

            migrationBuilder.DropIndex(
                name: "IX_DuzelticiFaaliyet_ResimId",
                table: "DuzelticiFaaliyet");

            migrationBuilder.DropColumn(
                name: "ResimId",
                table: "DuzelticiFaaliyet");

            migrationBuilder.AddColumn<int>(
                name: "DuzelticiFaaliyetId",
                table: "Dosya",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dosya_DuzelticiFaaliyetId",
                table: "Dosya",
                column: "DuzelticiFaaliyetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_DuzelticiFaaliyet_DuzelticiFaaliyetId",
                table: "Dosya",
                column: "DuzelticiFaaliyetId",
                principalTable: "DuzelticiFaaliyet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
