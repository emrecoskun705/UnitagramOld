using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unitagram.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLanguageResource : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LanguageResource",
                table: "LanguageResource");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "LanguageResource");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "LanguageResource",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LanguageResource",
                table: "LanguageResource",
                columns: new[] { "Id", "Source", "SourceKey" });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Culture = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LanguageResource_LanguageId",
                table: "LanguageResource",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_LanguageResource_Language_LanguageId",
                table: "LanguageResource",
                column: "LanguageId",
                principalTable: "Language",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LanguageResource_Language_LanguageId",
                table: "LanguageResource");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LanguageResource",
                table: "LanguageResource");

            migrationBuilder.DropIndex(
                name: "IX_LanguageResource_LanguageId",
                table: "LanguageResource");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "LanguageResource");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "LanguageResource",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LanguageResource",
                table: "LanguageResource",
                columns: new[] { "Id", "Language", "Source", "SourceKey" });
        }
    }
}
