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
                    { "CF001", "Mario", "Rossi" },
                    { "CF002", "Luigi", "Verdi" },
                    { "CF003", "Giovanni", "Bianchi" },
                    { "CF004", "Paolo", "Neri" },
                    { "CF005", "Francesca", "Gialli" },
                    { "CF006", "Anna", "Blu" },
                    { "CF007", "Marco", "Giallo" },
                    { "CF008", "Luca", "Viola" },
                    { "CF009", "Sara", "Rosa" },
                    { "CF010", "Elena", "Marrone" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "CF", "Address", "Name", "Password", "Surname" },
                values: new object[,]
                {
                    { "USER001", "anna.rossi@example.com", "Anna", "Password01!", "Rossi" },
                    { "USER002", "marco.verdi@example.com", "Marco", "Password01!", "Verdi" },
                    { "USER003", "luca.bianchi@example.com", "Luca", "Password01!", "Bianchi" },
                    { "USER004", "sara.neri@example.com", "Sara", "Password01!", "Neri" },
                    { "USER005", "elena.gialli@example.com", "Elena", "Password01!", "Gialli" },
                    { "USER006", "giulia.blu@example.com", "Giulia", "Password01!", "Blu" },
                    { "USER007", "davide.giallo@example.com", "Davide", "Password01!", "Giallo" },
                    { "USER008", "matteo.viola@example.com", "Matteo", "Password01!", "Viola" },
                    { "USER009", "chiara.rosa@example.com", "Chiara", "Password01!", "Rosa" },
                    { "USER010", "federico.marrone@example.com", "Federico", "Password01!", "Marrone" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ISBN", "AuthorCF", "Genre", "IsBooked", "Title" },
                values: new object[,]
                {
                    { 1001, "CF001", "Fantasy", false, "Il Signore degli Anelli" },
                    { 1002, "CF002", "Fantasy", false, "Harry Potter" },
                    { 1003, "CF003", "Thriller", false, "Il Codice Da Vinci" },
                    { 1004, "CF004", "Storico", false, "Il Nome della Rosa" },
                    { 1005, "CF005", "Classico", false, "La Divina Commedia" },
                    { 1006, "CF006", "Distopico", false, "1984" },
                    { 1007, "CF007", "Fiaba", false, "Il Piccolo Principe" },
                    { 1008, "CF008", "Avventura", false, "Moby Dick" },
                    { 1009, "CF009", "Romantico", false, "Orgoglio e Pregiudizio" },
                    { 1010, "CF010", "Storico", false, "Guerra e Pace" }
                });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "Id", "BookISBN", "EndDate", "StartDate", "UserCF" },
                values: new object[,]
                {
                    { 1, 1001, new DateTime(2025, 1, 11, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 22, 12, 0, 0, 0, DateTimeKind.Unspecified), "USER001" },
                    { 2, 1002, new DateTime(2025, 1, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 23, 12, 0, 0, 0, DateTimeKind.Unspecified), "USER002" },
                    { 3, 1003, new DateTime(2025, 1, 13, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 24, 12, 0, 0, 0, DateTimeKind.Unspecified), "USER003" },
                    { 4, 1004, new DateTime(2025, 1, 14, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 25, 12, 0, 0, 0, DateTimeKind.Unspecified), "USER004" },
                    { 5, 1005, new DateTime(2025, 1, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 26, 12, 0, 0, 0, DateTimeKind.Unspecified), "USER005" },
                    { 6, 1006, new DateTime(2025, 1, 16, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 27, 12, 0, 0, 0, DateTimeKind.Unspecified), "USER006" },
                    { 7, 1007, new DateTime(2025, 1, 17, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), "USER007" },
                    { 8, 1008, new DateTime(2025, 1, 18, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 29, 12, 0, 0, 0, DateTimeKind.Unspecified), "USER008" },
                    { 9, 1009, new DateTime(2025, 1, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 30, 12, 0, 0, 0, DateTimeKind.Unspecified), "USER009" },
                    { 10, 1010, new DateTime(2025, 1, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 12, 0, 0, 0, DateTimeKind.Unspecified), "USER010" }
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
