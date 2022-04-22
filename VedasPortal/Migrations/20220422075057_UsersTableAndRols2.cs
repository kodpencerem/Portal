using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class UsersTableAndRols2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Toplanti_ToplantiId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ToplantiId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AktifEdilsinMi",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "KullaniciAdi",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SonGirisBilgisi",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ToplantiId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Kullanici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SonGirisBilgisi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AktifEdilsinMi = table.Column<bool>(type: "bit", nullable: false),
                    ToplantiId = table.Column<int>(type: "int", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KaydedenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SilenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanici", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kullanici_Toplanti_ToplantiId",
                        column: x => x.ToplantiId,
                        principalTable: "Toplanti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kullanici_ToplantiId",
                table: "Kullanici",
                column: "ToplantiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kullanici");

            migrationBuilder.AddColumn<bool>(
                name: "AktifEdilsinMi",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KullaniciAdi",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SonGirisBilgisi",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ToplantiId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ToplantiId",
                table: "AspNetUsers",
                column: "ToplantiId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Toplanti_ToplantiId",
                table: "AspNetUsers",
                column: "ToplantiId",
                principalTable: "Toplanti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
