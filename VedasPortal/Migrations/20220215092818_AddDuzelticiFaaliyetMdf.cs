using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class AddDuzelticiFaaliyetMdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AktifPasif",
                table: "DuzelticiFaaliyet",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Kategori",
                table: "DuzelticiFaaliyet",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AktifPasif",
                table: "DuzelticiFaaliyet");

            migrationBuilder.DropColumn(
                name: "Kategori",
                table: "DuzelticiFaaliyet");
        }
    }
}
