using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class AddFirstDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AnketSorusu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToplamKatilim = table.Column<int>(type: "int", nullable: false),
                    SecilenAnketMi = table.Column<bool>(type: "bit", nullable: false),
                    ToplamAlinanSure = table.Column<int>(type: "int", nullable: false),
                    AktifPasif = table.Column<bool>(type: "bit", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KaydedenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SilenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anket", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DuzelticiFaaliyet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaaliyetGurupAdi = table.Column<string>(type: "VarChar", nullable: false),
                    IstekFaaliyetKonusu = table.Column<string>(type: "VarChar", nullable: false),
                    Aciklama = table.Column<string>(type: "VarChar", nullable: false),
                    BildirimTarihi = table.Column<DateTime>(type: "Date", nullable: false),
                    AktifPasif = table.Column<bool>(type: "Bit", nullable: false),
                    Kategori = table.Column<byte>(type: "TinyInt", nullable: false),
                    KonuEtiketi = table.Column<string>(type: "VarChar", nullable: false),
                    LokasyonBilgisi = table.Column<string>(type: "VarChar", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "Date", nullable: true),
                    SilmeTarihi = table.Column<DateTime>(type: "Date", nullable: true),
                    KaydedenKullanici = table.Column<string>(type: "VarChar", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "VarChar", nullable: true),
                    SilenKullanici = table.Column<string>(type: "VarChar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuzelticiFaaliyet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Etkinlik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    No = table.Column<int>(type: "Int", nullable: false),
                    Adi = table.Column<string>(type: "VarChar", nullable: false),
                    Aciklama = table.Column<string>(type: "VarChar", nullable: false),
                    BaslangicTarihi = table.Column<DateTime>(type: "Date", nullable: false),
                    BitisTarihi = table.Column<DateTime>(type: "Date", nullable: false),
                    SliderdaGoster = table.Column<bool>(type: "Bit", nullable: false),
                    Kategori = table.Column<byte>(type: "TinyInt", nullable: false),
                    KKategori = table.Column<byte>(type: "TinyInt", nullable: false),
                    AktifPasif = table.Column<bool>(type: "Bit", nullable: false),
                    AnasayfadaGoster = table.Column<bool>(type: "Bit", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "Date", nullable: true),
                    SilmeTarihi = table.Column<DateTime>(type: "Date", nullable: true),
                    KaydedenKullanici = table.Column<string>(type: "VarChar", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "VarChar", nullable: true),
                    SilenKullanici = table.Column<string>(type: "VarChar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etkinlik", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GorevSecenek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GorevAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Oncellik = table.Column<int>(type: "int", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KaydedenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SilenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GorevSecenek", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HaberDuyuru",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    No = table.Column<int>(type: "Int", nullable: false),
                    Adi = table.Column<string>(type: "VarChar", nullable: false),
                    AltBaslik = table.Column<string>(type: "VarChar", nullable: false),
                    Aciklama = table.Column<string>(type: "VarChar", nullable: false),
                    SliderdaGoster = table.Column<bool>(type: "Bit", nullable: false),
                    Kategori = table.Column<byte>(type: "TinyInt", nullable: false),
                    AktifPasif = table.Column<bool>(type: "Bit", nullable: false),
                    AnasayfadaGoster = table.Column<bool>(type: "Bit", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "Date", nullable: true),
                    SilmeTarihi = table.Column<DateTime>(type: "Date", nullable: true),
                    KaydedenKullanici = table.Column<string>(type: "VarChar", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "VarChar", nullable: true),
                    SilenKullanici = table.Column<string>(type: "VarChar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HaberDuyuru", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IkUygulama",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "VarChar", nullable: false),
                    Aciklama = table.Column<string>(type: "VarChar", nullable: false),
                    AktifPasif = table.Column<bool>(type: "bit", nullable: false),
                    Kategori = table.Column<byte>(type: "TinyInt", nullable: false),
                    Birimler = table.Column<byte>(type: "TinyInt", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "Date", nullable: true),
                    SilmeTarihi = table.Column<DateTime>(type: "Date", nullable: true),
                    KaydedenKullanici = table.Column<string>(type: "VarChar", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "VarChar", nullable: true),
                    SilenKullanici = table.Column<string>(type: "VarChar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IkUygulama", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KursVeSertifika",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VerenKurum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaslamaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BitisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GecerlilikSuresi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SertifikaVerilisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SertifikaKodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SertifikaBaslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SertifikaUrlAdres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KaydedenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SilenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KursVeSertifika", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mevzuat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    No = table.Column<int>(type: "int", nullable: false),
                    Adi = table.Column<string>(type: "VarChar", nullable: false),
                    Aciklama = table.Column<string>(type: "VarChar", nullable: false),
                    BaslangicTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BitisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AktifPasif = table.Column<bool>(type: "bit", nullable: false),
                    Kategori = table.Column<byte>(type: "TinyInt", nullable: false),
                    Birimler = table.Column<byte>(type: "TinyInt", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "Date", nullable: true),
                    SilmeTarihi = table.Column<DateTime>(type: "Date", nullable: true),
                    KaydedenKullanici = table.Column<string>(type: "VarChar", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "VarChar", nullable: true),
                    SilenKullanici = table.Column<string>(type: "VarChar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mevzuat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OkulMezunBilgisi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OkulAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaslamaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MezuniyetTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EgitimDurumu = table.Column<int>(type: "int", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KaydedenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SilenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OkulMezunBilgisi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Oneri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "VarChar", nullable: false),
                    Aciklama = table.Column<string>(type: "VarChar", nullable: false),
                    AktifPasif = table.Column<bool>(type: "Bit", nullable: false),
                    KabulDurum = table.Column<bool>(type: "Bit", nullable: false),
                    RedNedeni = table.Column<string>(type: "VarChar", nullable: false),
                    YapanAdiSoyadı = table.Column<string>(type: "VarChar", nullable: false),
                    TelefonNo = table.Column<string>(type: "VarChar", nullable: false),
                    EPosta = table.Column<string>(type: "VarChar", nullable: false),
                    Derece = table.Column<byte>(type: "TinyInt", nullable: false),
                    Odul = table.Column<byte>(type: "TinyInt", nullable: false),
                    Kategori = table.Column<byte>(type: "TinyInt", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "Date", nullable: true),
                    SilmeTarihi = table.Column<DateTime>(type: "Date", nullable: true),
                    KaydedenKullanici = table.Column<string>(type: "VarChar", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "VarChar", nullable: true),
                    SilenKullanici = table.Column<string>(type: "VarChar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oneri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToplantiMerkezi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Adi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Kapasite = table.Column<int>(type: "int", nullable: false),
                    AktifPasif = table.Column<bool>(type: "bit", nullable: false),
                    VideoKonferansMi = table.Column<bool>(type: "bit", nullable: false),
                    RezervDurumu = table.Column<bool>(type: "bit", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KaydedenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SilenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToplantiMerkezi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnketSecenek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_AnketId = table.Column<int>(type: "int", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Resim = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ToplamKatilim = table.Column<int>(type: "int", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KaydedenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SilenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnketSecenek", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnketSecenek_Anket_Fk_AnketId",
                        column: x => x.Fk_AnketId,
                        principalTable: "Anket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Toplanti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserToDoId = table.Column<int>(type: "int", nullable: false),
                    Kod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Konu = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    BaslangicTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BitisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToplantiTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BeklenenKatilimSayisi = table.Column<int>(type: "int", nullable: false),
                    GunAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToplantiNotu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mesaj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoKonferansMi = table.Column<bool>(type: "bit", nullable: false),
                    Renk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AktifPasif = table.Column<bool>(type: "bit", nullable: false),
                    AnaSayfadaGoster = table.Column<bool>(type: "bit", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToplantiMerkeziId = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KaydedenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SilenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toplanti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Toplanti_ToplantiMerkezi_ToplantiMerkeziId",
                        column: x => x.ToplantiMerkeziId,
                        principalTable: "ToplantiMerkezi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ToplantiNotu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "VarChar", nullable: false),
                    AltBaslik = table.Column<string>(type: "VarChar", nullable: false),
                    Konu = table.Column<string>(type: "VarChar", nullable: false),
                    Aciklama = table.Column<string>(type: "VarChar", nullable: false),
                    AktifPasif = table.Column<bool>(type: "Bit", nullable: false),
                    Birimler = table.Column<byte>(type: "TinyInt", nullable: false),
                    ToplantiMerkeziId = table.Column<int>(type: "int", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "Date", nullable: true),
                    SilmeTarihi = table.Column<DateTime>(type: "Date", nullable: true),
                    KaydedenKullanici = table.Column<string>(type: "VarChar", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "VarChar", nullable: true),
                    SilenKullanici = table.Column<string>(type: "VarChar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToplantiNotu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToplantiNotu_ToplantiMerkezi_ToplantiMerkeziId",
                        column: x => x.ToplantiMerkeziId,
                        principalTable: "ToplantiMerkezi",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ToplantiOdasi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Adi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AktifPasif = table.Column<bool>(type: "bit", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kapasite = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    VideoKonferansMi = table.Column<bool>(type: "bit", nullable: false),
                    RezervDurumu = table.Column<bool>(type: "bit", nullable: false),
                    ToplantiMerkeziId = table.Column<int>(type: "int", nullable: true),
                    ToplantiTakvimiId = table.Column<int>(type: "int", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KaydedenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SilenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToplantiOdasi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToplantiOdasi_Toplanti_ToplantiTakvimiId",
                        column: x => x.ToplantiTakvimiId,
                        principalTable: "Toplanti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ToplantiOdasi_ToplantiMerkezi_ToplantiMerkeziId",
                        column: x => x.ToplantiMerkeziId,
                        principalTable: "ToplantiMerkezi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dosya",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "VarChar", nullable: false),
                    Yolu = table.Column<string>(type: "VarChar", nullable: false),
                    Uzanti = table.Column<string>(type: "VarChar", nullable: false),
                    Aciklama = table.Column<string>(type: "VarChar", nullable: false),
                    Boyutu = table.Column<string>(type: "VarChar(30)", maxLength: 30, nullable: true),
                    Kategori = table.Column<byte>(type: "TinyInt", nullable: false),
                    AktifPasif = table.Column<bool>(type: "Bit", nullable: false),
                    EtkinlikId = table.Column<int>(type: "int", nullable: true),
                    DuzelticiFaaliyetId = table.Column<int>(type: "int", nullable: true),
                    HaberDuyuruId = table.Column<int>(type: "int", nullable: true),
                    IKUygulamaId = table.Column<int>(type: "int", nullable: true),
                    MevzuatId = table.Column<int>(type: "int", nullable: true),
                    OneriId = table.Column<int>(type: "int", nullable: true),
                    ToplantiNotuId = table.Column<int>(type: "int", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "Date", nullable: true),
                    SilmeTarihi = table.Column<DateTime>(type: "Date", nullable: true),
                    KaydedenKullanici = table.Column<string>(type: "VarChar", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "VarChar", nullable: true),
                    SilenKullanici = table.Column<string>(type: "VarChar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dosya", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dosya_DuzelticiFaaliyet_DuzelticiFaaliyetId",
                        column: x => x.DuzelticiFaaliyetId,
                        principalTable: "DuzelticiFaaliyet",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Dosya_Etkinlik_EtkinlikId",
                        column: x => x.EtkinlikId,
                        principalTable: "Etkinlik",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Dosya_HaberDuyuru_HaberDuyuruId",
                        column: x => x.HaberDuyuruId,
                        principalTable: "HaberDuyuru",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Dosya_IkUygulama_IKUygulamaId",
                        column: x => x.IKUygulamaId,
                        principalTable: "IkUygulama",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Dosya_Mevzuat_MevzuatId",
                        column: x => x.MevzuatId,
                        principalTable: "Mevzuat",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Dosya_Oneri_OneriId",
                        column: x => x.OneriId,
                        principalTable: "Oneri",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Dosya_ToplantiNotu_ToplantiNotuId",
                        column: x => x.ToplantiNotuId,
                        principalTable: "ToplantiNotu",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Katilimci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdSoyad = table.Column<string>(type: "VarChar", nullable: false),
                    EMail = table.Column<string>(type: "VarChar", nullable: false),
                    TelefonNo = table.Column<string>(type: "VarChar", nullable: false),
                    KatilisDurumu = table.Column<bool>(type: "Bit", nullable: false),
                    KatilisNedeni = table.Column<string>(type: "VarChar", nullable: false),
                    ResimId = table.Column<int>(type: "int", nullable: true),
                    EtkinlikId = table.Column<int>(type: "int", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "Date", nullable: true),
                    SilmeTarihi = table.Column<DateTime>(type: "Date", nullable: true),
                    KaydedenKullanici = table.Column<string>(type: "VarChar", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "VarChar", nullable: true),
                    SilenKullanici = table.Column<string>(type: "VarChar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Katilimci", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Katilimci_Dosya_ResimId",
                        column: x => x.ResimId,
                        principalTable: "Dosya",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Katilimci_Etkinlik_EtkinlikId",
                        column: x => x.EtkinlikId,
                        principalTable: "Etkinlik",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rehber",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfilResmiId = table.Column<int>(type: "int", nullable: true),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Soyadi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unvani = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonNo = table.Column<long>(type: "bigint", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KaydedenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SilenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rehber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rehber_Dosya_ProfilResmiId",
                        column: x => x.ProfilResmiId,
                        principalTable: "Dosya",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DosyaId = table.Column<int>(type: "int", nullable: true),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AltBaslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uzunluk = table.Column<long>(type: "bigint", nullable: false),
                    AktifPasif = table.Column<bool>(type: "bit", nullable: false),
                    IzlenmeDurumu = table.Column<bool>(type: "bit", nullable: false),
                    Kategori = table.Column<int>(type: "int", nullable: false),
                    Birimler = table.Column<int>(type: "int", nullable: false),
                    HaberDuyuruId = table.Column<int>(type: "int", nullable: true),
                    EtkinlikId = table.Column<int>(type: "int", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KaydedenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SilenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Video_Dosya_DosyaId",
                        column: x => x.DosyaId,
                        principalTable: "Dosya",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Video_Etkinlik_EtkinlikId",
                        column: x => x.EtkinlikId,
                        principalTable: "Etkinlik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Video_HaberDuyuru_HaberDuyuruId",
                        column: x => x.HaberDuyuruId,
                        principalTable: "HaberDuyuru",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Egitim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KapakId = table.Column<int>(type: "int", nullable: true),
                    VideoId = table.Column<int>(type: "int", nullable: true),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gereksinim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Egitmen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AktifPasif = table.Column<bool>(type: "bit", nullable: false),
                    ToplamIzlenme = table.Column<long>(type: "bigint", nullable: false),
                    TamamlandiMi = table.Column<bool>(type: "bit", nullable: false),
                    Sertifika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KonuBasligi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToplamUzunluk = table.Column<long>(type: "bigint", nullable: false),
                    KimlereUygun = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kategori = table.Column<int>(type: "int", nullable: false),
                    Birimler = table.Column<int>(type: "int", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KaydedenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SilenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Egitim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Egitim_Dosya_KapakId",
                        column: x => x.KapakId,
                        principalTable: "Dosya",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Egitim_Video_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Video",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VideoYorum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OnaylansınMı = table.Column<bool>(type: "bit", nullable: false),
                    VideoId = table.Column<int>(type: "int", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KaydedenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SilenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoYorum", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideoYorum_Video_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Video",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnketSecenek_Fk_AnketId",
                table: "AnketSecenek",
                column: "Fk_AnketId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "IX_Dosya_IKUygulamaId",
                table: "Dosya",
                column: "IKUygulamaId");

            migrationBuilder.CreateIndex(
                name: "IX_Dosya_MevzuatId",
                table: "Dosya",
                column: "MevzuatId");

            migrationBuilder.CreateIndex(
                name: "IX_Dosya_OneriId",
                table: "Dosya",
                column: "OneriId");

            migrationBuilder.CreateIndex(
                name: "IX_Dosya_ToplantiNotuId",
                table: "Dosya",
                column: "ToplantiNotuId");

            migrationBuilder.CreateIndex(
                name: "IX_Egitim_KapakId",
                table: "Egitim",
                column: "KapakId");

            migrationBuilder.CreateIndex(
                name: "IX_Egitim_VideoId",
                table: "Egitim",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_Etkinlik_No",
                table: "Etkinlik",
                column: "No");

            migrationBuilder.CreateIndex(
                name: "IX_HaberDuyuru_No",
                table: "HaberDuyuru",
                column: "No");

            migrationBuilder.CreateIndex(
                name: "IX_Katilimci_EtkinlikId",
                table: "Katilimci",
                column: "EtkinlikId");

            migrationBuilder.CreateIndex(
                name: "IX_Katilimci_ResimId",
                table: "Katilimci",
                column: "ResimId");

            migrationBuilder.CreateIndex(
                name: "IX_Rehber_ProfilResmiId",
                table: "Rehber",
                column: "ProfilResmiId");

            migrationBuilder.CreateIndex(
                name: "IX_Toplanti_ToplantiMerkeziId",
                table: "Toplanti",
                column: "ToplantiMerkeziId");

            migrationBuilder.CreateIndex(
                name: "IX_ToplantiNotu_ToplantiMerkeziId",
                table: "ToplantiNotu",
                column: "ToplantiMerkeziId");

            migrationBuilder.CreateIndex(
                name: "IX_ToplantiOdasi_ToplantiMerkeziId",
                table: "ToplantiOdasi",
                column: "ToplantiMerkeziId");

            migrationBuilder.CreateIndex(
                name: "IX_ToplantiOdasi_ToplantiTakvimiId",
                table: "ToplantiOdasi",
                column: "ToplantiTakvimiId");

            migrationBuilder.CreateIndex(
                name: "IX_Video_DosyaId",
                table: "Video",
                column: "DosyaId");

            migrationBuilder.CreateIndex(
                name: "IX_Video_EtkinlikId",
                table: "Video",
                column: "EtkinlikId");

            migrationBuilder.CreateIndex(
                name: "IX_Video_HaberDuyuruId",
                table: "Video",
                column: "HaberDuyuruId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoYorum_VideoId",
                table: "VideoYorum",
                column: "VideoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnketSecenek");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Egitim");

            migrationBuilder.DropTable(
                name: "GorevSecenek");

            migrationBuilder.DropTable(
                name: "Katilimci");

            migrationBuilder.DropTable(
                name: "KursVeSertifika");

            migrationBuilder.DropTable(
                name: "OkulMezunBilgisi");

            migrationBuilder.DropTable(
                name: "Rehber");

            migrationBuilder.DropTable(
                name: "ToplantiOdasi");

            migrationBuilder.DropTable(
                name: "VideoYorum");

            migrationBuilder.DropTable(
                name: "Anket");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Toplanti");

            migrationBuilder.DropTable(
                name: "Video");

            migrationBuilder.DropTable(
                name: "Dosya");

            migrationBuilder.DropTable(
                name: "DuzelticiFaaliyet");

            migrationBuilder.DropTable(
                name: "Etkinlik");

            migrationBuilder.DropTable(
                name: "HaberDuyuru");

            migrationBuilder.DropTable(
                name: "IkUygulama");

            migrationBuilder.DropTable(
                name: "Mevzuat");

            migrationBuilder.DropTable(
                name: "Oneri");

            migrationBuilder.DropTable(
                name: "ToplantiNotu");

            migrationBuilder.DropTable(
                name: "ToplantiMerkezi");
        }
    }
}
