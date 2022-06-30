using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class RehberMdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Toplanti_Merkez_ToplantiMerkeziId",
                table: "Toplanti");

            migrationBuilder.DropForeignKey(
                name: "FK_ToplantiNotu_Merkez_ToplantiMerkeziId",
                table: "ToplantiNotu");

            migrationBuilder.DropForeignKey(
                name: "FK_ToplantiOdasi_Merkez_ToplantiMerkeziId",
                table: "ToplantiOdasi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Merkez",
                table: "Merkez");

            migrationBuilder.RenameTable(
                name: "Merkez",
                newName: "ToplantiMerkezi");

            migrationBuilder.AlterColumn<string>(
                name: "Unvani",
                table: "Rehber",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Soyadi",
                table: "Rehber",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Rehber",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToplantiMerkezi",
                table: "ToplantiMerkezi",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Toplanti_ToplantiMerkezi_ToplantiMerkeziId",
                table: "Toplanti",
                column: "ToplantiMerkeziId",
                principalTable: "ToplantiMerkezi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ToplantiNotu_ToplantiMerkezi_ToplantiMerkeziId",
                table: "ToplantiNotu",
                column: "ToplantiMerkeziId",
                principalTable: "ToplantiMerkezi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ToplantiOdasi_ToplantiMerkezi_ToplantiMerkeziId",
                table: "ToplantiOdasi",
                column: "ToplantiMerkeziId",
                principalTable: "ToplantiMerkezi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Toplanti_ToplantiMerkezi_ToplantiMerkeziId",
                table: "Toplanti");

            migrationBuilder.DropForeignKey(
                name: "FK_ToplantiNotu_ToplantiMerkezi_ToplantiMerkeziId",
                table: "ToplantiNotu");

            migrationBuilder.DropForeignKey(
                name: "FK_ToplantiOdasi_ToplantiMerkezi_ToplantiMerkeziId",
                table: "ToplantiOdasi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToplantiMerkezi",
                table: "ToplantiMerkezi");

            migrationBuilder.RenameTable(
                name: "ToplantiMerkezi",
                newName: "Merkez");

            migrationBuilder.AlterColumn<string>(
                name: "Unvani",
                table: "Rehber",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Soyadi",
                table: "Rehber",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Rehber",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Merkez",
                table: "Merkez",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Toplanti_Merkez_ToplantiMerkeziId",
                table: "Toplanti",
                column: "ToplantiMerkeziId",
                principalTable: "Merkez",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ToplantiNotu_Merkez_ToplantiMerkeziId",
                table: "ToplantiNotu",
                column: "ToplantiMerkeziId",
                principalTable: "Merkez",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ToplantiOdasi_Merkez_ToplantiMerkeziId",
                table: "ToplantiOdasi",
                column: "ToplantiMerkeziId",
                principalTable: "Merkez",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
