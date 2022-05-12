using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class UserTableConf4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_KullaniciId1",
                table: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_KullaniciId1",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "Aciklama",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "KullaniciId1",
                table: "AspNetRoles");

            migrationBuilder.AlterColumn<string>(
                name: "KullaniciId",
                table: "AspNetRoles",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_KullaniciId",
                table: "AspNetRoles",
                column: "KullaniciId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_KullaniciId",
                table: "AspNetRoles",
                column: "KullaniciId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_KullaniciId",
                table: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_KullaniciId",
                table: "AspNetRoles");

            migrationBuilder.AlterColumn<int>(
                name: "KullaniciId",
                table: "AspNetRoles",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Aciklama",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KullaniciId1",
                table: "AspNetRoles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_KullaniciId1",
                table: "AspNetRoles",
                column: "KullaniciId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_KullaniciId1",
                table: "AspNetRoles",
                column: "KullaniciId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
