using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class VidyoDosyaEgitimMdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AltBaslik",
                table: "Egitim",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IzlenmeDurumu",
                table: "Egitim",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AltBaslik",
                table: "Egitim");

            migrationBuilder.DropColumn(
                name: "IzlenmeDurumu",
                table: "Egitim");
        }
    }
}
