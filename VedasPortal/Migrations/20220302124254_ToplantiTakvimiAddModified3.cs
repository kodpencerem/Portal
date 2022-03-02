using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class ToplantiTakvimiAddModified3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adres",
                table: "ToplantiTakvimi");

            migrationBuilder.AddColumn<string>(
                name: "Adres",
                table: "ToplantiOdasi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AktifPasif",
                table: "ToplantiOdasi",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adres",
                table: "ToplantiOdasi");

            migrationBuilder.DropColumn(
                name: "AktifPasif",
                table: "ToplantiOdasi");

            migrationBuilder.AddColumn<string>(
                name: "Adres",
                table: "ToplantiTakvimi",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
