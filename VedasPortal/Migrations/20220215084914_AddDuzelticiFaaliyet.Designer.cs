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
    [Migration("20220215084914_AddDuzelticiFaaliyet")]
    partial class AddDuzelticiFaaliyet
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
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

            modelBuilder.Entity("VedasPortal.Models.Dosya.Dosya", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aciklama")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Adi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Boyutu")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime?>("DuzenlemeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("DuzenleyenKullanici")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HaberDuyuruId")
                        .HasColumnType("int");

                    b.Property<string>("KaydedenKullanici")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("KayitTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("Uzanti")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Yolu")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HaberDuyuruId");

                    b.ToTable("Dosya");
                });

            modelBuilder.Entity("VedasPortal.Models.DuzelticiFaaliyet.DuzelticiFaaliyet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("BildirimTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DuzenlemeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("DuzenleyenKullanici")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FaaliyetGurupAdi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("IstekFaaliyetKonusu")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("KaydedenKullanici")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("KayitTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("KonuEtiketi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LokasyonBilgisi")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("ResimId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ResimId");

                    b.ToTable("DuzelticiFaaliyet");
                });

            modelBuilder.Entity("VedasPortal.Models.Etkinlik.Etkinlik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aciklama")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Adi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("AktifPasif")
                        .HasColumnType("bit");

                    b.Property<bool>("AnasayfadaGoster")
                        .HasColumnType("bit");

                    b.Property<string>("BaslangicTarihi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BitisTarihi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DuzenlemeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("DuzenleyenKullanici")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KKategori")
                        .HasColumnType("int");

                    b.Property<int?>("KapakId")
                        .HasColumnType("int");

                    b.Property<int>("Kategori")
                        .HasColumnType("int");

                    b.Property<int?>("KatilimciId")
                        .HasColumnType("int");

                    b.Property<string>("KaydedenKullanici")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("KayitTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("No")
                        .HasColumnType("int");

                    b.Property<bool>("SliderdaGoster")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("KapakId");

                    b.HasIndex("KatilimciId");

                    b.ToTable("Etkinlik");
                });

            modelBuilder.Entity("VedasPortal.Models.Etkinlik.Katilimci", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdSoyad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DuzenlemeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("DuzenleyenKullanici")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EMail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KatilisDurumu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KatilisNedeni")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KaydedenKullanici")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("KayitTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ResimId")
                        .HasColumnType("int");

                    b.Property<string>("TelefonNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ResimId");

                    b.ToTable("Katilimci");
                });

            modelBuilder.Entity("VedasPortal.Models.HaberDuyuru.HaberDuyuru", b =>
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

                    b.Property<bool>("AktifPasif")
                        .HasColumnType("bit");

                    b.Property<string>("AltBaslik")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("AnasayfadaGoster")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DuzenlemeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("DuzenleyenKullanici")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Kategori")
                        .HasColumnType("int");

                    b.Property<string>("KaydedenKullanici")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("KayitTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("No")
                        .HasColumnType("int");

                    b.Property<bool>("SliderdaGoster")
                        .HasColumnType("bit");

                    b.Property<int?>("VideoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VideoId");

                    b.ToTable("HaberDuyuru");
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

                    b.ToTable("Rehber");
                });

            modelBuilder.Entity("VedasPortal.Models.Video.Video", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Baslik")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DosyaId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DuzenlemeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("DuzenleyenKullanici")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KaydedenKullanici")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("KayitTarihi")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DosyaId");

                    b.ToTable("Video");
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

            modelBuilder.Entity("VedasPortal.Models.Dosya.Dosya", b =>
                {
                    b.HasOne("VedasPortal.Models.HaberDuyuru.HaberDuyuru", null)
                        .WithMany("Dosya")
                        .HasForeignKey("HaberDuyuruId");
                });

            modelBuilder.Entity("VedasPortal.Models.DuzelticiFaaliyet.DuzelticiFaaliyet", b =>
                {
                    b.HasOne("VedasPortal.Models.Dosya.Dosya", "Resim")
                        .WithMany()
                        .HasForeignKey("ResimId");

                    b.Navigation("Resim");
                });

            modelBuilder.Entity("VedasPortal.Models.Etkinlik.Etkinlik", b =>
                {
                    b.HasOne("VedasPortal.Models.Dosya.Dosya", "Kapak")
                        .WithMany()
                        .HasForeignKey("KapakId");

                    b.HasOne("VedasPortal.Models.Etkinlik.Katilimci", null)
                        .WithMany("Etkinlikler")
                        .HasForeignKey("KatilimciId");

                    b.Navigation("Kapak");
                });

            modelBuilder.Entity("VedasPortal.Models.Etkinlik.Katilimci", b =>
                {
                    b.HasOne("VedasPortal.Models.Dosya.Dosya", "Resim")
                        .WithMany()
                        .HasForeignKey("ResimId");

                    b.Navigation("Resim");
                });

            modelBuilder.Entity("VedasPortal.Models.HaberDuyuru.HaberDuyuru", b =>
                {
                    b.HasOne("VedasPortal.Models.Video.Video", "Video")
                        .WithMany("HaberDuyuru")
                        .HasForeignKey("VideoId");

                    b.Navigation("Video");
                });

            modelBuilder.Entity("VedasPortal.Models.Video.Video", b =>
                {
                    b.HasOne("VedasPortal.Models.Dosya.Dosya", "Dosya")
                        .WithMany()
                        .HasForeignKey("DosyaId");

                    b.Navigation("Dosya");
                });

            modelBuilder.Entity("VedasPortal.Models.Etkinlik.Katilimci", b =>
                {
                    b.Navigation("Etkinlikler");
                });

            modelBuilder.Entity("VedasPortal.Models.HaberDuyuru.HaberDuyuru", b =>
                {
                    b.Navigation("Dosya");
                });

            modelBuilder.Entity("VedasPortal.Models.Video.Video", b =>
                {
                    b.Navigation("HaberDuyuru");
                });
#pragma warning restore 612, 618
        }
    }
}
