using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class modifiedVideoHaberDuyruTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResimId",
                table: "Katilimci",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Katilimci_ResimId",
                table: "Katilimci",
                column: "ResimId");

            migrationBuilder.AddForeignKey(
                name: "FK_Katilimci_Dosya_ResimId",
                table: "Katilimci",
                column: "ResimId",
                principalTable: "Dosya",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Katilimci_Dosya_ResimId",
                table: "Katilimci");

            migrationBuilder.DropIndex(
                name: "IX_Katilimci_ResimId",
                table: "Katilimci");

            migrationBuilder.DropColumn(
                name: "ResimId",
                table: "Katilimci");
        }
    }
}
