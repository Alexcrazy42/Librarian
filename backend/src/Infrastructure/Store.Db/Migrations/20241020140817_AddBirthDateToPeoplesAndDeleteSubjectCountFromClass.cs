using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddBirthDateToPeoplesAndDeleteSubjectCountFromClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubjectCount",
                table: "classes");

            migrationBuilder.AddColumn<DateOnly>(
                name: "BirthDate",
                table: "students",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "BirthDate",
                table: "librarians",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "BirthDate",
                table: "employees",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "students");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "librarians");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "employees");

            migrationBuilder.AddColumn<int>(
                name: "SubjectCount",
                table: "classes",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
