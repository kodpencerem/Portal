using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class OneriTblMdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KabulDurum",
                table: "Oneri");

            migrationBuilder.AddColumn<int>(
                name: "OneriDurum",
                table: "Oneri",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OneriDurum",
                table: "Oneri");

            migrationBuilder.AddColumn<bool>(
                name: "KabulDurum",
                table: "Oneri",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
