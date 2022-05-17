using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class VideoTblMdf17052022 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Yorum_Egitim_EgitimId",
                table: "Yorum");

            migrationBuilder.DropIndex(
                name: "IX_Yorum_EgitimId",
                table: "Yorum");

            migrationBuilder.DropColumn(
                name: "EgitimId",
                table: "Yorum");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EgitimId",
                table: "Yorum",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Yorum_EgitimId",
                table: "Yorum",
                column: "EgitimId");

            migrationBuilder.AddForeignKey(
                name: "FK_Yorum_Egitim_EgitimId",
                table: "Yorum",
                column: "EgitimId",
                principalTable: "Egitim",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
