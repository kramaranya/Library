using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: true),
                    GenreId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Books_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Form",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Form", x => new { x.BooksId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_Form_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Form_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, "James", "Patterson" },
                    { 2, "Stephen", "King" },
                    { 3, "Stan", "Lee" },
                    { 4, "John", "Gresham" },
                    { 5, "Danielle", "Steel" },
                    { 6, "Anne", "Rice" },
                    { 7, "Dean", "Koontz" },
                    { 8, "Danielle", "Steel" },
                    { 9, "Nora", "Roberts" },
                    { 10, "Tony", "Morrison" },
                    { 11, "William", "Shakespeare" },
                    { 12, "Agatha", "Christie" },
                    { 13, "Barbara", "Cartland" },
                    { 14, "Kyotaro", "Nishimura" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Poetry" },
                    { 2, "Fiction" },
                    { 3, "Folktale" },
                    { 4, "Drama" },
                    { 5, "Mystery" },
                    { 6, "Detective" },
                    { 7, "Romance" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateOfBirth", "Name", "Password", "PhoneNumber", "Surname", "Username" },
                values: new object[] { 1, new DateTime(1965, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Catherine ", "204jsk", "719-557-7626", "McGinley", "kakdld" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "GenreId", "PublicationDate", "Quantity", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2019, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Shakespeare's Sonnets" },
                    { 2, 1, 1, new DateTime(1985, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Shall I compare thee to a summer's day?" },
                    { 3, 2, 4, new DateTime(1999, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hercule Poirot" },
                    { 4, 2, 4, new DateTime(2014, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Jane Marple" },
                    { 5, 3, 5, new DateTime(1786, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Duel of Hearts" },
                    { 6, 3, 5, new DateTime(1954, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Romantic Royal Marriages" },
                    { 7, 3, 5, new DateTime(1994, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "A Ghost in Monte Carlo" },
                    { 8, 5, 5, new DateTime(1991, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Zoya" },
                    { 9, 5, 5, new DateTime(1832, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sisters" },
                    { 10, 4, 3, new DateTime(2011, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "The Mystery Train Disappears" },
                    { 11, 4, 3, new DateTime(2004, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "Kisei Honsen Satsujin Jiken" },
                    { 12, 6, 4, new DateTime(2022, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Maigret" },
                    { 13, 6, 4, new DateTime(2011, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "The Strange Case of Peter the Lett" },
                    { 14, 7, 5, new DateTime(1992, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Tu pasado me condena" },
                    { 15, 8, 1, new DateTime(2019, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Poltava" },
                    { 16, 8, 1, new DateTime(2016, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "The Gypsies" },
                    { 17, 9, 2, new DateTime(1992, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Frank Merriwell" },
                    { 18, 9, 2, new DateTime(2010, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Boltwood of Yale" },
                    { 19, 10, 2, new DateTime(1845, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Winnetou" },
                    { 20, 10, 2, new DateTime(1905, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "The Oil Prince" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenreId",
                table: "Books",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Form_UsersId",
                table: "Form",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Form");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
