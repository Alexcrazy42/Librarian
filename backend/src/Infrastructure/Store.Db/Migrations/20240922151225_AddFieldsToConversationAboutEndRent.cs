using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldsToConversationAboutEndRent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ed_book_school_rents_ed_books_in_balance_ed_book_id",
                table: "ed_book_school_rents");

            migrationBuilder.DropColumn(
                name: "return_date",
                table: "ed_book_school_rents");

            migrationBuilder.RenameColumn(
                name: "start_date",
                table: "ed_book_school_rents",
                newName: "end_rent_at");

            migrationBuilder.RenameColumn(
                name: "ed_book_id",
                table: "ed_book_school_rents",
                newName: "owner_ed_book_id");

            migrationBuilder.RenameColumn(
                name: "closed_by_owner",
                table: "ed_book_school_rents",
                newName: "send_by_debtor");

            migrationBuilder.RenameColumn(
                name: "closed_by_debtor",
                table: "ed_book_school_rents",
                newName: "received_by_owner");

            migrationBuilder.RenameIndex(
                name: "IX_ed_book_school_rents_ed_book_id",
                table: "ed_book_school_rents",
                newName: "IX_ed_book_school_rents_owner_ed_book_id");

            migrationBuilder.AddColumn<DateOnly>(
                name: "ChangeDebtorEndRentAt",
                table: "ed_books_school_rent_request_conversation_messages",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "OwnerReadyToEndRentAt",
                table: "ed_books_school_rent_request_conversation_messages",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "debtor_ed_book_id",
                table: "ed_book_school_rents",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateOnly>(
                name: "end_rent_at",
                table: "ed_book_school_rent_requests",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "owner_ready_to_end_rent_at",
                table: "ed_book_school_rent_requests",
                type: "date",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ed_book_school_rents_debtor_ed_book_id",
                table: "ed_book_school_rents",
                column: "debtor_ed_book_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ed_book_school_rents_ed_books_in_balance_debtor_ed_book_id",
                table: "ed_book_school_rents",
                column: "debtor_ed_book_id",
                principalTable: "ed_books_in_balance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ed_book_school_rents_ed_books_in_balance_owner_ed_book_id",
                table: "ed_book_school_rents",
                column: "owner_ed_book_id",
                principalTable: "ed_books_in_balance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ed_book_school_rents_ed_books_in_balance_debtor_ed_book_id",
                table: "ed_book_school_rents");

            migrationBuilder.DropForeignKey(
                name: "FK_ed_book_school_rents_ed_books_in_balance_owner_ed_book_id",
                table: "ed_book_school_rents");

            migrationBuilder.DropIndex(
                name: "IX_ed_book_school_rents_debtor_ed_book_id",
                table: "ed_book_school_rents");

            migrationBuilder.DropColumn(
                name: "ChangeDebtorEndRentAt",
                table: "ed_books_school_rent_request_conversation_messages");

            migrationBuilder.DropColumn(
                name: "OwnerReadyToEndRentAt",
                table: "ed_books_school_rent_request_conversation_messages");

            migrationBuilder.DropColumn(
                name: "debtor_ed_book_id",
                table: "ed_book_school_rents");

            migrationBuilder.DropColumn(
                name: "end_rent_at",
                table: "ed_book_school_rent_requests");

            migrationBuilder.DropColumn(
                name: "owner_ready_to_end_rent_at",
                table: "ed_book_school_rent_requests");

            migrationBuilder.RenameColumn(
                name: "send_by_debtor",
                table: "ed_book_school_rents",
                newName: "closed_by_owner");

            migrationBuilder.RenameColumn(
                name: "received_by_owner",
                table: "ed_book_school_rents",
                newName: "closed_by_debtor");

            migrationBuilder.RenameColumn(
                name: "owner_ed_book_id",
                table: "ed_book_school_rents",
                newName: "ed_book_id");

            migrationBuilder.RenameColumn(
                name: "end_rent_at",
                table: "ed_book_school_rents",
                newName: "start_date");

            migrationBuilder.RenameIndex(
                name: "IX_ed_book_school_rents_owner_ed_book_id",
                table: "ed_book_school_rents",
                newName: "IX_ed_book_school_rents_ed_book_id");

            migrationBuilder.AddColumn<DateOnly>(
                name: "return_date",
                table: "ed_book_school_rents",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddForeignKey(
                name: "FK_ed_book_school_rents_ed_books_in_balance_ed_book_id",
                table: "ed_book_school_rents",
                column: "ed_book_id",
                principalTable: "ed_books_in_balance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
