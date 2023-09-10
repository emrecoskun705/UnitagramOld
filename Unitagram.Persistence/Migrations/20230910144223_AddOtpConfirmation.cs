using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unitagram.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddOtpConfirmation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OtpConfirmation",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    RetryCount = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)0),
                    RetryDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtpConfirmation", x => new { x.UserId, x.Name });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OtpConfirmation");
        }
    }
}
