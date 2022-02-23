using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class AnketTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SurveyOptions");

            migrationBuilder.DropTable(
                name: "Surveys");

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
                    KaydedenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anket", x => x.Id);
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
                    KaydedenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_AnketSecenek_Fk_AnketId",
                table: "AnketSecenek",
                column: "Fk_AnketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnketSecenek");

            migrationBuilder.DropTable(
                name: "Anket");

            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    SurveyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FeaturedSurvey = table.Column<bool>(type: "bit", nullable: false),
                    SurveyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SurveyQuestion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalTimesTaken = table.Column<int>(type: "int", nullable: false),
                    TotalVotes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.SurveyId);
                });

            migrationBuilder.CreateTable(
                name: "SurveyOptions",
                columns: table => new
                {
                    SurveyOptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Fk_SurveyId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TotalVotes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyOptions", x => x.SurveyOptionId);
                    table.ForeignKey(
                        name: "FK_SurveyOptions_Surveys_Fk_SurveyId",
                        column: x => x.Fk_SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "SurveyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SurveyOptions_Fk_SurveyId",
                table: "SurveyOptions",
                column: "Fk_SurveyId");
        }
    }
}
