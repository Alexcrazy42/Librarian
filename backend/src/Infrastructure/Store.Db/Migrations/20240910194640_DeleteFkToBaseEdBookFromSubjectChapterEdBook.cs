using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Db.Migrations
{
    /// <inheritdoc />
    public partial class DeleteFkToBaseEdBookFromSubjectChapterEdBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_class_subject_chapter_ed_books_base_ed_books_base_ed_book_id",
                table: "class_subject_chapter_ed_books");

            migrationBuilder.DropIndex(
                name: "IX_class_subject_chapter_ed_books_base_ed_book_id",
                table: "class_subject_chapter_ed_books");

            migrationBuilder.DropColumn(
                name: "base_ed_book_id",
                table: "class_subject_chapter_ed_books");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "base_ed_book_id",
                table: "class_subject_chapter_ed_books",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_class_subject_chapter_ed_books_base_ed_book_id",
                table: "class_subject_chapter_ed_books",
                column: "base_ed_book_id");

            migrationBuilder.AddForeignKey(
                name: "FK_class_subject_chapter_ed_books_base_ed_books_base_ed_book_id",
                table: "class_subject_chapter_ed_books",
                column: "base_ed_book_id",
                principalTable: "base_ed_books",
                principalColumn: "Id");
        }
    }
}
