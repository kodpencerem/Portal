using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class UserTable6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KullaniciId",
                table: "Dosya",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KullaniciId1",
                table: "Dosya",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccessToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KullaniciRolId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "KullaniciRol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciRol", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dosya_KullaniciId1",
                table: "Dosya",
                column: "KullaniciId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_KullaniciRolId",
                table: "AspNetUsers",
                column: "KullaniciRolId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_KullaniciRol_KullaniciRolId",
                table: "AspNetUsers",
                column: "KullaniciRolId",
                principalTable: "KullaniciRol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_AspNetUsers_KullaniciId1",
                table: "Dosya",
                column: "KullaniciId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_KullaniciRol_KullaniciRolId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_AspNetUsers_KullaniciId1",
                table: "Dosya");

            migrationBuilder.DropTable(
                name: "KullaniciRol");

            migrationBuilder.DropIndex(
                name: "IX_Dosya_KullaniciId1",
                table: "Dosya");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_KullaniciRolId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "KullaniciId",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "KullaniciId1",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "AccessToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "KullaniciRolId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");
        }
    }
}
