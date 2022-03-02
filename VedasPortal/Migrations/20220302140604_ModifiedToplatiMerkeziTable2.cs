using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class ModifiedToplatiMerkeziTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "RezervDurumu",
                table: "ToplantiOdasi",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RezervDurumu",
                table: "ToplantiMerkezi",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RezervDurumu",
                table: "ToplantiOdasi");

            migrationBuilder.DropColumn(
                name: "RezervDurumu",
                table: "ToplantiMerkezi");
        }
    }
}
