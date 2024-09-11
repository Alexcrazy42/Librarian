using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddOverdueFieldToEdBookStudentRent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOverdue",
                table: "ed_book_student_rent",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOverdue",
                table: "ed_book_student_rent");
        }
    }
}
