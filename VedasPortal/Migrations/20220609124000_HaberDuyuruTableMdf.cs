using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class HaberDuyuruTableMdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Begeni",
                table: "HaberDuyuru");

            migrationBuilder.DropColumn(
                name: "BegeniDerecesi",
                table: "HaberDuyuru");

            migrationBuilder.DropColumn(
                name: "BegeniSayisi",
                table: "HaberDuyuru");

            migrationBuilder.DropColumn(
                name: "BegeniYuzdesi",
                table: "HaberDuyuru");

            migrationBuilder.DropColumn(
                name: "GorulduSayisi",
                table: "HaberDuyuru");

            migrationBuilder.DropColumn(
                name: "BegeniDerecesi",
                table: "Etkinlik");

            migrationBuilder.AlterColumn<string>(
                name: "Adi",
                table: "ToplantiOdasi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Adi",
                table: "Merkez",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Adi",
                table: "ToplantiOdasi",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Adi",
                table: "Merkez",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "Begeni",
                table: "HaberDuyuru",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "BegeniDerecesi",
                table: "HaberDuyuru",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddColumn<int>(
                name: "BegeniDerecesi",
                table: "Etkinlik",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
