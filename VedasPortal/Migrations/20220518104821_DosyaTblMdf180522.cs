using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class DosyaTblMdf180522 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DosyaId",
                table: "Yorum",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Yorum_DosyaId",
                table: "Yorum",
                column: "DosyaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Yorum_Dosya_DosyaId",
                table: "Yorum",
                column: "DosyaId",
                principalTable: "Dosya",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Yorum_Dosya_DosyaId",
                table: "Yorum");

            migrationBuilder.DropIndex(
                name: "IX_Yorum_DosyaId",
                table: "Yorum");

            migrationBuilder.DropColumn(
                name: "DosyaId",
                table: "Yorum");
        }
    }
}
