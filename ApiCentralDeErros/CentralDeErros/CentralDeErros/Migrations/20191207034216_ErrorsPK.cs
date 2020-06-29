using Microsoft.EntityFrameworkCore.Migrations;

namespace CentralDeErros.Api.Migrations
{
    public partial class ErrorsPK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ERROR_OCCURRENCE_ERROR_ErrorEnvironmentId_ErrorLevelId",
                table: "ERROR_OCCURRENCE");

            migrationBuilder.DropIndex(
                name: "IX_ERROR_OCCURRENCE_ErrorEnvironmentId_ErrorLevelId",
                table: "ERROR_OCCURRENCE");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_ERROR_ID",
                table: "ERROR");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ERROR",
                table: "ERROR");

            migrationBuilder.DropColumn(
                name: "ErrorEnvironmentId",
                table: "ERROR_OCCURRENCE");

            migrationBuilder.DropColumn(
                name: "ErrorLevelId",
                table: "ERROR_OCCURRENCE");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ERROR",
                table: "ERROR",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_ERROR_OCCURRENCE_ErrorId",
                table: "ERROR_OCCURRENCE",
                column: "ErrorId");

            migrationBuilder.CreateIndex(
                name: "IX_ERROR_EnvironmentId",
                table: "ERROR",
                column: "EnvironmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ERROR_OCCURRENCE_ERROR_ErrorId",
                table: "ERROR_OCCURRENCE",
                column: "ErrorId",
                principalTable: "ERROR",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ERROR_OCCURRENCE_ERROR_ErrorId",
                table: "ERROR_OCCURRENCE");

            migrationBuilder.DropIndex(
                name: "IX_ERROR_OCCURRENCE_ErrorId",
                table: "ERROR_OCCURRENCE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ERROR",
                table: "ERROR");

            migrationBuilder.DropIndex(
                name: "IX_ERROR_EnvironmentId",
                table: "ERROR");

            migrationBuilder.AddColumn<int>(
                name: "ErrorEnvironmentId",
                table: "ERROR_OCCURRENCE",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ErrorLevelId",
                table: "ERROR_OCCURRENCE",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ERROR_ID",
                table: "ERROR",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ERROR",
                table: "ERROR",
                columns: new[] { "EnvironmentId", "LevelId" });

            migrationBuilder.CreateIndex(
                name: "IX_ERROR_OCCURRENCE_ErrorEnvironmentId_ErrorLevelId",
                table: "ERROR_OCCURRENCE",
                columns: new[] { "ErrorEnvironmentId", "ErrorLevelId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ERROR_OCCURRENCE_ERROR_ErrorEnvironmentId_ErrorLevelId",
                table: "ERROR_OCCURRENCE",
                columns: new[] { "ErrorEnvironmentId", "ErrorLevelId" },
                principalTable: "ERROR",
                principalColumns: new[] { "EnvironmentId", "LevelId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}