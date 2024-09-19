using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddIsArchivedFieldToSchoolRentRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ed_books_in_balance_ed_books_in_balance_base_book_id",
                table: "ed_books_in_balance");

            migrationBuilder.RenameColumn(
                name: "base_book_id",
                table: "ed_books_in_balance",
                newName: "book_debtor_school_ground_id");

            migrationBuilder.RenameIndex(
                name: "IX_ed_books_in_balance_base_book_id",
                table: "ed_books_in_balance",
                newName: "IX_ed_books_in_balance_book_debtor_school_ground_id");

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "ed_book_school_rent_requests",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_ed_books_in_balance_school_grounds_book_debtor_school_groun~",
                table: "ed_books_in_balance",
                column: "book_debtor_school_ground_id",
                principalTable: "school_grounds",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ed_books_in_balance_school_grounds_book_debtor_school_groun~",
                table: "ed_books_in_balance");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "ed_book_school_rent_requests");

            migrationBuilder.RenameColumn(
                name: "book_debtor_school_ground_id",
                table: "ed_books_in_balance",
                newName: "base_book_id");

            migrationBuilder.RenameIndex(
                name: "IX_ed_books_in_balance_book_debtor_school_ground_id",
                table: "ed_books_in_balance",
                newName: "IX_ed_books_in_balance_base_book_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ed_books_in_balance_ed_books_in_balance_base_book_id",
                table: "ed_books_in_balance",
                column: "base_book_id",
                principalTable: "ed_books_in_balance",
                principalColumn: "Id");
        }
    }
}
