using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class YorumTblMdf2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EgitimId",
                table: "Yorum",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OneriId",
                table: "Yorum",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Yorum_EgitimId",
                table: "Yorum",
                column: "EgitimId");

            migrationBuilder.CreateIndex(
                name: "IX_Yorum_OneriId",
                table: "Yorum",
                column: "OneriId");

            migrationBuilder.AddForeignKey(
                name: "FK_Yorum_Egitim_EgitimId",
                table: "Yorum",
                column: "EgitimId",
                principalTable: "Egitim",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Yorum_Oneri_OneriId",
                table: "Yorum",
                column: "OneriId",
                principalTable: "Oneri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Yorum_Egitim_EgitimId",
                table: "Yorum");

            migrationBuilder.DropForeignKey(
                name: "FK_Yorum_Oneri_OneriId",
                table: "Yorum");

            migrationBuilder.DropIndex(
                name: "IX_Yorum_EgitimId",
                table: "Yorum");

            migrationBuilder.DropIndex(
                name: "IX_Yorum_OneriId",
                table: "Yorum");

            migrationBuilder.DropColumn(
                name: "EgitimId",
                table: "Yorum");

            migrationBuilder.DropColumn(
                name: "OneriId",
                table: "Yorum");
        }
    }
}
