using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Wba.MovieRating.Web.Migrations
{
    /// <inheritdoc />
    public partial class seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Firstname", "Lastname" },
                values: new object[,]
                {
                    { 1, "Ryan", "Renolds" },
                    { 2, "Kim", "Basinger" },
                    { 3, "Pamela", "Anderson" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sony" },
                    { 2, "Columbia Pictures" },
                    { 3, "Marvel" }
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "Firstname", "Lastname" },
                values: new object[,]
                {
                    { 1, "Francis F.", "Coppola" },
                    { 2, "Martin", "Scorsese" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Firstname", "Lastname", "Username" },
                values: new object[,]
                {
                    { 1, "Bart", "Soete", null },
                    { 2, "Joachim", "François", null },
                    { 3, "Dries", "Deboosere", null }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CompanyId", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2017, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deadpool" },
                    { 2, 2, new DateTime(2018, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "The suicide squad" },
                    { 3, 3, new DateTime(1972, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "The godfather" }
                });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "Id", "ActorId", "Character", "MovieId" },
                values: new object[,]
                {
                    { 1, 1, "Deadpool", 1 },
                    { 2, 2, "Kim", 1 },
                    { 3, 3, "Pamela", 1 },
                    { 4, 1, "Danny", 2 },
                    { 5, 3, "Pamela", 3 }
                });

            migrationBuilder.InsertData(
                table: "DirectorMovie",
                columns: new[] { "DirectorsId", "MoviesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "MovieId", "UserId", "Score" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 1, 2, 4 },
                    { 1, 3, 3 },
                    { 2, 1, 3 },
                    { 2, 2, 5 },
                    { 2, 3, 2 },
                    { 3, 1, 5 },
                    { 3, 2, 2 },
                    { 3, 3, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ActorMovie",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ActorMovie",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ActorMovie",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ActorMovie",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ActorMovie",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DirectorMovie",
                keyColumns: new[] { "DirectorsId", "MoviesId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "DirectorMovie",
                keyColumns: new[] { "DirectorsId", "MoviesId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "DirectorMovie",
                keyColumns: new[] { "DirectorsId", "MoviesId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumns: new[] { "MovieId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumns: new[] { "MovieId", "UserId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumns: new[] { "MovieId", "UserId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumns: new[] { "MovieId", "UserId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumns: new[] { "MovieId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumns: new[] { "MovieId", "UserId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumns: new[] { "MovieId", "UserId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumns: new[] { "MovieId", "UserId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumns: new[] { "MovieId", "UserId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
