using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class AddKursSertifika2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KurumAdresi",
                table: "KursVeSertifika",
                newName: "GecerlilikSuresi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GecerlilikSuresi",
                table: "KursVeSertifika",
                newName: "KurumAdresi");
        }
    }
}
