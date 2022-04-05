using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class MdfDuyuruHaber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_DuzelticiFaaliyet_DuzelticiFaaliyetId1",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_Egitim_EgitimId1",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_Etkinlik_EtkinlikId1",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_HaberDuyuru_HaberDuyuruId1",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_IkUygulama_IkUygulamaId1",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_Katilimci_KatilimciId1",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_Mevzuat_MevzuatId1",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_Oneri_OneriId1",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_Rehber_RehberId1",
                table: "Dosya");

            migrationBuilder.RenameColumn(
                name: "RehberId1",
                table: "Dosya",
                newName: "RehberId");

            migrationBuilder.RenameColumn(
                name: "OneriId1",
                table: "Dosya",
                newName: "OneriId");

            migrationBuilder.RenameColumn(
                name: "MevzuatId1",
                table: "Dosya",
                newName: "MevzuatId");

            migrationBuilder.RenameColumn(
                name: "KatilimciId1",
                table: "Dosya",
                newName: "KatilimciId");

            migrationBuilder.RenameColumn(
                name: "IkUygulamaId1",
                table: "Dosya",
                newName: "IkUygulamaId");

            migrationBuilder.RenameColumn(
                name: "HaberDuyuruId1",
                table: "Dosya",
                newName: "HaberDuyuruId");

            migrationBuilder.RenameColumn(
                name: "EtkinlikId1",
                table: "Dosya",
                newName: "EtkinlikId");

            migrationBuilder.RenameColumn(
                name: "EgitimId1",
                table: "Dosya",
                newName: "EgitimId");

            migrationBuilder.RenameColumn(
                name: "DuzelticiFaaliyetId1",
                table: "Dosya",
                newName: "DuzelticiFaaliyetId");

            migrationBuilder.RenameIndex(
                name: "IX_Dosya_RehberId1",
                table: "Dosya",
                newName: "IX_Dosya_RehberId");

            migrationBuilder.RenameIndex(
                name: "IX_Dosya_OneriId1",
                table: "Dosya",
                newName: "IX_Dosya_OneriId");

            migrationBuilder.RenameIndex(
                name: "IX_Dosya_MevzuatId1",
                table: "Dosya",
                newName: "IX_Dosya_MevzuatId");

            migrationBuilder.RenameIndex(
                name: "IX_Dosya_KatilimciId1",
                table: "Dosya",
                newName: "IX_Dosya_KatilimciId");

            migrationBuilder.RenameIndex(
                name: "IX_Dosya_IkUygulamaId1",
                table: "Dosya",
                newName: "IX_Dosya_IkUygulamaId");

            migrationBuilder.RenameIndex(
                name: "IX_Dosya_HaberDuyuruId1",
                table: "Dosya",
                newName: "IX_Dosya_HaberDuyuruId");

            migrationBuilder.RenameIndex(
                name: "IX_Dosya_EtkinlikId1",
                table: "Dosya",
                newName: "IX_Dosya_EtkinlikId");

            migrationBuilder.RenameIndex(
                name: "IX_Dosya_EgitimId1",
                table: "Dosya",
                newName: "IX_Dosya_EgitimId");

            migrationBuilder.RenameIndex(
                name: "IX_Dosya_DuzelticiFaaliyetId1",
                table: "Dosya",
                newName: "IX_Dosya_DuzelticiFaaliyetId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SilmeTarihi",
                table: "Dosya",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SilenKullanici",
                table: "Dosya",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "KayitTarihi",
                table: "Dosya",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<string>(
                name: "KaydedenKullanici",
                table: "Dosya",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DuzenleyenKullanici",
                table: "Dosya",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DuzenlemeTarihi",
                table: "Dosya",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "AktifPasif",
                table: "Dosya",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "Bit");

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "Dosya",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_DuzelticiFaaliyet_DuzelticiFaaliyetId",
                table: "Dosya",
                column: "DuzelticiFaaliyetId",
                principalTable: "DuzelticiFaaliyet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_Egitim_EgitimId",
                table: "Dosya",
                column: "EgitimId",
                principalTable: "Egitim",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_Etkinlik_EtkinlikId",
                table: "Dosya",
                column: "EtkinlikId",
                principalTable: "Etkinlik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_HaberDuyuru_HaberDuyuruId",
                table: "Dosya",
                column: "HaberDuyuruId",
                principalTable: "HaberDuyuru",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_IkUygulama_IkUygulamaId",
                table: "Dosya",
                column: "IkUygulamaId",
                principalTable: "IkUygulama",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_Katilimci_KatilimciId",
                table: "Dosya",
                column: "KatilimciId",
                principalTable: "Katilimci",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_Mevzuat_MevzuatId",
                table: "Dosya",
                column: "MevzuatId",
                principalTable: "Mevzuat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_Oneri_OneriId",
                table: "Dosya",
                column: "OneriId",
                principalTable: "Oneri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_Rehber_RehberId",
                table: "Dosya",
                column: "RehberId",
                principalTable: "Rehber",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_DuzelticiFaaliyet_DuzelticiFaaliyetId",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_Egitim_EgitimId",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_Etkinlik_EtkinlikId",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_HaberDuyuru_HaberDuyuruId",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_IkUygulama_IkUygulamaId",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_Katilimci_KatilimciId",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_Mevzuat_MevzuatId",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_Oneri_OneriId",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_Rehber_RehberId",
                table: "Dosya");

            migrationBuilder.RenameColumn(
                name: "RehberId",
                table: "Dosya",
                newName: "RehberId1");

            migrationBuilder.RenameColumn(
                name: "OneriId",
                table: "Dosya",
                newName: "OneriId1");

            migrationBuilder.RenameColumn(
                name: "MevzuatId",
                table: "Dosya",
                newName: "MevzuatId1");

            migrationBuilder.RenameColumn(
                name: "KatilimciId",
                table: "Dosya",
                newName: "KatilimciId1");

            migrationBuilder.RenameColumn(
                name: "IkUygulamaId",
                table: "Dosya",
                newName: "IkUygulamaId1");

            migrationBuilder.RenameColumn(
                name: "HaberDuyuruId",
                table: "Dosya",
                newName: "HaberDuyuruId1");

            migrationBuilder.RenameColumn(
                name: "EtkinlikId",
                table: "Dosya",
                newName: "EtkinlikId1");

            migrationBuilder.RenameColumn(
                name: "EgitimId",
                table: "Dosya",
                newName: "EgitimId1");

            migrationBuilder.RenameColumn(
                name: "DuzelticiFaaliyetId",
                table: "Dosya",
                newName: "DuzelticiFaaliyetId1");

            migrationBuilder.RenameIndex(
                name: "IX_Dosya_RehberId",
                table: "Dosya",
                newName: "IX_Dosya_RehberId1");

            migrationBuilder.RenameIndex(
                name: "IX_Dosya_OneriId",
                table: "Dosya",
                newName: "IX_Dosya_OneriId1");

            migrationBuilder.RenameIndex(
                name: "IX_Dosya_MevzuatId",
                table: "Dosya",
                newName: "IX_Dosya_MevzuatId1");

            migrationBuilder.RenameIndex(
                name: "IX_Dosya_KatilimciId",
                table: "Dosya",
                newName: "IX_Dosya_KatilimciId1");

            migrationBuilder.RenameIndex(
                name: "IX_Dosya_IkUygulamaId",
                table: "Dosya",
                newName: "IX_Dosya_IkUygulamaId1");

            migrationBuilder.RenameIndex(
                name: "IX_Dosya_HaberDuyuruId",
                table: "Dosya",
                newName: "IX_Dosya_HaberDuyuruId1");

            migrationBuilder.RenameIndex(
                name: "IX_Dosya_EtkinlikId",
                table: "Dosya",
                newName: "IX_Dosya_EtkinlikId1");

            migrationBuilder.RenameIndex(
                name: "IX_Dosya_EgitimId",
                table: "Dosya",
                newName: "IX_Dosya_EgitimId1");

            migrationBuilder.RenameIndex(
                name: "IX_Dosya_DuzelticiFaaliyetId",
                table: "Dosya",
                newName: "IX_Dosya_DuzelticiFaaliyetId1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SilmeTarihi",
                table: "Dosya",
                type: "Date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SilenKullanici",
                table: "Dosya",
                type: "VarChar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "KayitTarihi",
                table: "Dosya",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "KaydedenKullanici",
                table: "Dosya",
                type: "VarChar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DuzenleyenKullanici",
                table: "Dosya",
                type: "VarChar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DuzenlemeTarihi",
                table: "Dosya",
                type: "Date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "AktifPasif",
                table: "Dosya",
                type: "Bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "Dosya",
                type: "VarChar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_DuzelticiFaaliyet_DuzelticiFaaliyetId1",
                table: "Dosya",
                column: "DuzelticiFaaliyetId1",
                principalTable: "DuzelticiFaaliyet",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_Egitim_EgitimId1",
                table: "Dosya",
                column: "EgitimId1",
                principalTable: "Egitim",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_Etkinlik_EtkinlikId1",
                table: "Dosya",
                column: "EtkinlikId1",
                principalTable: "Etkinlik",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_HaberDuyuru_HaberDuyuruId1",
                table: "Dosya",
                column: "HaberDuyuruId1",
                principalTable: "HaberDuyuru",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_IkUygulama_IkUygulamaId1",
                table: "Dosya",
                column: "IkUygulamaId1",
                principalTable: "IkUygulama",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_Katilimci_KatilimciId1",
                table: "Dosya",
                column: "KatilimciId1",
                principalTable: "Katilimci",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_Mevzuat_MevzuatId1",
                table: "Dosya",
                column: "MevzuatId1",
                principalTable: "Mevzuat",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_Oneri_OneriId1",
                table: "Dosya",
                column: "OneriId1",
                principalTable: "Oneri",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_Rehber_RehberId1",
                table: "Dosya",
                column: "RehberId1",
                principalTable: "Rehber",
                principalColumn: "Id");
        }
    }
}
