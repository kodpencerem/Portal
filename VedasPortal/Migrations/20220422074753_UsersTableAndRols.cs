using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class UsersTableAndRols : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
