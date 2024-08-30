using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddFKOnSchoolToClassesLibrarians : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_librarians_school_grounds_Ground_id",
                table: "librarians");

            migrationBuilder.DropForeignKey(
                name: "FK_librarians_school_grounds_SchoolGroundId",
                table: "librarians");

            migrationBuilder.DropIndex(
                name: "IX_librarians_SchoolGroundId",
                table: "librarians");

            migrationBuilder.DropColumn(
                name: "SchoolGroundId",
                table: "librarians");

            migrationBuilder.RenameColumn(
                name: "Ground_id",
                table: "librarians",
                newName: "ground_id");

            migrationBuilder.RenameIndex(
                name: "IX_librarians_Ground_id",
                table: "librarians",
                newName: "IX_librarians_ground_id");

            migrationBuilder.AlterColumn<Guid>(
                name: "ground_id",
                table: "librarians",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "school_id",
                table: "librarians",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "school_id",
                table: "classes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_librarians_school_id",
                table: "librarians",
                column: "school_id");

            migrationBuilder.CreateIndex(
                name: "IX_classes_school_id",
                table: "classes",
                column: "school_id");

            migrationBuilder.AddForeignKey(
                name: "FK_classes_schools_school_id",
                table: "classes",
                column: "school_id",
                principalTable: "schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_librarians_school_grounds_ground_id",
                table: "librarians",
                column: "ground_id",
                principalTable: "school_grounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_librarians_schools_school_id",
                table: "librarians",
                column: "school_id",
                principalTable: "schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_classes_schools_school_id",
                table: "classes");

            migrationBuilder.DropForeignKey(
                name: "FK_librarians_school_grounds_ground_id",
                table: "librarians");

            migrationBuilder.DropForeignKey(
                name: "FK_librarians_schools_school_id",
                table: "librarians");

            migrationBuilder.DropIndex(
                name: "IX_librarians_school_id",
                table: "librarians");

            migrationBuilder.DropIndex(
                name: "IX_classes_school_id",
                table: "classes");

            migrationBuilder.DropColumn(
                name: "school_id",
                table: "librarians");

            migrationBuilder.DropColumn(
                name: "school_id",
                table: "classes");

            migrationBuilder.RenameColumn(
                name: "ground_id",
                table: "librarians",
                newName: "Ground_id");

            migrationBuilder.RenameIndex(
                name: "IX_librarians_ground_id",
                table: "librarians",
                newName: "IX_librarians_Ground_id");

            migrationBuilder.AlterColumn<Guid>(
                name: "Ground_id",
                table: "librarians",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "SchoolGroundId",
                table: "librarians",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_librarians_SchoolGroundId",
                table: "librarians",
                column: "SchoolGroundId");

            migrationBuilder.AddForeignKey(
                name: "FK_librarians_school_grounds_Ground_id",
                table: "librarians",
                column: "Ground_id",
                principalTable: "school_grounds",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_librarians_school_grounds_SchoolGroundId",
                table: "librarians",
                column: "SchoolGroundId",
                principalTable: "school_grounds",
                principalColumn: "Id");
        }
    }
}
