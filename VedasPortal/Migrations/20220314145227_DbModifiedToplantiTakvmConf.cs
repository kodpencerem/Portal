using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class DbModifiedToplantiTakvmConf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToplantiTakvimi_ToplantiOdasi_ToplantiOdasiId",
                table: "ToplantiTakvimi");

            migrationBuilder.DropIndex(
                name: "IX_ToplantiTakvimi_ToplantiOdasiId",
                table: "ToplantiTakvimi");

            migrationBuilder.DropColumn(
                name: "ToplantiOdasiId",
                table: "ToplantiTakvimi");

            migrationBuilder.AddColumn<int>(
                name: "ToplantiTakvimiId",
                table: "ToplantiOdasi",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ToplantiOdasi_ToplantiTakvimiId",
                table: "ToplantiOdasi",
                column: "ToplantiTakvimiId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToplantiOdasi_ToplantiTakvimi_ToplantiTakvimiId",
                table: "ToplantiOdasi",
                column: "ToplantiTakvimiId",
                principalTable: "ToplantiTakvimi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToplantiOdasi_ToplantiTakvimi_ToplantiTakvimiId",
                table: "ToplantiOdasi");

            migrationBuilder.DropIndex(
                name: "IX_ToplantiOdasi_ToplantiTakvimiId",
                table: "ToplantiOdasi");

            migrationBuilder.DropColumn(
                name: "ToplantiTakvimiId",
                table: "ToplantiOdasi");

            migrationBuilder.AddColumn<int>(
                name: "ToplantiOdasiId",
                table: "ToplantiTakvimi",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ToplantiTakvimi_ToplantiOdasiId",
                table: "ToplantiTakvimi",
                column: "ToplantiOdasiId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToplantiTakvimi_ToplantiOdasi_ToplantiOdasiId",
                table: "ToplantiTakvimi",
                column: "ToplantiOdasiId",
                principalTable: "ToplantiOdasi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
