using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Db.Migrations
{
    /// <inheritdoc />
    public partial class MakeSupplyFKInEdBookNotRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ed_books_in_balance_book_supplies_supply_id",
                table: "ed_books_in_balance");

            migrationBuilder.AlterColumn<Guid>(
                name: "supply_id",
                table: "ed_books_in_balance",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_ed_books_in_balance_book_supplies_supply_id",
                table: "ed_books_in_balance",
                column: "supply_id",
                principalTable: "book_supplies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ed_books_in_balance_book_supplies_supply_id",
                table: "ed_books_in_balance");

            migrationBuilder.AlterColumn<Guid>(
                name: "supply_id",
                table: "ed_books_in_balance",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ed_books_in_balance_book_supplies_supply_id",
                table: "ed_books_in_balance",
                column: "supply_id",
                principalTable: "book_supplies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
