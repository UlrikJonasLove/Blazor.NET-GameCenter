using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace gamecenter.Server.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "NewlyReleases", "Poster", "ReleaseDate", "Summary", "Title", "Trailer" },
                values: new object[,]
                {
                    { 1, false, "Images/Game/RedDeadRedemption.jpg", new DateTime(2011, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "* Red Dead Redemption", "Red Dead Redemption", "" },
                    { 2, true, "Images/Game/RedDeadRedemption-2.jpg", new DateTime(2018, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "* Red Dead Redemption 2", "Red Dead Redemption 2", "SXvQ1nK4oxk" },
                    { 3, false, "Images/Game/LittleNightmares-1.jpg", new DateTime(2017, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "* Little Nightmares", "Little Nightmares", "aOadxZBsPiA" },
                    { 4, true, "Images/Game/LittleNightmares-2.jpg", new DateTime(2021, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "* Little Nightmares 2", "Little Nightmares 2", "AI9zBBTyX-E" },
                    { 5, false, "Images/Game/AssassinsCreed-Odyssey.jpg", new DateTime(2018, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "* Assassins Creed - Odyssey", "Assassins Creed - Odyssey", "s_SJZSAtLBA" },
                    { 6, true, "Images/Game/AssassinsCreed-Valhalla.jpg", new DateTime(2021, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "* Assassins Creed - Valhalla", "Assassins Creed - Valhalla", "z-r2AhqxBzw" },
                    { 7, false, "Images/Game/TheWitcher-WildHunt.jpg", new DateTime(2050, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "* The Witcher 3 - Wild Hunt", "The Witcher 3 - Wild Hunt", "c0i88t0Kacs" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 9, "RPG" },
                    { 8, "Platform" },
                    { 7, "Action" },
                    { 6, "Western" },
                    { 5, "Acient Greek" },
                    { 4, "Norse Mythology" },
                    { 3, "Fantasy" },
                    { 2, "Thriller" },
                    { 1, "Horror" }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Biography", "DateOfBirth", "Name", "Picture" },
                values: new object[,]
                {
                    { 1, "* Ulrik Rosberg", new DateTime(1993, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ulrik Rosberg", "Images/Person/UlrikRosberg.jpg" },
                    { 2, "* Anna Moberg", new DateTime(1998, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anna Moberg", "Images/Person/AnnaMoberg.jpg" },
                    { 3, "* Magnus Bruun", new DateTime(1993, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Magnus Bruun", "Images/Person/MagnusBruun.jpg" },
                    { 4, "* Michael Antanakos", new DateTime(1980, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michael Antonakos", "Images/Person/MichaelAntonakos.jpg" },
                    { 5, "* Roger Clark", new DateTime(1978, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Roger Clark", "Images/Person/RogerClark.jpg" },
                    { 6, "* Robert Wiethoff", new DateTime(1978, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rob Wiethoff", "Images/Person/RobWiethoff.jpg" },
                    { 7, "* Doug Cockle", new DateTime(1978, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doug Cockle", "Images/Person/DougCockle.jpg" }
                });

            migrationBuilder.InsertData(
                table: "GamesGenres",
                columns: new[] { "GameId", "GenreId" },
                values: new object[,]
                {
                    { 3, 1 },
                    { 7, 9 },
                    { 2, 9 },
                    { 1, 9 },
                    { 6, 9 },
                    { 4, 8 },
                    { 3, 8 },
                    { 2, 7 },
                    { 1, 7 },
                    { 2, 6 },
                    { 1, 6 },
                    { 5, 9 },
                    { 6, 4 },
                    { 7, 3 },
                    { 4, 3 },
                    { 3, 3 },
                    { 5, 3 },
                    { 6, 3 },
                    { 4, 2 },
                    { 3, 2 },
                    { 4, 1 },
                    { 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "GamesPeople",
                columns: new[] { "GameId", "PersonId", "Order", "RoleOfGame" },
                values: new object[,]
                {
                    { 1, 6, 1, "John Marston" },
                    { 2, 5, 1, "Arthur Morgan" },
                    { 5, 4, 1, "Alexios" },
                    { 6, 3, 1, "Eivor Wolf-Kissed" },
                    { 4, 2, 1, "Six / Mono" },
                    { 3, 2, 1, "Six" },
                    { 3, 1, 2, "Programmer" },
                    { 6, 1, 2, "Programmer" },
                    { 5, 1, 2, "Programmer" },
                    { 4, 1, 2, "Programmer" },
                    { 2, 1, 3, "Programmer" },
                    { 1, 1, 2, "Programmer" },
                    { 2, 6, 2, "John Marston" },
                    { 7, 1, 2, "Programmer" },
                    { 7, 7, 1, "Geralt of Rivia" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GamesGenres",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "GamesGenres",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "GamesGenres",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 1, 9 });

            migrationBuilder.DeleteData(
                table: "GamesGenres",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "GamesGenres",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "GamesGenres",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 2, 9 });

            migrationBuilder.DeleteData(
                table: "GamesGenres",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "GamesGenres",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "GamesGenres",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "GamesGenres",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 3, 8 });

            migrationBuilder.DeleteData(
                table: "GamesGenres",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "GamesGenres",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "GamesGenres",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "GamesGenres",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 4, 8 });

            migrationBuilder.DeleteData(
                table: "GamesGenres",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "GamesGenres",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "GamesGenres",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 5, 9 });

            migrationBuilder.DeleteData(
                table: "GamesGenres",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "GamesGenres",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "GamesGenres",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 6, 9 });

            migrationBuilder.DeleteData(
                table: "GamesGenres",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "GamesGenres",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 7, 9 });

            migrationBuilder.DeleteData(
                table: "GamesPeople",
                keyColumns: new[] { "GameId", "PersonId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "GamesPeople",
                keyColumns: new[] { "GameId", "PersonId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "GamesPeople",
                keyColumns: new[] { "GameId", "PersonId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "GamesPeople",
                keyColumns: new[] { "GameId", "PersonId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "GamesPeople",
                keyColumns: new[] { "GameId", "PersonId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "GamesPeople",
                keyColumns: new[] { "GameId", "PersonId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "GamesPeople",
                keyColumns: new[] { "GameId", "PersonId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "GamesPeople",
                keyColumns: new[] { "GameId", "PersonId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "GamesPeople",
                keyColumns: new[] { "GameId", "PersonId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "GamesPeople",
                keyColumns: new[] { "GameId", "PersonId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "GamesPeople",
                keyColumns: new[] { "GameId", "PersonId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "GamesPeople",
                keyColumns: new[] { "GameId", "PersonId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "GamesPeople",
                keyColumns: new[] { "GameId", "PersonId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "GamesPeople",
                keyColumns: new[] { "GameId", "PersonId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "GamesPeople",
                keyColumns: new[] { "GameId", "PersonId" },
                keyValues: new object[] { 7, 7 });

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
