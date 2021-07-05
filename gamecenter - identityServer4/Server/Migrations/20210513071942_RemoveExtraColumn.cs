using Microsoft.EntityFrameworkCore.Migrations;

namespace gamecenter.Server.Migrations
{
    public partial class RemoveExtraColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamesGenres_Genres_GenreId",
                table: "GamesGenres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GamesGenres",
                table: "GamesGenres");

            migrationBuilder.DropColumn(
                name: "GenresId",
                table: "GamesGenres");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "GamesPeople",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "GenreId",
                table: "GamesGenres",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GamesGenres",
                table: "GamesGenres",
                columns: new[] { "GameId", "GenreId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GamesGenres_Genres_GenreId",
                table: "GamesGenres",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamesGenres_Genres_GenreId",
                table: "GamesGenres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GamesGenres",
                table: "GamesGenres");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "GamesPeople");

            migrationBuilder.AlterColumn<int>(
                name: "GenreId",
                table: "GamesGenres",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "GenresId",
                table: "GamesGenres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GamesGenres",
                table: "GamesGenres",
                columns: new[] { "GameId", "GenresId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GamesGenres_Genres_GenreId",
                table: "GamesGenres",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
