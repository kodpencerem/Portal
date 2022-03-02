using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class ModifiedToplatiMerkeziTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AktifPasif",
                table: "ToplantiMerkezi",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "VideoKonferansMi",
                table: "ToplantiMerkezi",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AktifPasif",
                table: "ToplantiMerkezi");

            migrationBuilder.DropColumn(
                name: "VideoKonferansMi",
                table: "ToplantiMerkezi");
        }
    }
}
