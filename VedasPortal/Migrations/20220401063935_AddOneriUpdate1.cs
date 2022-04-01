using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class AddOneriUpdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RedNedeni",
                table: "Oneri",
                type: "VarChar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar");

            migrationBuilder.AlterColumn<string>(
                name: "EPosta",
                table: "Oneri",
                type: "VarChar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RedNedeni",
                table: "Oneri",
                type: "VarChar",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VarChar",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EPosta",
                table: "Oneri",
                type: "VarChar",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VarChar",
                oldNullable: true);
        }
    }
}
