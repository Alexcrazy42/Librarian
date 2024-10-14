using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Db.Migrations
{
    /// <inheritdoc />
    public partial class UpdateChapterEdBookFromEdBookFromBalanceToBaseEdBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_class_subject_chapter_ed_books_ed_books_in_balance_ed_book_~",
                table: "class_subject_chapter_ed_books");

            migrationBuilder.RenameColumn(
                name: "ed_book_in_balance_id",
                table: "class_subject_chapter_ed_books",
                newName: "base_ed_book_id");

            migrationBuilder.RenameIndex(
                name: "IX_class_subject_chapter_ed_books_ed_book_in_balance_id",
                table: "class_subject_chapter_ed_books",
                newName: "IX_class_subject_chapter_ed_books_base_ed_book_id");

            migrationBuilder.AddForeignKey(
                name: "FK_class_subject_chapter_ed_books_base_ed_books_base_ed_book_id",
                table: "class_subject_chapter_ed_books",
                column: "base_ed_book_id",
                principalTable: "base_ed_books",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_class_subject_chapter_ed_books_base_ed_books_base_ed_book_id",
                table: "class_subject_chapter_ed_books");

            migrationBuilder.RenameColumn(
                name: "base_ed_book_id",
                table: "class_subject_chapter_ed_books",
                newName: "ed_book_in_balance_id");

            migrationBuilder.RenameIndex(
                name: "IX_class_subject_chapter_ed_books_base_ed_book_id",
                table: "class_subject_chapter_ed_books",
                newName: "IX_class_subject_chapter_ed_books_ed_book_in_balance_id");

            migrationBuilder.AddForeignKey(
                name: "FK_class_subject_chapter_ed_books_ed_books_in_balance_ed_book_~",
                table: "class_subject_chapter_ed_books",
                column: "ed_book_in_balance_id",
                principalTable: "ed_books_in_balance",
                principalColumn: "Id");
        }
    }
}
