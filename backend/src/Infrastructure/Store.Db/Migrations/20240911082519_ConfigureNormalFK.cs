using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Db.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureNormalFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ed_book_student_rent_students_StudentId",
                table: "ed_book_student_rent");

            migrationBuilder.DropForeignKey(
                name: "FK_students_school_grounds_Ground_id",
                table: "students");

            migrationBuilder.RenameColumn(
                name: "Ground_id",
                table: "students",
                newName: "ground_id");

            migrationBuilder.RenameIndex(
                name: "IX_students_Ground_id",
                table: "students",
                newName: "IX_students_ground_id");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "ed_book_student_rent",
                newName: "student_id");

            migrationBuilder.RenameIndex(
                name: "IX_ed_book_student_rent_StudentId",
                table: "ed_book_student_rent",
                newName: "IX_ed_book_student_rent_student_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ed_book_student_rent_students_student_id",
                table: "ed_book_student_rent",
                column: "student_id",
                principalTable: "students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_students_school_grounds_ground_id",
                table: "students",
                column: "ground_id",
                principalTable: "school_grounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ed_book_student_rent_students_student_id",
                table: "ed_book_student_rent");

            migrationBuilder.DropForeignKey(
                name: "FK_students_school_grounds_ground_id",
                table: "students");

            migrationBuilder.RenameColumn(
                name: "ground_id",
                table: "students",
                newName: "Ground_id");

            migrationBuilder.RenameIndex(
                name: "IX_students_ground_id",
                table: "students",
                newName: "IX_students_Ground_id");

            migrationBuilder.RenameColumn(
                name: "student_id",
                table: "ed_book_student_rent",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_ed_book_student_rent_student_id",
                table: "ed_book_student_rent",
                newName: "IX_ed_book_student_rent_StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ed_book_student_rent_students_StudentId",
                table: "ed_book_student_rent",
                column: "StudentId",
                principalTable: "students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_students_school_grounds_Ground_id",
                table: "students",
                column: "Ground_id",
                principalTable: "school_grounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
