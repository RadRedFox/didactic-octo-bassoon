using DestifyMovies.Server.Contexts;
using DestifyMovies.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace DestifyMovies.Server.Repositories;

public interface IMovieRepository
{
    public Task<SearchResults> Search(string searchTerm);
    public Task<IEnumerable<object>?> GetMovies();
    public Task<object?> GetMovie(int movieId);
    public Task<object?> AddMovie(Movie.MoviePartial movie);
    public Task<object?> UpdateMovie(Movie.MoviePartial movie);
    public Task<bool> RemoveMovie(int movieId);
    public Task<object?> RemoveActorFromMovie(int movieId, int actorId);
    public Task<IEnumerable<object>?> GetActors();
    public Task<object?> GetActor(int actorId);
    public Task<object?> AddActor(Actor.ActorPartial actor);
    public Task<object?> UpdateActor(Actor.ActorPartial actor);
    public Task<bool> RemoveActor(int actorId);
    public Task<IEnumerable<object>?> GetRatings();
    public Task<object?> GetRating(int ratingId);
    public Task<object?> AddRating(Rating.RatingPartial partialRating);
    public Task<object?> UpdateRating(Rating.RatingPartial partialRating);
    public Task<bool> RemoveRating(int ratingId);
}

public class MovieRepository : IMovieRepository
{
    private readonly IConfiguration _configuration;
    private readonly MovieContext _context;

    public MovieRepository(IConfiguration configuration) {
        _configuration = configuration;
        _context = new MovieContext(configuration);
    }

    public async Task<SearchResults> Search(string searchTerm)
    {
        var lowerSearchTerm = searchTerm.ToLower();
        var movies = await _context.Movies
            .Where(m => m.Title.ToLower().Contains(lowerSearchTerm))
            .Select(m => new {
                m.Id,
                m.Title
            })
            .ToListAsync();
        var actors = await _context.Actors
            .Where(a => a.FirstName.ToLower().Contains(lowerSearchTerm) || a.LastName.ToLower().Contains(lowerSearchTerm))
            .Select(a => new {
                a.Id,
                a.FirstName,
                a.LastName
            })
            .ToListAsync();
    
        return new SearchResults { Actors = actors, Movies = movies };
    }

    public async Task<IEnumerable<object>?> GetMovies()
    {
        var movies = await _context.Movies
            .Select(m => new {
                m.Id,
                m.Title
            })
            .ToListAsync();

        return movies;
    }

    public async Task<object?> GetMovie(int movieId)
    {
        var movie = await _context.Movies
            .Where(m => m.Id == movieId)
            .Include(m => m.Actors)
            .Include(m => m.Ratings)
            .Select(m => new
            {
                m.Id,
                m.Title,
                Ratings = m.Ratings.Select(r => new { r.Id, r.Source, r.Score, r.MovieId }).ToList(),
                Actors = m.Actors.Select(a => new { a.Id, a.FirstName, a.LastName })
            })
            .FirstOrDefaultAsync();

        return movie;
    }

    public async Task<object?> AddMovie(Movie.MoviePartial newMovie)
    {
        var movie = new Movie(newMovie);
        
        await _context.Movies.AddAsync(movie);
        await _context.SaveChangesAsync();

        return new {
            movie.Id,
            movie.Title,
            Ratings = movie.Ratings.Select(r => new {
                r.Id,
                r.Source,
                r.Score
            }),
            Actors = movie.Actors.Select(a => new
            {
                a.Id,
                a.FirstName,
                a.LastName
            })
        };
    }

    public async Task<object?> UpdateMovie(Movie.MoviePartial partialMovie)
    {
        var movie = await _context.Movies.Where(m => m.Id == partialMovie.Id).FirstOrDefaultAsync();

        if (movie == null) return null;

        if (!string.IsNullOrWhiteSpace(partialMovie.Title)) movie.Title = partialMovie.Title;

        _context.Movies.Update(movie);
        await _context.SaveChangesAsync();

        return movie;
    }

