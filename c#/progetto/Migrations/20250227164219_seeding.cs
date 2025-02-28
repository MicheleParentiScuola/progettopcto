using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace progetto.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "CF", "Name", "Surname" },
                values: new object[,]
                {
                    { "A1", "Author1", "Surname1" },
                    { "A2", "Author2", "Surname2" },
                    { "A3", "Author3", "Surname3" },
                    { "A4", "Author4", "Surname4" },
                    { "A5", "Author5", "Surname5" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "CF", "Address", "Name", "Password", "Surname" },
                values: new object[,]
                {
                    { "U1", "Address1", "User1", "Password01!", "Surname1" },
                    { "U2", "Address2", "User2", "Password01!", "Surname2" },
                    { "U3", "Address3", "User3", "Password01!", "Surname3" },
                    { "U4", "Address4", "User4", "Password01!", "Surname4" },
                    { "U5", "Address5", "User5", "Password01!", "Surname5" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ISBN", "AuthorCF", "Genre", "Title" },
                values: new object[,]
                {
                    { 1, "A1", "Genre1", "Book1" },
                    { 2, "A2", "Genre2", "Book2" },
                    { 3, "A3", "Genre3", "Book3" },
                    { 4, "A4", "Genre4", "Book4" },
                    { 5, "A5", "Genre5", "Book5" }
                });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "Id", "BookISBN", "EndDate", "StartDate", "UserCF" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 1, 11, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 22, 12, 0, 0, 0, DateTimeKind.Unspecified), "U1" },
                    { 2, 2, new DateTime(2025, 1, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 23, 12, 0, 0, 0, DateTimeKind.Unspecified), "U2" },
                    { 3, 3, new DateTime(2025, 1, 13, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 24, 12, 0, 0, 0, DateTimeKind.Unspecified), "U3" },
                    { 4, 4, new DateTime(2025, 1, 14, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 25, 12, 0, 0, 0, DateTimeKind.Unspecified), "U4" },
                    { 5, 5, new DateTime(2025, 1, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 26, 12, 0, 0, 0, DateTimeKind.Unspecified), "U5" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "CF",
                keyValue: "U1");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "CF",
                keyValue: "U2");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "CF",
                keyValue: "U3");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "CF",
                keyValue: "U4");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "CF",
                keyValue: "U5");

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "CF",
                keyValue: "A1");

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "CF",
                keyValue: "A2");

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "CF",
                keyValue: "A3");

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "CF",
                keyValue: "A4");

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "CF",
                keyValue: "A5");
        }
    }
}
