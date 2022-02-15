using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class UpdateDb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HaberDuyuru_Dosya_DosyaId",
                table: "HaberDuyuru");

            migrationBuilder.AlterColumn<int>(
                name: "DosyaId",
                table: "HaberDuyuru",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_HaberDuyuru_Dosya_DosyaId",
                table: "HaberDuyuru",
                column: "DosyaId",
                principalTable: "Dosya",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HaberDuyuru_Dosya_DosyaId",
                table: "HaberDuyuru");

            migrationBuilder.AlterColumn<int>(
                name: "DosyaId",
                table: "HaberDuyuru",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HaberDuyuru_Dosya_DosyaId",
                table: "HaberDuyuru",
                column: "DosyaId",
                principalTable: "Dosya",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
