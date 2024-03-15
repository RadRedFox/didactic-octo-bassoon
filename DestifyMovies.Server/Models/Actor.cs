namespace DestifyMovies.Server.Models;

public class Actor
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string? LastName { get; set; }

    public List<Movie> Movies { get; set; } = new List<Movie>();

    public Actor() { }

    public Actor(ActorPartial partialActor)
    {
        FirstName = partialActor.FirstName;
        LastName = partialActor.LastName;

        if (partialActor.Id != null) { Id = (int)partialActor.Id; }
    }

    public class ActorPartial
    {
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public List<int>? MovieIds { get; set; }
    }
}
