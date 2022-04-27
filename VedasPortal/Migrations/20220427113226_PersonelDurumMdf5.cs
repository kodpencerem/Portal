using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class PersonelDurumMdf5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Aciklama",
                table: "PersonelDurum",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DogumYeri",
                table: "PersonelDurum",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EMail",
                table: "PersonelDurum",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aciklama",
                table: "PersonelDurum");

            migrationBuilder.DropColumn(
                name: "DogumYeri",
                table: "PersonelDurum");

            migrationBuilder.DropColumn(
                name: "EMail",
                table: "PersonelDurum");
        }
    }
}
