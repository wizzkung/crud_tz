using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crud_tz.Migrations
{
    public partial class initials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_issue_Book_bookid",
                table: "Book_issue");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_issue_User_userid",
                table: "Book_issue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Book_issue",
                table: "Book_issue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Book",
                table: "Book");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Book_issue",
                newName: "book_issues");

            migrationBuilder.RenameTable(
                name: "Book",
                newName: "books");

            migrationBuilder.RenameIndex(
                name: "IX_Book_issue_userid",
                table: "book_issues",
                newName: "IX_book_issues_userid");

            migrationBuilder.RenameIndex(
                name: "IX_Book_issue_bookid",
                table: "book_issues",
                newName: "IX_book_issues_bookid");

            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "book_issues",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_book_issues",
                table: "book_issues",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_books",
                table: "books",
                column: "id");

            migrationBuilder.CreateTable(
                name: "returnedBooks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    book_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    date_issued = table.Column<DateTime>(type: "datetime2", nullable: false),
                    due_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_returnedBooks", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "unreturnedBooks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    book_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unreturnedBooks", x => x.id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_book_issues_books_bookid",
                table: "book_issues",
                column: "bookid",
                principalTable: "books",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_book_issues_users_userid",
                table: "book_issues",
                column: "userid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_book_issues_books_bookid",
                table: "book_issues");

            migrationBuilder.DropForeignKey(
                name: "FK_book_issues_users_userid",
                table: "book_issues");

            migrationBuilder.DropTable(
                name: "returnedBooks");

            migrationBuilder.DropTable(
                name: "unreturnedBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_books",
                table: "books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_book_issues",
                table: "book_issues");

            migrationBuilder.DropColumn(
                name: "quantity",
                table: "books");

            migrationBuilder.DropColumn(
                name: "quantity",
                table: "book_issues");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "books",
                newName: "Book");

            migrationBuilder.RenameTable(
                name: "book_issues",
                newName: "Book_issue");

            migrationBuilder.RenameIndex(
                name: "IX_book_issues_userid",
                table: "Book_issue",
                newName: "IX_Book_issue_userid");

            migrationBuilder.RenameIndex(
                name: "IX_book_issues_bookid",
                table: "Book_issue",
                newName: "IX_Book_issue_bookid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book",
                table: "Book",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book_issue",
                table: "Book_issue",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_issue_Book_bookid",
                table: "Book_issue",
                column: "bookid",
                principalTable: "Book",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Book_issue_User_userid",
                table: "Book_issue",
                column: "userid",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
