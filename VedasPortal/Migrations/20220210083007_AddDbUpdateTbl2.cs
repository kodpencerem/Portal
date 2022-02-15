using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class AddDbUpdateTbl2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HaberDuyuru_Dosya_DosyaId",
                table: "HaberDuyuru");

            migrationBuilder.DropForeignKey(
                name: "FK_HaberDuyuru_Video_VideoId",
                table: "HaberDuyuru");

            migrationBuilder.AlterColumn<string>(
                name: "Adi",
                table: "HaberDuyuru",
                type: "VarChar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.CreateIndex(
                name: "IX_HaberDuyuru_No",
                table: "HaberDuyuru",
                column: "No");

            migrationBuilder.AddForeignKey(
                name: "FK_HaberDuyuru_Dosya_DosyaId",
                table: "HaberDuyuru",
                column: "DosyaId",
                principalTable: "Dosya",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HaberDuyuru_Video_VideoId",
                table: "HaberDuyuru",
                column: "VideoId",
                principalTable: "Video",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HaberDuyuru_Dosya_DosyaId",
                table: "HaberDuyuru");

            migrationBuilder.DropForeignKey(
                name: "FK_HaberDuyuru_Video_VideoId",
                table: "HaberDuyuru");

            migrationBuilder.DropIndex(
                name: "IX_HaberDuyuru_No",
                table: "HaberDuyuru");

            migrationBuilder.AlterColumn<string>(
                name: "Adi",
                table: "HaberDuyuru",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VarChar(250)",
                oldMaxLength: 250);

            migrationBuilder.AddForeignKey(
                name: "FK_HaberDuyuru_Dosya_DosyaId",
                table: "HaberDuyuru",
                column: "DosyaId",
                principalTable: "Dosya",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HaberDuyuru_Video_VideoId",
                table: "HaberDuyuru",
                column: "VideoId",
                principalTable: "Video",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
