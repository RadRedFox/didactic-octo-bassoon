namespace DestifyMovies.Server.Models;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public List<Rating> Ratings { get; set; } = new List<Rating>();
    public List<Actor> Actors { get; set; } = new List<Actor>();

    public Movie() { }

    public Movie(MoviePartial partialMovie)
    {
        Title = partialMovie.Title;

        if (partialMovie.Id != null) { Id = (int)partialMovie.Id; }

    }

    public class MoviePartial
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public List<int>? RatingIds { get; set; }
        public List<int>? ActorIds { get; set; }
    }

    public class RemoveActorRequest
    {
        public int MovieId { get; set; }
        public int ActorId { get; set; }
    }
}
