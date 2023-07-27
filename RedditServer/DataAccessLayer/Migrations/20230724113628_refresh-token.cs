using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class refreshtoken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "refresh_token",
                table: "user",
                type: "VARCHAR(100)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "refresh_token_expiration_time",
                table: "user",
                type: "datetimeoffset",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "refresh_token",
                table: "user");

            migrationBuilder.DropColumn(
                name: "refresh_token_expiration_time",
                table: "user");
        }
    }
}
