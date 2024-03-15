using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DestifyMovies.Server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActorMovie",
                columns: table => new
                {
                    ActorsId = table.Column<int>(type: "INTEGER", nullable: false),
                    MoviesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorMovie", x => new { x.ActorsId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_ActorMovie_Actors_ActorsId",
                        column: x => x.ActorsId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorMovie_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Source = table.Column<string>(type: "TEXT", nullable: false),
                    Score = table.Column<int>(type: "INTEGER", nullable: false),
                    MovieId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { -21, "Michael", "Beach" });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { -20, "Randall", "Park" });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { -19, "Dolph", "Lundgren" });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { -18, "Willem", "Dafoe" });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { -17, "Nicole", "Kidman" });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { -16, "Patrick", "Wilson" });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { -15, "Amber", "Heard" });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { -14, "Austin", "Butler" });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { -13, "Josh", "Brolin" });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { -12, "Jason", "Momoa" });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { -11, "Florence", "Pugh" });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { -10, "Rebecca", "Ferguson" });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { -9, "Zendaya", "" });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { -8, "Timothee", "Chalamet" });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { -7, "Mark", "Hamill" });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { -6, "Carrie", "Fisher" });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { -5, "Adam", "Driver" });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { -4, "Oscar", "Isaac" });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { -3, "Harrison", "Ford" });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { -2, "John", "Boyega" });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { -1, "Daisy", "Ridley" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Title" },
                values: new object[] { -6, "Aquaman" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Title" },
                values: new object[] { -5, "Dune Part 2" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Title" },
                values: new object[] { -4, "Dune Part 1" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Title" },
                values: new object[] { -3, "Star Wars Episode 9 The Rise of Skywalker" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Title" },
                values: new object[] { -2, "Star Wars Episode 8 The Last Jedi" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Title" },
                values: new object[] { -1, "Star Wars Episode 7 The Force Awakens" });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorsId", "MoviesId" },
                values: new object[] { -21, -6 });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorsId", "MoviesId" },
                values: new object[] { -20, -6 });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorsId", "MoviesId" },
                values: new object[] { -19, -6 });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorsId", "MoviesId" },
                values: new object[] { -18, -6 });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorsId", "MoviesId" },
                values: new object[] { -17, -6 });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorsId", "MoviesId" },
                values: new object[] { -16, -6 });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorsId", "MoviesId" },
                values: new object[] { -15, -6 });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorsId", "MoviesId" },
                values: new object[] { -14, -5 });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorsId", "MoviesId" },
                values: new object[] { -14, -4 });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorsId", "MoviesId" },
                values: new object[] { -13, -5 });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorsId", "MoviesId" },
                values: new object[] { -13, -4 });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorsId", "MoviesId" },
                values: new object[] { -12, -6 });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorsId", "MoviesId" },
                values: new object[] { -12, -4 });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorsId", "MoviesId" },
                values: new object[] { -11, -5 });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorsId", "MoviesId" },
                values: new object[] { -11, -4 });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorsId", "MoviesId" },
                values: new object[] { -10, -5 });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorsId", "MoviesId" },
                values: new object[] { -10, -4 });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorsId", "MoviesId" },
                values: new object[] { -9, -5 });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorsId", "MoviesId" },
                values: new object[] { -9, -4 });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorsId", "MoviesId" },
                values: new object[] { -8, -5 });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorsId", "MoviesId" },
                values: new object[] { -8, -4 });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorsId", "MoviesId" },
                values: new object[] { -7, -3 });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorsId", "MoviesId" },
                values: new object[] { -7, -2 });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorsId", "MoviesId" },
                values: new object[] { -7, -1 });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorsId", "MoviesId" },
                values: new object[] { -6, -3 });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorsId", "MoviesId" },
                values: new object[] { -6, -2 });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorsId", "MoviesId" },
                values: new object[] { -6, -1 });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorsId", "MoviesId" },
                values: new object[] { -5, -3 });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorsId", "MoviesId" },
                values: new object[] { -5, -2 });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorsId", "MoviesId" },
                values: new object[] { -5, -1 });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorsId", "MoviesId" },
                values: new object[] { -4, -3 });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorsId", "MoviesId" },
                values: new object[] { -4, -2 });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorsId", "MoviesId" },
                values: new object[] { -4, -1 });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorsId", "MoviesId" },
                values: new object[] { -3, -3 });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorsId", "MoviesId" },
                values: new object[] { -3, -2 });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorsId", "MoviesId" },
                values: new object[] { -3, -1 });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorsId", "MoviesId" },
                values: new object[] { -2, -1 });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorsId", "MoviesId" },
                values: new object[] { -1, -3 });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorsId", "MoviesId" },
                values: new object[] { -1, -2 });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorsId", "MoviesId" },
                values: new object[] { -1, -1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "MovieId", "Score", "Source" },
                values: new object[] { -18, -6, 55, "Metacritic" });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "MovieId", "Score", "Source" },
                values: new object[] { -17, -6, 66, "Rotten Tomatoes" });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "MovieId", "Score", "Source" },
                values: new object[] { -16, -6, 68, "IMDB" });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "MovieId", "Score", "Source" },
                values: new object[] { -15, -5, 79, "Metacritic" });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "MovieId", "Score", "Source" },
                values: new object[] { -14, -5, 93, "Rotten Tomatoes" });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "MovieId", "Score", "Source" },
                values: new object[] { -13, -5, 89, "IMDB" });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "MovieId", "Score", "Source" },
                values: new object[] { -12, -4, 74, "Metacritic" });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "MovieId", "Score", "Source" },
                values: new object[] { -11, -4, 83, "Rotten Tomatoes" });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "MovieId", "Score", "Source" },
                values: new object[] { -10, -4, 80, "IMDB" });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "MovieId", "Score", "Source" },
                values: new object[] { -9, -3, 53, "Metacritic" });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "MovieId", "Score", "Source" },
                values: new object[] { -8, -3, 52, "Rotten Tomatoes" });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "MovieId", "Score", "Source" },
                values: new object[] { -7, -3, 64, "IMDB" });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "MovieId", "Score", "Source" },
                values: new object[] { -6, -2, 84, "Metacritic" });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "MovieId", "Score", "Source" },
                values: new object[] { -5, -2, 91, "Rotten Tomatoes" });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "MovieId", "Score", "Source" },
                values: new object[] { -4, -2, 69, "IMDB" });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "MovieId", "Score", "Source" },
                values: new object[] { -3, -1, 80, "Metacritic" });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "MovieId", "Score", "Source" },
                values: new object[] { -2, -1, 93, "Rotten Tomatoes" });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "MovieId", "Score", "Source" },
                values: new object[] { -1, -1, 78, "IMDB" });

            migrationBuilder.CreateIndex(
                name: "IX_ActorMovie_MoviesId",
                table: "ActorMovie",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_MovieId",
                table: "Ratings",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorMovie");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
