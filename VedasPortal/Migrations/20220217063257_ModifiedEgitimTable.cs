using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class ModifiedEgitimTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KKategori",
                table: "Egitim");

            migrationBuilder.RenameColumn(
                name: "Basliklar",
                table: "Egitim",
                newName: "KonuBasligi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KonuBasligi",
                table: "Egitim",
                newName: "Basliklar");

            migrationBuilder.AddColumn<int>(
                name: "KKategori",
                table: "Egitim",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
