using DestifyMovies.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace DestifyMovies.Server.Contexts;

public class MovieContext : DbContext
{
    protected readonly IConfiguration _configuration;

    public MovieContext(IConfiguration configuration) => _configuration = configuration;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(_configuration.GetConnectionString("MovieDatabase"));

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>()
            .HasData(
                new Movie
                {
                    Id = -1,
                    Title = "Star Wars Episode 7 The Force Awakens"
                },
                new Movie
                {
                    Id = -2,
                    Title = "Star Wars Episode 8 The Last Jedi"
                },
                new Movie
                {
                    Id = -3,
                    Title = "Star Wars Episode 9 The Rise of Skywalker"
                },
                new Movie
                {
                    Id = -4,
                    Title = "Dune Part 1"
                },
                new Movie
                {
                    Id = -5,
                    Title = "Dune Part 2"
                },
                new Movie
                {
                    Id = -6,
                    Title = "Aquaman"
                }
            );

        modelBuilder.Entity<Actor>()
            .HasData(new[]
            {
                new Actor { Id = -1, FirstName = "Daisy", LastName = "Ridley" },
                new Actor { Id = -2, FirstName = "John", LastName = "Boyega" },
                new Actor { Id = -3, FirstName = "Harrison", LastName = "Ford" },
                new Actor { Id = -4, FirstName = "Oscar", LastName = "Isaac" },
                new Actor { Id = -5, FirstName = "Adam", LastName = "Driver" },
                new Actor { Id = -6, FirstName = "Carrie", LastName = "Fisher" },
                new Actor { Id = -7, FirstName = "Mark", LastName = "Hamill" },
                new Actor { Id = -8, FirstName = "Timothee", LastName = "Chalamet" },
                new Actor { Id = -9, FirstName = "Zendaya", LastName = "" },
                new Actor { Id = -10, FirstName = "Rebecca", LastName = "Ferguson" },
                new Actor { Id = -11, FirstName = "Florence", LastName = "Pugh" },
                new Actor { Id = -12, FirstName = "Jason", LastName = "Momoa" },
                new Actor { Id = -13, FirstName = "Josh", LastName = "Brolin" },
                new Actor { Id = -14, FirstName = "Austin", LastName = "Butler" },
                new Actor { Id = -15, FirstName = "Amber", LastName = "Heard" },
                new Actor { Id = -16, FirstName = "Patrick", LastName = "Wilson" },
                new Actor { Id = -17, FirstName = "Nicole", LastName = "Kidman" },
                new Actor { Id = -18, FirstName = "Willem", LastName = "Dafoe" },
                new Actor { Id = -19, FirstName = "Dolph", LastName = "Lundgren" },
                new Actor { Id = -20, FirstName = "Randall", LastName = "Park" },
                new Actor { Id = -21, FirstName = "Michael", LastName = "Beach" },
            });

        modelBuilder.Entity<Rating>()
            .HasData(new [] {
                new Rating { Id = -1, MovieId = -1, Source = "IMDB", Score = 78 },
                new Rating { Id = -2, MovieId = -1, Source = "Rotten Tomatoes", Score = 93 },
                new Rating { Id = -3, MovieId = -1, Source = "Metacritic", Score = 80 },
                new Rating { Id = -4, MovieId = -2, Source = "IMDB", Score = 69 },
                new Rating { Id = -5, MovieId = -2, Source = "Rotten Tomatoes", Score = 91 },
                new Rating { Id = -6, MovieId = -2, Source = "Metacritic", Score = 84 },
                new Rating { Id = -7, MovieId = -3, Source = "IMDB", Score = 64 },
                new Rating { Id = -8, MovieId = -3, Source = "Rotten Tomatoes", Score = 52 },
                new Rating { Id = -9, MovieId = -3, Source = "Metacritic", Score = 53 },
                new Rating { Id = -10, MovieId = -4, Source = "IMDB", Score = 80 },
                new Rating { Id = -11, MovieId = -4, Source = "Rotten Tomatoes", Score = 83 },
                new Rating { Id = -12, MovieId = -4, Source = "Metacritic", Score = 74 },
                new Rating { Id = -13, MovieId = -5, Source = "IMDB", Score = 89 },
                new Rating { Id = -14, MovieId = -5, Source = "Rotten Tomatoes", Score = 93 },
                new Rating { Id = -15, MovieId = -5, Source = "Metacritic", Score = 79 },
                new Rating { Id = -16, MovieId = -6, Source = "IMDB", Score = 68 },
                new Rating { Id = -17, MovieId = -6, Source = "Rotten Tomatoes", Score = 66 },
                new Rating { Id = -18, MovieId = -6, Source = "Metacritic", Score = 55 },
            });

        modelBuilder.Entity<Movie>()
            .HasMany(e => e.Ratings)
            .WithOne(e => e.Movie)
            .HasForeignKey(e => e.MovieId)
            .HasPrincipalKey(e => e.Id);

        modelBuilder.Entity<Movie>()
            .HasMany(e => e.Actors)
            .WithMany(e => e.Movies)
            .UsingEntity(j => j
                .HasData(new[] {
                    new { MoviesId = -1, ActorsId = -1 },
                    new { MoviesId = -1, ActorsId = -2 },
                    new { MoviesId = -1, ActorsId = -3 },
                    new { MoviesId = -1, ActorsId = -4 },
                    new { MoviesId = -1, ActorsId = -5 },
                    new { MoviesId = -1, ActorsId = -6 },
                    new { MoviesId = -1, ActorsId = -7 },
                    new { MoviesId = -2, ActorsId = -1 },
                    new { MoviesId = -2, ActorsId = -3 },
                    new { MoviesId = -2, ActorsId = -4 },
                    new { MoviesId = -2, ActorsId = -5 },
                    new { MoviesId = -2, ActorsId = -6 },
                    new { MoviesId = -2, ActorsId = -7 },
                    new { MoviesId = -3, ActorsId = -1 },
                    new { MoviesId = -3, ActorsId = -3 },
                    new { MoviesId = -3, ActorsId = -4 },
                    new { MoviesId = -3, ActorsId = -5 },
                    new { MoviesId = -3, ActorsId = -6 },
                    new { MoviesId = -3, ActorsId = -7 },
                    new { MoviesId = -4, ActorsId = -8 },
                    new { MoviesId = -4, ActorsId = -9 },
                    new { MoviesId = -4, ActorsId = -10 },
                    new { MoviesId = -4, ActorsId = -11 },
                    new { MoviesId = -4, ActorsId = -12 },
                    new { MoviesId = -4, ActorsId = -13 },
                    new { MoviesId = -4, ActorsId = -14 },
                    new { MoviesId = -5, ActorsId = -8 },
                    new { MoviesId = -5, ActorsId = -9 },
                    new { MoviesId = -5, ActorsId = -10 },
                    new { MoviesId = -5, ActorsId = -11 },
                    new { MoviesId = -5, ActorsId = -13 },
                    new { MoviesId = -5, ActorsId = -14 },
                    new { MoviesId = -6, ActorsId = -12 },
                    new { MoviesId = -6, ActorsId = -15 },
                    new { MoviesId = -6, ActorsId = -16 },
                    new { MoviesId = -6, ActorsId = -17 },
                    new { MoviesId = -6, ActorsId = -18 },
                    new { MoviesId = -6, ActorsId = -19 },
                    new { MoviesId = -6, ActorsId = -20 },
                    new { MoviesId = -6, ActorsId = -21 },
                })
            );

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Rating> Ratings { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Movie> Movies { get; set; }
}
