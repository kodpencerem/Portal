using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class EtkinlikTableMdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BegeniDerecesi",
                table: "Etkinlik");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BegeniDerecesi",
                table: "Etkinlik",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
