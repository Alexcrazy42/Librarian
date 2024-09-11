using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Db.Migrations
{
    /// <inheritdoc />
    public partial class ReturnEdBookToSubjectChapterEdBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassSubjectChapterEdBookEducationalBookInBalance");

            migrationBuilder.AddColumn<Guid>(
                name: "ed_book_in_balance_id",
                table: "class_subject_chapter_ed_books",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_class_subject_chapter_ed_books_ed_book_in_balance_id",
                table: "class_subject_chapter_ed_books",
                column: "ed_book_in_balance_id");

            migrationBuilder.AddForeignKey(
                name: "FK_class_subject_chapter_ed_books_ed_books_in_balance_ed_book_~",
                table: "class_subject_chapter_ed_books",
                column: "ed_book_in_balance_id",
                principalTable: "ed_books_in_balance",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_class_subject_chapter_ed_books_ed_books_in_balance_ed_book_~",
                table: "class_subject_chapter_ed_books");

            migrationBuilder.DropIndex(
                name: "IX_class_subject_chapter_ed_books_ed_book_in_balance_id",
                table: "class_subject_chapter_ed_books");

            migrationBuilder.DropColumn(
                name: "ed_book_in_balance_id",
                table: "class_subject_chapter_ed_books");

            migrationBuilder.CreateTable(
                name: "ClassSubjectChapterEdBookEducationalBookInBalance",
                columns: table => new
                {
                    ClassSubjectChapterEdBookId = table.Column<Guid>(type: "uuid", nullable: false),
                    EdBooksId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassSubjectChapterEdBookEducationalBookInBalance", x => new { x.ClassSubjectChapterEdBookId, x.EdBooksId });
                    table.ForeignKey(
                        name: "FK_ClassSubjectChapterEdBookEducationalBookInBalance_class_sub~",
                        column: x => x.ClassSubjectChapterEdBookId,
                        principalTable: "class_subject_chapter_ed_books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassSubjectChapterEdBookEducationalBookInBalance_ed_books_~",
                        column: x => x.EdBooksId,
                        principalTable: "ed_books_in_balance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubjectChapterEdBookEducationalBookInBalance_EdBooksId",
                table: "ClassSubjectChapterEdBookEducationalBookInBalance",
                column: "EdBooksId");
        }
    }
}
