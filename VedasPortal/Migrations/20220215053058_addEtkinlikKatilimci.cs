using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class addEtkinlikKatilimci : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Etkinlik_Katilimci_KatilimciId",
                table: "Etkinlik");

            migrationBuilder.DropForeignKey(
                name: "FK_HaberDuyuru_Dosya_DosyaId",
                table: "HaberDuyuru");

            migrationBuilder.DropForeignKey(
                name: "FK_HaberDuyuru_Video_VideoId",
                table: "HaberDuyuru");

            migrationBuilder.DropIndex(
                name: "IX_HaberDuyuru_DosyaId",
                table: "HaberDuyuru");

            migrationBuilder.DropIndex(
                name: "IX_HaberDuyuru_No",
                table: "HaberDuyuru");

            migrationBuilder.DropColumn(
                name: "DosyaId",
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

            migrationBuilder.AlterColumn<int>(
                name: "KatilimciId",
                table: "Etkinlik",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "AktifPasif",
                table: "Etkinlik",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AnasayfadaGoster",
                table: "Etkinlik",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "KKategori",
                table: "Etkinlik",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Kategori",
                table: "Etkinlik",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "SliderdaGoster",
                table: "Etkinlik",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "HaberDuyuruId",
                table: "Dosya",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dosya_HaberDuyuruId",
                table: "Dosya",
                column: "HaberDuyuruId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_HaberDuyuru_HaberDuyuruId",
                table: "Dosya",
                column: "HaberDuyuruId",
                principalTable: "HaberDuyuru",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Etkinlik_Katilimci_KatilimciId",
                table: "Etkinlik",
                column: "KatilimciId",
                principalTable: "Katilimci",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_HaberDuyuru_HaberDuyuruId",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Etkinlik_Katilimci_KatilimciId",
                table: "Etkinlik");

            migrationBuilder.DropForeignKey(
                name: "FK_HaberDuyuru_Video_VideoId",
                table: "HaberDuyuru");

            migrationBuilder.DropIndex(
                name: "IX_Dosya_HaberDuyuruId",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "AktifPasif",
                table: "Etkinlik");

            migrationBuilder.DropColumn(
                name: "AnasayfadaGoster",
                table: "Etkinlik");

            migrationBuilder.DropColumn(
                name: "KKategori",
                table: "Etkinlik");

            migrationBuilder.DropColumn(
                name: "Kategori",
                table: "Etkinlik");

            migrationBuilder.DropColumn(
                name: "SliderdaGoster",
                table: "Etkinlik");

            migrationBuilder.DropColumn(
                name: "HaberDuyuruId",
                table: "Dosya");

            migrationBuilder.AlterColumn<string>(
                name: "Adi",
                table: "HaberDuyuru",
                type: "VarChar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AddColumn<int>(
                name: "DosyaId",
                table: "HaberDuyuru",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "KatilimciId",
                table: "Etkinlik",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HaberDuyuru_DosyaId",
                table: "HaberDuyuru",
                column: "DosyaId");

            migrationBuilder.CreateIndex(
                name: "IX_HaberDuyuru_No",
                table: "HaberDuyuru",
                column: "No");

            migrationBuilder.AddForeignKey(
                name: "FK_Etkinlik_Katilimci_KatilimciId",
                table: "Etkinlik",
                column: "KatilimciId",
                principalTable: "Katilimci",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
