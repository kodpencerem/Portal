using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class DbSetUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    SurveyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurveyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SurveyQuestion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalVotes = table.Column<int>(type: "int", nullable: false),
                    FeaturedSurvey = table.Column<bool>(type: "bit", nullable: false),
                    TotalTimesTaken = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
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
                    Fk_SurveyId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SurveyOptions");

            migrationBuilder.DropTable(
                name: "Surveys");
        }
    }
}
