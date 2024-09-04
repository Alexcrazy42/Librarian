using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Store.Db.Migrations
{
    /// <inheritdoc />
    public partial class InitHelpingEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "book_authors",
                columns: new[] { "Id", "full_name" },
                values: new object[,]
                {
                    { new Guid("01715fbe-af4f-4f19-82d1-7e22201fbd26"), "Достоевский Ф.М." },
                    { new Guid("2b0489f0-33db-4085-b45c-d93bd1517ff1"), "Пушкин А.С." }
                });

            migrationBuilder.InsertData(
                table: "book_editors",
                columns: new[] { "Id", "full_name" },
                values: new object[,]
                {
                    { new Guid("10b8b598-e5a4-4633-bb20-056fa10d3863"), "Пушкин А.С." },
                    { new Guid("1aebd275-e6e3-4697-93e3-963dd25d0050"), "Достоевский Ф.М." }
                });

            migrationBuilder.InsertData(
                table: "publishing_houses",
                columns: new[] { "Id", "name" },
                values: new object[,]
                {
                    { new Guid("4616bbb8-68b7-40b8-ab49-72c7bfae2302"), "Просвещение" },
                    { new Guid("e2b4aea0-72eb-4c15-b8df-a2e3a5e7a2ca"), "Издательство" }
                });

            migrationBuilder.InsertData(
                table: "publishing_places",
                columns: new[] { "Id", "name" },
                values: new object[,]
                {
                    { new Guid("a654195a-7289-4671-8442-027e2f3e74e0"), "Москва" },
                    { new Guid("c2ebd291-fb56-4068-9be7-965481c737fd"), "Краснодар" }
                });

            migrationBuilder.InsertData(
                table: "subjects",
                columns: new[] { "Id", "name" },
                values: new object[,]
                {
                    { new Guid("0e07794f-baf8-48aa-9982-7d0c710ec817"), "Математика" },
                    { new Guid("d421fbe4-3638-4e33-ae93-31e77e063a0f"), "Русский язык" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "book_authors",
                keyColumn: "Id",
                keyValue: new Guid("01715fbe-af4f-4f19-82d1-7e22201fbd26"));

            migrationBuilder.DeleteData(
                table: "book_authors",
                keyColumn: "Id",
                keyValue: new Guid("2b0489f0-33db-4085-b45c-d93bd1517ff1"));

            migrationBuilder.DeleteData(
                table: "book_editors",
                keyColumn: "Id",
                keyValue: new Guid("10b8b598-e5a4-4633-bb20-056fa10d3863"));

            migrationBuilder.DeleteData(
                table: "book_editors",
                keyColumn: "Id",
                keyValue: new Guid("1aebd275-e6e3-4697-93e3-963dd25d0050"));

            migrationBuilder.DeleteData(
                table: "publishing_houses",
                keyColumn: "Id",
                keyValue: new Guid("4616bbb8-68b7-40b8-ab49-72c7bfae2302"));

            migrationBuilder.DeleteData(
                table: "publishing_houses",
                keyColumn: "Id",
                keyValue: new Guid("e2b4aea0-72eb-4c15-b8df-a2e3a5e7a2ca"));

            migrationBuilder.DeleteData(
                table: "publishing_places",
                keyColumn: "Id",
                keyValue: new Guid("a654195a-7289-4671-8442-027e2f3e74e0"));

            migrationBuilder.DeleteData(
                table: "publishing_places",
                keyColumn: "Id",
                keyValue: new Guid("c2ebd291-fb56-4068-9be7-965481c737fd"));

            migrationBuilder.DeleteData(
                table: "subjects",
                keyColumn: "Id",
                keyValue: new Guid("0e07794f-baf8-48aa-9982-7d0c710ec817"));

            migrationBuilder.DeleteData(
                table: "subjects",
                keyColumn: "Id",
                keyValue: new Guid("d421fbe4-3638-4e33-ae93-31e77e063a0f"));
        }
    }
}
