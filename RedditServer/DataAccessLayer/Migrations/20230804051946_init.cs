using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbRedditTopic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbRedditTopic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Username = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "https://firebasestorage.googleapis.com/v0/b/reddit-clone-6a660.appspot.com/o/files%2Fprofile-icon.png?alt=media"),
                    Status = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1),
                    RefreshToken = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    RefreshTokenExpirationTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbSubReddit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Title = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Slug = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "https://firebasestorage.googleapis.com/v0/b/reddit-clone-6a660.appspot.com/o/files%2Fsubreddit.png?alt=media"),
                    Banner = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "https://firebasestorage.googleapis.com/v0/b/reddit-clone-6a660.appspot.com/o/files%2Fbakcground.jpg?alt=media"),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(MAX)", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1),
                    Type = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1),
                    MemberCount = table.Column<long>(type: "bigint", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbSubReddit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbSubReddit_tbUser_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "tbUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbSubRedditModerator",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubRedditId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbSubRedditModerator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbSubRedditModerator_tbSubReddit_SubRedditId",
                        column: x => x.SubRedditId,
                        principalTable: "tbSubReddit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbSubRedditModerator_tbUser_UserId",
                        column: x => x.UserId,
                        principalTable: "tbUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tbSubRedditTopic",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubRedditId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TopicId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbSubRedditTopic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbSubRedditTopic_tbRedditTopic_TopicId",
                        column: x => x.TopicId,
                        principalTable: "tbRedditTopic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbSubRedditTopic_tbSubReddit_SubRedditId",
                        column: x => x.SubRedditId,
                        principalTable: "tbSubReddit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbSubReddit_CreatedById",
                table: "tbSubReddit",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_tbSubReddit_Slug",
                table: "tbSubReddit",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbSubRedditModerator_SubRedditId_UserId",
                table: "tbSubRedditModerator",
                columns: new[] { "SubRedditId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbSubRedditModerator_UserId",
                table: "tbSubRedditModerator",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbSubRedditTopic_SubRedditId",
                table: "tbSubRedditTopic",
                column: "SubRedditId");

            migrationBuilder.CreateIndex(
                name: "IX_tbSubRedditTopic_TopicId_SubRedditId",
                table: "tbSubRedditTopic",
                columns: new[] { "TopicId", "SubRedditId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbUser_Email",
                table: "tbUser",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbUser_Username",
                table: "tbUser",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbSubRedditModerator");

            migrationBuilder.DropTable(
                name: "tbSubRedditTopic");

            migrationBuilder.DropTable(
                name: "tbRedditTopic");

            migrationBuilder.DropTable(
                name: "tbSubReddit");

            migrationBuilder.DropTable(
                name: "tbUser");
        }
    }
}
