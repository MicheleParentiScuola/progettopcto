using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace progetto.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    CF = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.CF);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    CF = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.CF);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    ISBN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorCF = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsBooked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.ISBN);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorCF",
                        column: x => x.AuthorCF,
                        principalTable: "Authors",
                        principalColumn: "CF",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookISBN = table.Column<int>(type: "int", nullable: false),
                    UserCF = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loans_Books_BookISBN",
                        column: x => x.BookISBN,
                        principalTable: "Books",
                        principalColumn: "ISBN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Loans_Users_UserCF",
                        column: x => x.UserCF,
                        principalTable: "Users",
                        principalColumn: "CF",
                        onDelete: ReferentialAction.Cascade);
                });

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
                columns: new[] { "ISBN", "AuthorCF", "Genre", "IsBooked", "Title" },
                values: new object[,]
                {
                    { 1, "A1", "Genre1", true, "Book1" },
                    { 2, "A2", "Genre2", false, "Book2" },
                    { 3, "A3", "Genre3", false, "Book3" },
                    { 4, "A4", "Genre4", false, "Book4" },
                    { 5, "A5", "Genre5", false, "Book5" }
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

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorCF",
                table: "Books",
                column: "AuthorCF");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_BookISBN",
                table: "Loans",
                column: "BookISBN");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_UserCF",
                table: "Loans",
                column: "UserCF");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