    public async Task<bool> RemoveMovie(int movieId)
    {
        var movie = await _context.Movies
            .Where(movie => movie.Id == movieId)
            .Include(movie => movie.Ratings)
            .FirstOrDefaultAsync();

        if (movie == null) return false;

        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<object?> RemoveActorFromMovie(int movieId, int actorId)
    {
        var movie = await _context.Movies
            .Where(movie => movie.Id == movieId)
            .Include(movie => movie.Actors)
            .FirstOrDefaultAsync();

        if (movie == null) return null;

        var actor = movie.Actors
            .Where(actor => actor.Id == actorId)
            .FirstOrDefault();

        if (actor == null) return null;

        movie.Actors.Remove(actor);

        await _context.SaveChangesAsync();

        return movie;
    }

    public async Task<IEnumerable<object>?> GetActors()
    {
        var actors = await _context.Actors
            .Select(a => new {
                a.Id,
                a.FirstName,
                a.LastName
            })
            .ToListAsync();

        return actors;
    }

    public async Task<object?> GetActor(int actorId)
    {
        var actor = await _context.Actors
            .Where(a => a.Id == actorId)
            .Include(a => a.Movies)
            .Select(a => new {
                a.Id,
                a.FirstName,
                a.LastName,
                Movies = a.Movies.Select(m => new {
                    m.Id,
                    m.Title
                })
            })
            .FirstOrDefaultAsync();

        return actor;
    }

    public async Task<object?> AddActor(Actor.ActorPartial newActor)
    {
        var actor = new Actor(newActor);

        await _context.Actors.AddAsync(actor);
        await _context.SaveChangesAsync();

        return new
        {
            actor.Id,
            actor.FirstName,
            actor.LastName
        };
    }

    public async Task<object?> UpdateActor(Actor.ActorPartial partialActor)
    {
        var actor = await _context.Actors.Where(actor => actor.Id == partialActor.Id).FirstOrDefaultAsync();

        if (actor == null) return null;

        if (!string.IsNullOrWhiteSpace(partialActor.FirstName)) actor.FirstName = partialActor.FirstName;

        if (!string.IsNullOrWhiteSpace(partialActor.LastName)) actor.LastName = partialActor.LastName;

        _context.Actors.Update(actor);
        await _context.SaveChangesAsync();

        return actor;
    }

    public async Task<bool> RemoveActor(int actorId)
    {
        var actor = await _context.Actors
            .Where(actor => actor.Id == actorId)
            .FirstOrDefaultAsync();

        if (actor == null) return false;

        _context.Actors.Remove(actor);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<IEnumerable<object>?> GetRatings()
    {
        var ratings = await _context.Ratings
            .Select(r => new {
                r.Id,
                r.Source,
                r.Score
            })
            .ToListAsync();

        return ratings;
    }

    public async Task<object?> GetRating(int ratingId)
    {
        var rating = await _context.Ratings
            .Where(r => r.Id == ratingId)
            .Select(r => new {
                r.Id,
                r.Source,
                r.Score,
                Movie = new
                {
                    r.Movie.Id,
                    r.Movie.Title
                }
            })
            .FirstOrDefaultAsync();

        return rating;
    }

    public async Task<object?> AddRating(Rating.RatingPartial partialRating)
    {
        var rating = new Rating(partialRating);

        await _context.Ratings.AddAsync(rating);
        await _context.SaveChangesAsync();

        return rating;
    }

    public async Task<object?> UpdateRating(Rating.RatingPartial partialRating)
    {
        var rating = await _context.Ratings.Where(rating => rating.Id == partialRating.Id).FirstOrDefaultAsync();

        if (rating == null) return null;

        if (!string.IsNullOrWhiteSpace(partialRating.Source)) rating.Source = partialRating.Source;

        if (partialRating.Score != null) rating.Score = (int)partialRating.Score;

        _context.Ratings.Update(rating);
        await _context.SaveChangesAsync();

        return rating;
    }

    public async Task<bool> RemoveRating(int ratingId)
    {
        var rating = await _context.Ratings
            .Where(rating => rating.Id == ratingId)
            .FirstOrDefaultAsync();

        if (rating == null) return false;

        _context.Ratings.Remove(rating);
        await _context.SaveChangesAsync();

        return true;
    }
}
