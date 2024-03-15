namespace DestifyMovies.Server.Models;

public class Rating
{
    public int Id { get; set; }
    public string Source { get; set; }
    public int Score { get; set; } = 0;

    public int MovieId { get; set; }
    public virtual Movie Movie { get; set; }

    public Rating() { }

    public Rating(RatingPartial partialRating)
    {
        Source = partialRating.Source ?? "";
        Score = partialRating.Score ?? 0;

        if (partialRating.Id != null) { Id = (int)partialRating.Id; }

        if (partialRating.MovieId != null) { MovieId = (int)partialRating.MovieId; }
    }

    public class RatingPartial
    {
        public int? Id { get; set; }
        public string? Source { get; set; }
        public int? Score { get; set; }

        public int? MovieId { get; set; }
    }
}
