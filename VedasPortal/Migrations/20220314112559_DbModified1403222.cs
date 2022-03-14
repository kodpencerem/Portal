using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class DbModified1403222 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Etkinlik_Katilimci_KatilimciId",
                table: "Etkinlik");

            migrationBuilder.DropIndex(
                name: "IX_Etkinlik_KatilimciId",
                table: "Etkinlik");

            migrationBuilder.DropColumn(
                name: "KatilimciId",
                table: "Etkinlik");

            migrationBuilder.AddColumn<int>(
                name: "EtkinlikId",
                table: "Katilimci",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Katilimci_EtkinlikId",
                table: "Katilimci",
                column: "EtkinlikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Katilimci_Etkinlik_EtkinlikId",
                table: "Katilimci",
                column: "EtkinlikId",
                principalTable: "Etkinlik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Katilimci_Etkinlik_EtkinlikId",
                table: "Katilimci");

            migrationBuilder.DropIndex(
                name: "IX_Katilimci_EtkinlikId",
                table: "Katilimci");

            migrationBuilder.DropColumn(
                name: "EtkinlikId",
                table: "Katilimci");

            migrationBuilder.AddColumn<int>(
                name: "KatilimciId",
                table: "Etkinlik",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Etkinlik_KatilimciId",
                table: "Etkinlik",
                column: "KatilimciId");

            migrationBuilder.AddForeignKey(
                name: "FK_Etkinlik_Katilimci_KatilimciId",
                table: "Etkinlik",
                column: "KatilimciId",
                principalTable: "Katilimci",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
