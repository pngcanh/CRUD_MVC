using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogMVC.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    AuthorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "Char(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.AuthorID);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Descriptions = table.Column<string>(type: "ntext", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "articles",
                columns: table => new
                {
                    ArticleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Content = table.Column<string>(type: "ntext", nullable: false),
                    Created = table.Column<DateTime>(type: "DateTime", nullable: false),
                    CateID = table.Column<int>(type: "int", nullable: false),
                    AuID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articles", x => x.ArticleID);
                    table.ForeignKey(
                        name: "FK_articles_authors_AuID",
                        column: x => x.AuID,
                        principalTable: "authors",
                        principalColumn: "AuthorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_articles_categories_CateID",
                        column: x => x.CateID,
                        principalTable: "categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_articles_AuID",
                table: "articles",
                column: "AuID");

            migrationBuilder.CreateIndex(
                name: "IX_articles_CateID",
                table: "articles",
                column: "CateID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articles");

            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
