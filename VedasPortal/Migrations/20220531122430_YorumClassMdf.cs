using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class YorumClassMdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Yorum_Dosya_VideoClassId",
                table: "Yorum");

            migrationBuilder.RenameColumn(
                name: "VideoClassId",
                table: "Yorum",
                newName: "DosyaId");

            migrationBuilder.RenameIndex(
                name: "IX_Yorum_VideoClassId",
                table: "Yorum",
                newName: "IX_Yorum_DosyaId");

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

            migrationBuilder.RenameColumn(
                name: "DosyaId",
                table: "Yorum",
                newName: "VideoClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Yorum_DosyaId",
                table: "Yorum",
                newName: "IX_Yorum_VideoClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Yorum_Dosya_VideoClassId",
                table: "Yorum",
                column: "VideoClassId",
                principalTable: "Dosya",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
