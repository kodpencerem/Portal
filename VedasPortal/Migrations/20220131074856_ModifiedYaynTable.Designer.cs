﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VedasPortal.Data;

namespace VedasPortal.Migrations
{
    [DbContext(typeof(VedasDbContext))]
    [Migration("20220131074856_ModifiedYaynTable")]
    partial class ModifiedYaynTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("VedasPortal.Models.Dokuman.DosyaYukle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DosyaAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("DosyaBoyutu")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("DosyaKategoriId")
                        .HasColumnType("int");

                    b.Property<string>("DosyaTipi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DosyaYolu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DuzenlemeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("DuzenleyenKullanici")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KaydedenKullanici")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("KayitTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("VarsayilanDosyaDegeri")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DosyaKategoriId");

                    b.ToTable("DosyaYuklemeleri");
                });

            modelBuilder.Entity("VedasPortal.Models.DosyaKategori", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DosyaKategoriBilgisi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DuzenlemeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("DuzenleyenKullanici")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KaydedenKullanici")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("KayitTarihi")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("DosyaKategorileri");
                });

            modelBuilder.Entity("VedasPortal.Models.Etkinlik.EtkinlikDurum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("DosyaBoyutu")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("DosyaYolu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DuzenlemeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("DuzenleyenKullanici")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EtkinlikAciklama")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EtkinlikAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EtkinlikBaslangicTarihi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EtkinlikBitisTarihi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EtkinlikNo")
                        .HasColumnType("int");

                    b.Property<string>("EtkinlikResmi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KaydedenKullanici")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("KayitTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("YayinKategoriId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("YayinKategoriId");

                    b.ToTable("EtkinlikDurumlari");
                });

            modelBuilder.Entity("VedasPortal.Models.Rehber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DuzenlemeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("DuzenleyenKullanici")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KaydedenKullanici")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("KayitTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("Soyadi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TelefonNo")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("PersonelRehber");
                });

            modelBuilder.Entity("VedasPortal.Models.YayinDurumlari.Yayin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("AltBaslik")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DosyaYolu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("DuyuruKutusundaOlsunMu")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DuzenlemeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("DuzenleyenKullanici")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HaberKutusundaOlsunMu")
                        .HasColumnType("bit");

                    b.Property<string>("KaydedenKullanici")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("KayitTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("No")
                        .HasColumnType("int");

                    b.Property<bool>("SlideraEklensinMi")
                        .HasColumnType("bit");

                    b.Property<bool>("YayinDurumu")
                        .HasColumnType("bit");

                    b.Property<int>("YayinKategoriId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("YayinKategoriId");

                    b.ToTable("Yayinlar");
                });

            modelBuilder.Entity("VedasPortal.Models.YayinDurumlari.YayinKategori", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DuzenlemeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("DuzenleyenKullanici")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KaydedenKullanici")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("KayitTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("YayinKategoriAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("YayinKategoriDurumu")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("YayinKategorileri");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VedasPortal.Models.Dokuman.DosyaYukle", b =>
                {
                    b.HasOne("VedasPortal.Models.DosyaKategori", "DosyaKategori")
                        .WithMany()
                        .HasForeignKey("DosyaKategoriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DosyaKategori");
                });

            modelBuilder.Entity("VedasPortal.Models.Etkinlik.EtkinlikDurum", b =>
                {
                    b.HasOne("VedasPortal.Models.YayinDurumlari.YayinKategori", "YayinKategori")
                        .WithMany()
                        .HasForeignKey("YayinKategoriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("YayinKategori");
                });

            modelBuilder.Entity("VedasPortal.Models.YayinDurumlari.Yayin", b =>
                {
                    b.HasOne("VedasPortal.Models.YayinDurumlari.YayinKategori", "YayinKategori")
                        .WithMany()
                        .HasForeignKey("YayinKategoriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("YayinKategori");
                });
#pragma warning restore 612, 618
        }
    }
}
