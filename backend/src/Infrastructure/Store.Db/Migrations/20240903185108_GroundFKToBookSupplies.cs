using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Db.Migrations
{
    /// <inheritdoc />
    public partial class GroundFKToBookSupplies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ground_id",
                table: "book_supplies",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "school_id",
                table: "book_supplies",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_book_supplies_ground_id",
                table: "book_supplies",
                column: "ground_id");

            migrationBuilder.CreateIndex(
                name: "IX_book_supplies_school_id",
                table: "book_supplies",
                column: "school_id");

            migrationBuilder.AddForeignKey(
                name: "FK_book_supplies_school_grounds_ground_id",
                table: "book_supplies",
                column: "ground_id",
                principalTable: "school_grounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_book_supplies_schools_school_id",
                table: "book_supplies",
                column: "school_id",
                principalTable: "schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_book_supplies_school_grounds_ground_id",
                table: "book_supplies");

            migrationBuilder.DropForeignKey(
                name: "FK_book_supplies_schools_school_id",
                table: "book_supplies");

            migrationBuilder.DropIndex(
                name: "IX_book_supplies_ground_id",
                table: "book_supplies");

            migrationBuilder.DropIndex(
                name: "IX_book_supplies_school_id",
                table: "book_supplies");

            migrationBuilder.DropColumn(
                name: "ground_id",
                table: "book_supplies");

            migrationBuilder.DropColumn(
                name: "school_id",
                table: "book_supplies");
        }
    }
}
