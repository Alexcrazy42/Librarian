using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddForUmkAndFullnessAndNeedBookCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_class_subject_chapter_ed_books_base_ed_books_base_ed_book_id",
                table: "class_subject_chapter_ed_books");

            migrationBuilder.DropForeignKey(
                name: "FK_class_subjects_classes_school_class_id",
                table: "class_subjects");

            migrationBuilder.DropIndex(
                name: "IX_class_subject_chapter_ed_books_base_ed_book_id",
                table: "class_subject_chapter_ed_books");

            migrationBuilder.DropColumn(
                name: "base_ed_book_id",
                table: "class_subject_chapter_ed_books");

            migrationBuilder.RenameColumn(
                name: "school_class_id",
                table: "class_subjects",
                newName: "umk_school_class_id");

            migrationBuilder.RenameIndex(
                name: "IX_class_subjects_school_class_id",
                table: "class_subjects",
                newName: "IX_class_subjects_umk_school_class_id");

            migrationBuilder.AddColumn<float>(
                name: "Fullness",
                table: "class_subjects",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "NeedCount",
                table: "class_subjects",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "SchoolClassId",
                table: "class_subjects",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdjustmentCount",
                table: "class_subject_chapters",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Fullness",
                table: "class_subject_chapters",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "NeedCount",
                table: "class_subject_chapters",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalBookCount",
                table: "class_subject_chapters",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ClassSubjectChapterEdBookEducationalBookInBalance",
                columns: table => new
                {
                    ClassSubjectChapterEdBookId = table.Column<Guid>(type: "uuid", nullable: false),
                    EdBooksInBalanceId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassSubjectChapterEdBookEducationalBookInBalance", x => new { x.ClassSubjectChapterEdBookId, x.EdBooksInBalanceId });
                    table.ForeignKey(
                        name: "FK_ClassSubjectChapterEdBookEducationalBookInBalance_class_sub~",
                        column: x => x.ClassSubjectChapterEdBookId,
                        principalTable: "class_subject_chapter_ed_books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassSubjectChapterEdBookEducationalBookInBalance_ed_books_~",
                        column: x => x.EdBooksInBalanceId,
                        principalTable: "ed_books_in_balance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "umk_classes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    school_class_id = table.Column<Guid>(type: "uuid", nullable: false),
                    student_count = table.Column<int>(type: "integer", nullable: false),
                    Fullness = table.Column<float>(type: "real", nullable: false),
                    NeedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_umk_classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_umk_classes_classes_school_class_id",
                        column: x => x.school_class_id,
                        principalTable: "classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_class_subjects_SchoolClassId",
                table: "class_subjects",
                column: "SchoolClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubjectChapterEdBookEducationalBookInBalance_EdBooksIn~",
                table: "ClassSubjectChapterEdBookEducationalBookInBalance",
                column: "EdBooksInBalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_umk_classes_school_class_id",
                table: "umk_classes",
                column: "school_class_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_class_subjects_classes_SchoolClassId",
                table: "class_subjects",
                column: "SchoolClassId",
                principalTable: "classes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_class_subjects_umk_classes_umk_school_class_id",
                table: "class_subjects",
                column: "umk_school_class_id",
                principalTable: "umk_classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_class_subjects_classes_SchoolClassId",
                table: "class_subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_class_subjects_umk_classes_umk_school_class_id",
                table: "class_subjects");

            migrationBuilder.DropTable(
                name: "ClassSubjectChapterEdBookEducationalBookInBalance");

            migrationBuilder.DropTable(
                name: "umk_classes");

            migrationBuilder.DropIndex(
                name: "IX_class_subjects_SchoolClassId",
                table: "class_subjects");

            migrationBuilder.DropColumn(
                name: "Fullness",
                table: "class_subjects");

            migrationBuilder.DropColumn(
                name: "NeedCount",
                table: "class_subjects");

            migrationBuilder.DropColumn(
                name: "SchoolClassId",
                table: "class_subjects");

            migrationBuilder.DropColumn(
                name: "AdjustmentCount",
                table: "class_subject_chapters");

            migrationBuilder.DropColumn(
                name: "Fullness",
                table: "class_subject_chapters");

            migrationBuilder.DropColumn(
                name: "NeedCount",
                table: "class_subject_chapters");

            migrationBuilder.DropColumn(
                name: "TotalBookCount",
                table: "class_subject_chapters");

            migrationBuilder.RenameColumn(
                name: "umk_school_class_id",
                table: "class_subjects",
                newName: "school_class_id");

            migrationBuilder.RenameIndex(
                name: "IX_class_subjects_umk_school_class_id",
                table: "class_subjects",
                newName: "IX_class_subjects_school_class_id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_class_subjects_classes_school_class_id",
                table: "class_subjects",
                column: "school_class_id",
                principalTable: "classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
