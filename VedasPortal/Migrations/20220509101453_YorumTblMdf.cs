using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class YorumTblMdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OnaylansınMı",
                table: "Yorum",
                newName: "OnaylansinMi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OnaylansinMi",
                table: "Yorum",
                newName: "OnaylansınMı");
        }
    }
}
