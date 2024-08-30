using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddSupplies_DecommissioningsAndSomeReports : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "chapter",
                table: "ed_books_in_balance");

            migrationBuilder.AddColumn<Guid>(
                name: "supply_id",
                table: "ed_books_in_balance",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RentReportId",
                table: "ed_book_student_rent",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RentReportId",
                table: "ed_book_employee_rent",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Chapter",
                table: "base_ed_books",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "book_supplies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    supply_date = table.Column<DateOnly>(type: "date", nullable: false),
                    supplier = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    invoice_number = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book_supplies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ed_book_decommissionings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    reason = table.Column<int>(type: "integer", nullable: false),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    ed_book_in_balance_id = table.Column<Guid>(type: "uuid", nullable: false),
                    count = table.Column<int>(type: "integer", nullable: false),
                    inspector_approved = table.Column<bool>(type: "boolean", nullable: false),
                    approved_date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ed_book_decommissionings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ed_book_decommissionings_ed_books_in_balance_ed_book_in_bal~",
                        column: x => x.ed_book_in_balance_id,
                        principalTable: "ed_books_in_balance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "people_rent_reports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    rent_count_classes_1_4 = table.Column<int>(type: "integer", nullable: false),
                    rent_count_classes_5_9 = table.Column<int>(type: "integer", nullable: false),
                    rent_count_classes_10_11 = table.Column<int>(type: "integer", nullable: false),
                    another_rent_count = table.Column<int>(type: "integer", nullable: false),
                    ed_book_rent_count = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    month = table.Column<int>(type: "integer", nullable: true),
                    year = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_people_rent_reports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "people_rent_report_genre_statistics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    people_rent_report_id = table.Column<Guid>(type: "uuid", nullable: false),
                    genre = table.Column<int>(type: "integer", nullable: false),
                    rent_count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_people_rent_report_genre_statistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_people_rent_report_genre_statistics_people_rent_reports_peo~",
                        column: x => x.people_rent_report_id,
                        principalTable: "people_rent_reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ed_books_in_balance_supply_id",
                table: "ed_books_in_balance",
                column: "supply_id");

            migrationBuilder.CreateIndex(
                name: "IX_ed_book_student_rent_RentReportId",
                table: "ed_book_student_rent",
                column: "RentReportId");

            migrationBuilder.CreateIndex(
                name: "IX_ed_book_employee_rent_RentReportId",
                table: "ed_book_employee_rent",
                column: "RentReportId");

            migrationBuilder.CreateIndex(
                name: "IX_ed_book_decommissionings_ed_book_in_balance_id",
                table: "ed_book_decommissionings",
                column: "ed_book_in_balance_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_people_rent_report_genre_statistics_people_rent_report_id",
                table: "people_rent_report_genre_statistics",
                column: "people_rent_report_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ed_book_employee_rent_people_rent_reports_RentReportId",
                table: "ed_book_employee_rent",
                column: "RentReportId",
                principalTable: "people_rent_reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ed_book_student_rent_people_rent_reports_RentReportId",
                table: "ed_book_student_rent",
                column: "RentReportId",
                principalTable: "people_rent_reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ed_books_in_balance_book_supplies_supply_id",
                table: "ed_books_in_balance",
                column: "supply_id",
                principalTable: "book_supplies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ed_book_employee_rent_people_rent_reports_RentReportId",
                table: "ed_book_employee_rent");

            migrationBuilder.DropForeignKey(
                name: "FK_ed_book_student_rent_people_rent_reports_RentReportId",
                table: "ed_book_student_rent");

            migrationBuilder.DropForeignKey(
                name: "FK_ed_books_in_balance_book_supplies_supply_id",
                table: "ed_books_in_balance");

            migrationBuilder.DropTable(
                name: "book_supplies");

            migrationBuilder.DropTable(
                name: "ed_book_decommissionings");

            migrationBuilder.DropTable(
                name: "people_rent_report_genre_statistics");

            migrationBuilder.DropTable(
                name: "people_rent_reports");

            migrationBuilder.DropIndex(
                name: "IX_ed_books_in_balance_supply_id",
                table: "ed_books_in_balance");

            migrationBuilder.DropIndex(
                name: "IX_ed_book_student_rent_RentReportId",
                table: "ed_book_student_rent");

            migrationBuilder.DropIndex(
                name: "IX_ed_book_employee_rent_RentReportId",
                table: "ed_book_employee_rent");

            migrationBuilder.DropColumn(
                name: "supply_id",
                table: "ed_books_in_balance");

            migrationBuilder.DropColumn(
                name: "RentReportId",
                table: "ed_book_student_rent");

            migrationBuilder.DropColumn(
                name: "RentReportId",
                table: "ed_book_employee_rent");

            migrationBuilder.DropColumn(
                name: "Chapter",
                table: "base_ed_books");

            migrationBuilder.AddColumn<int>(
                name: "chapter",
                table: "ed_books_in_balance",
                type: "integer",
                nullable: true);
        }
    }
}
