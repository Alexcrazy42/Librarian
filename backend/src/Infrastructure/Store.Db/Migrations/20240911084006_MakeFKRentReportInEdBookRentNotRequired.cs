using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Db.Migrations
{
    /// <inheritdoc />
    public partial class MakeFKRentReportInEdBookRentNotRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ed_book_student_rent_people_rent_reports_RentReportId",
                table: "ed_book_student_rent");

            migrationBuilder.DropIndex(
                name: "IX_ed_book_student_rent_RentReportId",
                table: "ed_book_student_rent");

            migrationBuilder.DropColumn(
                name: "RentReportId",
                table: "ed_book_student_rent");

            migrationBuilder.AddColumn<Guid>(
                name: "rent_report_id",
                table: "ed_book_student_rent",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ed_book_student_rent_rent_report_id",
                table: "ed_book_student_rent",
                column: "rent_report_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ed_book_student_rent_people_rent_reports_rent_report_id",
                table: "ed_book_student_rent",
                column: "rent_report_id",
                principalTable: "people_rent_reports",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ed_book_student_rent_people_rent_reports_rent_report_id",
                table: "ed_book_student_rent");

            migrationBuilder.DropIndex(
                name: "IX_ed_book_student_rent_rent_report_id",
                table: "ed_book_student_rent");

            migrationBuilder.DropColumn(
                name: "rent_report_id",
                table: "ed_book_student_rent");

            migrationBuilder.AddColumn<Guid>(
                name: "RentReportId",
                table: "ed_book_student_rent",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ed_book_student_rent_RentReportId",
                table: "ed_book_student_rent",
                column: "RentReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_ed_book_student_rent_people_rent_reports_RentReportId",
                table: "ed_book_student_rent",
                column: "RentReportId",
                principalTable: "people_rent_reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
