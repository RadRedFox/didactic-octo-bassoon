namespace DestifyMovies.Server.Models
{
    public class SearchResults
    {
        public IEnumerable<object> Movies { get; set; } = new List<object>();
        public IEnumerable<object> Actors { get; set; } = new List<object>();
    }
}
