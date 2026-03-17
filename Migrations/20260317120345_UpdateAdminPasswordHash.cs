using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OTAKode.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAdminPasswordHash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$yHDKLX7KWEOEhR7XhLpY1O.E.5QQGkPfF6JV.KpSL7cYYxPVqLOL6");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$Dv3aeNe5N5kJnVVy4Kqum.Lq2W0g7EJ8B2nH6mR6kJ7wNL7vGGh0i");
        }
    }
}
