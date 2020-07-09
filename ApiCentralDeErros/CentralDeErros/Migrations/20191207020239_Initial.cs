using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CentralDeErros.Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ENVIRONMENT",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", 
                        SqlServerValueGenerationStrategy.IdentityColumn),
                    ENVIRONMENT = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENVIRONMENT", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LEVEL",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", 
                        SqlServerValueGenerationStrategy.IdentityColumn),
                    LEVEL = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LEVEL", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SITUATION",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", 
                        SqlServerValueGenerationStrategy.IdentityColumn),
                    SITUATION = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SITUATION", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", 
                        SqlServerValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(maxLength: 200, nullable: false),
                    EMAIL = table.Column<string>(maxLength: 200, nullable: false),
                    PASSWORD = table.Column<string>(maxLength: 50, nullable: false),
                    TOKEN = table.Column<string>(maxLength: 400, nullable: true),
                    EXPIRATION = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ERROR",
                columns: table => new
                {
                    EnvironmentId = table.Column<int>(nullable: false),
                    LevelId = table.Column<int>(nullable: false),
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", 
                        SqlServerValueGenerationStrategy.IdentityColumn),
                    CODE = table.Column<int>(nullable: false),
                    TITLE = table.Column<string>(maxLength: 200, nullable: false),
                    DESCRIPTION = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ERROR", x => new { x.EnvironmentId, x.LevelId });
                    table.UniqueConstraint("AK_ERROR_ID", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ERROR_ENVIRONMENT_EnvironmentId",
                        column: x => x.EnvironmentId,
                        principalTable: "ENVIRONMENT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ERROR_LEVEL_LevelId",
                        column: x => x.LevelId,
                        principalTable: "LEVEL",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ERROR_OCCURRENCE",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", 
                        SqlServerValueGenerationStrategy.IdentityColumn),
                    ORIGIN = table.Column<string>(maxLength: 200, nullable: false),
                    DETAILS = table.Column<string>(maxLength: 2000, nullable: false),
                    DATE_TIME = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    ErrorId = table.Column<int>(nullable: false),
                    ErrorEnvironmentId = table.Column<int>(nullable: false),
                    ErrorLevelId = table.Column<int>(nullable: false),
                    SituationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ERROR_OCCURRENCE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ERROR_OCCURRENCE_SITUATION_SituationId",
                        column: x => x.SituationId,
                        principalTable: "SITUATION",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ERROR_OCCURRENCE_USERS_UserId",
                        column: x => x.UserId,
                        principalTable: "USERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ERROR_OCCURRENCE_ERROR_ErrorEnvironmentId_ErrorLevelId",
                        columns: x => new { x.ErrorEnvironmentId, x.ErrorLevelId },
                        principalTable: "ERROR",
                        principalColumns: new[] { "EnvironmentId", "LevelId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ERROR_LevelId",
                table: "ERROR",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_ERROR_OCCURRENCE_SituationId",
                table: "ERROR_OCCURRENCE",
                column: "SituationId");

            migrationBuilder.CreateIndex(
                name: "IX_ERROR_OCCURRENCE_UserId",
                table: "ERROR_OCCURRENCE",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ERROR_OCCURRENCE_ErrorEnvironmentId_ErrorLevelId",
                table: "ERROR_OCCURRENCE",
                columns: new[] { "ErrorEnvironmentId", "ErrorLevelId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ERROR_OCCURRENCE");
            migrationBuilder.DropTable(
                name: "SITUATION");
            migrationBuilder.DropTable(
                name: "USERS");
            migrationBuilder.DropTable(
                name: "ERROR");
            migrationBuilder.DropTable(
                name: "ENVIRONMENT");
            migrationBuilder.DropTable(
                name: "LEVEL");
        }
    }
}