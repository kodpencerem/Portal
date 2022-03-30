using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class UpdateToplantiTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adi",
                table: "Toplanti");

            migrationBuilder.DropColumn(
                name: "GunAdi",
                table: "Toplanti");

            migrationBuilder.DropColumn(
                name: "Mesaj",
                table: "Toplanti");

            migrationBuilder.DropColumn(
                name: "ToplantiNotu",
                table: "Toplanti");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adi",
                table: "Toplanti",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GunAdi",
                table: "Toplanti",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mesaj",
                table: "Toplanti",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToplantiNotu",
                table: "Toplanti",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
