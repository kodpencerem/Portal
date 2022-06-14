using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class DosyaMdfImageFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_DuzelticiFaaliyet_DuzelticiFaaliyetId",
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
                name: "FK_Dosya_PersonelDurum_PersonelDurumId",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_Rehber_RehberId",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_ToplantiNotu_ToplantiNotuId",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Yorum_Dosya_DosyaId",
                table: "Yorum");

            migrationBuilder.DropForeignKey(
                name: "FK_Yorum_Vidyo_VidyoId",
                table: "Yorum");

            migrationBuilder.DropTable(
                name: "Vidyo");

            migrationBuilder.DropIndex(
                name: "IX_Dosya_DuzelticiFaaliyetId",
                table: "Dosya");

            migrationBuilder.DropIndex(
                name: "IX_Dosya_EtkinlikId",
                table: "Dosya");

            migrationBuilder.DropIndex(
                name: "IX_Dosya_HaberDuyuruId",
                table: "Dosya");

            migrationBuilder.DropIndex(
                name: "IX_Dosya_IkUygulamaId",
                table: "Dosya");

            migrationBuilder.DropIndex(
                name: "IX_Dosya_KatilimciId",
                table: "Dosya");

            migrationBuilder.DropIndex(
                name: "IX_Dosya_MevzuatId",
                table: "Dosya");

            migrationBuilder.DropIndex(
                name: "IX_Dosya_OneriId",
                table: "Dosya");

            migrationBuilder.DropIndex(
                name: "IX_Dosya_PersonelDurumId",
                table: "Dosya");

            migrationBuilder.DropIndex(
                name: "IX_Dosya_RehberId",
                table: "Dosya");

            migrationBuilder.DropIndex(
                name: "IX_Dosya_ToplantiNotuId",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "DuzelticiFaaliyetId",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "EtkinlikId",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "HaberDuyuruId",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "IkUygulamaId",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "KatilimciId",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "MevzuatId",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "OneriId",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "PersonelDurumId",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "RehberId",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "ToplantiNotuId",
                table: "Dosya");

            migrationBuilder.AlterColumn<string>(
                name: "Yolu",
                table: "Dosya",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "KayitTarihi",
                table: "Dosya",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<string>(
                name: "Adi",
                table: "Dosya",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "Dosya",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "VideoUzunluk",
                table: "Dosya",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "ImageFile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AltBaslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yolu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Uzanti = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Boyutu = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Kategori = table.Column<int>(type: "int", nullable: true),
                    AktifPasif = table.Column<bool>(type: "bit", nullable: false),
                    VideoKategori = table.Column<int>(type: "int", nullable: true),
                    Birimler = table.Column<int>(type: "int", nullable: false),
                    HaberDuyuruId = table.Column<int>(type: "int", nullable: true),
                    DuzelticiFaaliyetId = table.Column<int>(type: "int", nullable: true),
                    EtkinlikId = table.Column<int>(type: "int", nullable: true),
                    KatilimciId = table.Column<int>(type: "int", nullable: true),
                    IkUygulamaId = table.Column<int>(type: "int", nullable: true),
                    MevzuatId = table.Column<int>(type: "int", nullable: true),
                    OneriId = table.Column<int>(type: "int", nullable: true),
                    RehberId = table.Column<int>(type: "int", nullable: true),
                    PersonelDurumId = table.Column<int>(type: "int", nullable: true),
                    EgitimId = table.Column<int>(type: "int", nullable: true),
                    ToplantiNotuId = table.Column<int>(type: "int", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KaydedenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SilenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageFile_DuzelticiFaaliyet_DuzelticiFaaliyetId",
                        column: x => x.DuzelticiFaaliyetId,
                        principalTable: "DuzelticiFaaliyet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ImageFile_Egitim_EgitimId",
                        column: x => x.EgitimId,
                        principalTable: "Egitim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ImageFile_Etkinlik_EtkinlikId",
                        column: x => x.EtkinlikId,
                        principalTable: "Etkinlik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ImageFile_HaberDuyuru_HaberDuyuruId",
                        column: x => x.HaberDuyuruId,
                        principalTable: "HaberDuyuru",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ImageFile_IkUygulama_IkUygulamaId",
                        column: x => x.IkUygulamaId,
                        principalTable: "IkUygulama",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ImageFile_Katilimci_KatilimciId",
                        column: x => x.KatilimciId,
                        principalTable: "Katilimci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ImageFile_Mevzuat_MevzuatId",
                        column: x => x.MevzuatId,
                        principalTable: "Mevzuat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ImageFile_Oneri_OneriId",
                        column: x => x.OneriId,
                        principalTable: "Oneri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ImageFile_PersonelDurum_PersonelDurumId",
                        column: x => x.PersonelDurumId,
                        principalTable: "PersonelDurum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ImageFile_Rehber_RehberId",
                        column: x => x.RehberId,
                        principalTable: "Rehber",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ImageFile_ToplantiNotu_ToplantiNotuId",
                        column: x => x.ToplantiNotuId,
                        principalTable: "ToplantiNotu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile_DuzelticiFaaliyetId",
                table: "ImageFile",
                column: "DuzelticiFaaliyetId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile_EgitimId",
                table: "ImageFile",
                column: "EgitimId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile_EtkinlikId",
                table: "ImageFile",
                column: "EtkinlikId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile_HaberDuyuruId",
                table: "ImageFile",
                column: "HaberDuyuruId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile_IkUygulamaId",
                table: "ImageFile",
                column: "IkUygulamaId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile_KatilimciId",
                table: "ImageFile",
                column: "KatilimciId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile_MevzuatId",
                table: "ImageFile",
                column: "MevzuatId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile_OneriId",
                table: "ImageFile",
                column: "OneriId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile_PersonelDurumId",
                table: "ImageFile",
                column: "PersonelDurumId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile_RehberId",
                table: "ImageFile",
                column: "RehberId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile_ToplantiNotuId",
                table: "ImageFile",
                column: "ToplantiNotuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Yorum_Dosya_VidyoId",
                table: "Yorum",
                column: "VidyoId",
                principalTable: "Dosya",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Yorum_ImageFile_DosyaId",
                table: "Yorum",
                column: "DosyaId",
                principalTable: "ImageFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Yorum_Dosya_VidyoId",
                table: "Yorum");

            migrationBuilder.DropForeignKey(
                name: "FK_Yorum_ImageFile_DosyaId",
                table: "Yorum");

            migrationBuilder.DropTable(
                name: "ImageFile");

            migrationBuilder.DropColumn(
                name: "VideoUzunluk",
                table: "Dosya");

            migrationBuilder.AlterColumn<string>(
                name: "Yolu",
                table: "Dosya",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
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
                name: "Adi",
                table: "Dosya",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "Dosya",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DuzelticiFaaliyetId",
                table: "Dosya",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EtkinlikId",
                table: "Dosya",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HaberDuyuruId",
                table: "Dosya",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IkUygulamaId",
                table: "Dosya",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KatilimciId",
                table: "Dosya",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MevzuatId",
                table: "Dosya",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OneriId",
                table: "Dosya",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonelDurumId",
                table: "Dosya",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RehberId",
                table: "Dosya",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ToplantiNotuId",
                table: "Dosya",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Vidyo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AktifPasif = table.Column<bool>(type: "bit", nullable: false),
                    AltBaslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birimler = table.Column<int>(type: "int", nullable: false),
                    Boyutu = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EgitimId = table.Column<int>(type: "int", nullable: true),
                    IzlenmeDurumu = table.Column<bool>(type: "bit", nullable: false),
                    Kategori = table.Column<int>(type: "int", nullable: true),
                    KaydedenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SilenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Uzanti = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoKategori = table.Column<int>(type: "int", nullable: true),
                    VideoUzunluk = table.Column<long>(type: "bigint", nullable: false),
                    Yolu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vidyo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vidyo_Egitim_EgitimId",
                        column: x => x.EgitimId,
                        principalTable: "Egitim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dosya_DuzelticiFaaliyetId",
                table: "Dosya",
                column: "DuzelticiFaaliyetId");

            migrationBuilder.CreateIndex(
                name: "IX_Dosya_EtkinlikId",
                table: "Dosya",
                column: "EtkinlikId");

            migrationBuilder.CreateIndex(
                name: "IX_Dosya_HaberDuyuruId",
                table: "Dosya",
                column: "HaberDuyuruId");

            migrationBuilder.CreateIndex(
                name: "IX_Dosya_IkUygulamaId",
                table: "Dosya",
                column: "IkUygulamaId");

            migrationBuilder.CreateIndex(
                name: "IX_Dosya_KatilimciId",
                table: "Dosya",
                column: "KatilimciId");

            migrationBuilder.CreateIndex(
                name: "IX_Dosya_MevzuatId",
                table: "Dosya",
                column: "MevzuatId");

            migrationBuilder.CreateIndex(
                name: "IX_Dosya_OneriId",
                table: "Dosya",
                column: "OneriId");

            migrationBuilder.CreateIndex(
                name: "IX_Dosya_PersonelDurumId",
                table: "Dosya",
                column: "PersonelDurumId");

            migrationBuilder.CreateIndex(
                name: "IX_Dosya_RehberId",
                table: "Dosya",
                column: "RehberId");

            migrationBuilder.CreateIndex(
                name: "IX_Dosya_ToplantiNotuId",
                table: "Dosya",
                column: "ToplantiNotuId");

            migrationBuilder.CreateIndex(
                name: "IX_Vidyo_EgitimId",
                table: "Vidyo",
                column: "EgitimId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_DuzelticiFaaliyet_DuzelticiFaaliyetId",
                table: "Dosya",
                column: "DuzelticiFaaliyetId",
                principalTable: "DuzelticiFaaliyet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_Etkinlik_EtkinlikId",
                table: "Dosya",
                column: "EtkinlikId",
                principalTable: "Etkinlik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_HaberDuyuru_HaberDuyuruId",
                table: "Dosya",
                column: "HaberDuyuruId",
                principalTable: "HaberDuyuru",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_IkUygulama_IkUygulamaId",
                table: "Dosya",
                column: "IkUygulamaId",
                principalTable: "IkUygulama",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_Katilimci_KatilimciId",
                table: "Dosya",
                column: "KatilimciId",
                principalTable: "Katilimci",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_Mevzuat_MevzuatId",
                table: "Dosya",
                column: "MevzuatId",
                principalTable: "Mevzuat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_Oneri_OneriId",
                table: "Dosya",
                column: "OneriId",
                principalTable: "Oneri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_PersonelDurum_PersonelDurumId",
                table: "Dosya",
                column: "PersonelDurumId",
                principalTable: "PersonelDurum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_Rehber_RehberId",
                table: "Dosya",
                column: "RehberId",
                principalTable: "Rehber",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_ToplantiNotu_ToplantiNotuId",
                table: "Dosya",
                column: "ToplantiNotuId",
                principalTable: "ToplantiNotu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Yorum_Dosya_DosyaId",
                table: "Yorum",
                column: "DosyaId",
                principalTable: "Dosya",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Yorum_Vidyo_VidyoId",
                table: "Yorum",
                column: "VidyoId",
                principalTable: "Vidyo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
