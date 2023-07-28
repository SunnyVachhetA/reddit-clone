using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class subreddittable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sub_reddit",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    slug = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    banner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    description = table.Column<string>(type: "VARCHAR(MAX)", nullable: false),
                    status = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1),
                    type = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1),
                    MemberCount = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    updated_on = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sub_reddit", x => x.id);
                    table.ForeignKey(
                        name: "FK_sub_reddit_user_created_by",
                        column: x => x.created_by,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "subreddit_moderator",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    subreddit_id = table.Column<long>(type: "bigint", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    created_on = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    updated_on = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subreddit_moderator", x => x.id);
                    table.ForeignKey(
                        name: "FK_subreddit_moderator_sub_reddit_subreddit_id",
                        column: x => x.subreddit_id,
                        principalTable: "sub_reddit",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_subreddit_moderator_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "subreddit_topic",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    SubRedditId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subreddit_topic", x => x.id);
                    table.ForeignKey(
                        name: "FK_subreddit_topic_sub_reddit_SubRedditId",
                        column: x => x.SubRedditId,
                        principalTable: "sub_reddit",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_sub_reddit_created_by",
                table: "sub_reddit",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "IX_sub_reddit_slug",
                table: "sub_reddit",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_subreddit_moderator_subreddit_id_user_id",
                table: "subreddit_moderator",
                columns: new[] { "subreddit_id", "user_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_subreddit_moderator_user_id",
                table: "subreddit_moderator",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_subreddit_topic_SubRedditId",
                table: "subreddit_topic",
                column: "SubRedditId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "subreddit_moderator");

            migrationBuilder.DropTable(
                name: "subreddit_topic");

            migrationBuilder.DropTable(
                name: "sub_reddit");
        }
    }
}
