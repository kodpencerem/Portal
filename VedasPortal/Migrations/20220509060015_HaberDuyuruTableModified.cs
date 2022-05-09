using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class HaberDuyuruTableModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BegeniSayisi",
                table: "HaberDuyuru",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BegeniYuzdesi",
                table: "HaberDuyuru",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GorulduSayisi",
                table: "HaberDuyuru",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BegeniSayisi",
                table: "HaberDuyuru");

            migrationBuilder.DropColumn(
                name: "BegeniYuzdesi",
                table: "HaberDuyuru");

            migrationBuilder.DropColumn(
                name: "GorulduSayisi",
                table: "HaberDuyuru");
        }
    }
}
