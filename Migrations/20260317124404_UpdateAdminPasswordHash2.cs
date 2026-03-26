using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OTAKode.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAdminPasswordHash2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$zI.u/TjSvtvu0K7eH8XQweeV1xbGQKmJfJRfLSzxQADXBjfF.bQJm");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$yHDKLX7KWEOEhR7XhLpY1O.E.5QQGkPfF6JV.KpSL7cYYxPVqLOL6");
        }
    }
}
