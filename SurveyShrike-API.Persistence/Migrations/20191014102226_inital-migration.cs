using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyShrike_API.Persistence.Migrations
{
    public partial class initalmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SurveyShrike_API.Application.Interfaces.IApplicationDBContext.Surveys",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    isDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyShrike_API.Application.Interfaces.IApplicationDBContext.Surveys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SurveyShrike_API.Application.Interfaces.IApplicationDBContext.SurveyFormFields",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    FormTypes = table.Column<int>(nullable: false),
                    FormConfiguration = table.Column<string>(type: "nText", nullable: false),
                    SurveyId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyShrike_API.Application.Interfaces.IApplicationDBContext.SurveyFormFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyShrike_API.Application.Interfaces.IApplicationDBContext.SurveyFormFields_SurveyShrike_API.Application.Interfaces.IApplicationDBContext.Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "SurveyShrike_API.Application.Interfaces.IApplicationDBContext.Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SurveyShrike_API.Application.Interfaces.IApplicationDBContext.SurveyResponses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Response = table.Column<string>(type: "nText", nullable: false),
                    ReportedAt = table.Column<DateTime>(nullable: false),
                    ReportedIP = table.Column<string>(nullable: false),
                    SurveyFormFieldId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyShrike_API.Application.Interfaces.IApplicationDBContext.SurveyResponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyShrike_API.Application.Interfaces.IApplicationDBContext.SurveyResponses_SurveyShrike_API.Application.Interfaces.IApplicationDBContext.SurveyFormFields_SurveyFormFieldId",
                        column: x => x.SurveyFormFieldId,
                        principalTable: "SurveyShrike_API.Application.Interfaces.IApplicationDBContext.SurveyFormFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SurveyShrike_API.Application.Interfaces.IApplicationDBContext.SurveyFormFields_SurveyId",
                table: "SurveyShrike_API.Application.Interfaces.IApplicationDBContext.SurveyFormFields",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyShrike_API.Application.Interfaces.IApplicationDBContext.SurveyResponses_SurveyFormFieldId",
                table: "SurveyShrike_API.Application.Interfaces.IApplicationDBContext.SurveyResponses",
                column: "SurveyFormFieldId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SurveyShrike_API.Application.Interfaces.IApplicationDBContext.SurveyResponses");

            migrationBuilder.DropTable(
                name: "SurveyShrike_API.Application.Interfaces.IApplicationDBContext.SurveyFormFields");

            migrationBuilder.DropTable(
                name: "SurveyShrike_API.Application.Interfaces.IApplicationDBContext.Surveys");
        }
    }
}
