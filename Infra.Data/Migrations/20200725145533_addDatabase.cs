using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CentralDeErros.Infra.Data.Migrations
{
    public partial class addDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ENVIRONMENT",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(maxLength: 200, nullable: false),
                    EMAIL = table.Column<string>(maxLength: 200, nullable: false),
                    PASSWORD = table.Column<string>(maxLength: 50, nullable: false),
                    ROLE = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ERROR",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODE = table.Column<int>(nullable: false),
                    TITLE = table.Column<string>(maxLength: 200, nullable: false),
                    DESCRIPTION = table.Column<string>(maxLength: 200, nullable: false),
                    EnvironmentId = table.Column<int>(nullable: false),
                    LevelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ERROR", x => x.ID);
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRIPTION = table.Column<string>(maxLength: 2000, nullable: false),
                    TITLE = table.Column<string>(maxLength: 2000, nullable: false),
                    EVENTS = table.Column<string>(maxLength: 2000, nullable: false),
                    ARCHIVED = table.Column<bool>(nullable: false),
                    DATE_TIME = table.Column<DateTime>(nullable: false),
                    USERID = table.Column<int>(nullable: false),
                    USER_ID = table.Column<int>(nullable: true),
                    ERRORID = table.Column<int>(nullable: false),
                    ERROR_ID = table.Column<int>(nullable: true),
                    LEVELID = table.Column<int>(nullable: false),
                    LEVEL_ID = table.Column<int>(nullable: true),
                    SituationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ERROR_OCCURRENCE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ERROR_OCCURRENCE_ERROR_ERROR_ID",
                        column: x => x.ERROR_ID,
                        principalTable: "ERROR",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ERROR_OCCURRENCE_LEVEL_LEVEL_ID",
                        column: x => x.LEVEL_ID,
                        principalTable: "LEVEL",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ERROR_OCCURRENCE_SITUATION_SituationId",
                        column: x => x.SituationId,
                        principalTable: "SITUATION",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ERROR_OCCURRENCE_USERS_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ERROR_EnvironmentId",
                table: "ERROR",
                column: "EnvironmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ERROR_LevelId",
                table: "ERROR",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_ERROR_OCCURRENCE_ERROR_ID",
                table: "ERROR_OCCURRENCE",
                column: "ERROR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ERROR_OCCURRENCE_LEVEL_ID",
                table: "ERROR_OCCURRENCE",
                column: "LEVEL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ERROR_OCCURRENCE_SituationId",
                table: "ERROR_OCCURRENCE",
                column: "SituationId");

            migrationBuilder.CreateIndex(
                name: "IX_ERROR_OCCURRENCE_USER_ID",
                table: "ERROR_OCCURRENCE",
                column: "USER_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ERROR_OCCURRENCE");

            migrationBuilder.DropTable(
                name: "ERROR");

            migrationBuilder.DropTable(
                name: "SITUATION");

            migrationBuilder.DropTable(
                name: "USERS");

            migrationBuilder.DropTable(
                name: "ENVIRONMENT");

            migrationBuilder.DropTable(
                name: "LEVEL");
        }
    }
}
