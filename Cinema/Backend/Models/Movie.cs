namespace Cinema.Backend.Models
{
    public class Movie
    {
        public Guid Id { get; private init; } = Guid.NewGuid();
        public string Name { get; private set; } = string.Empty;
    }
}
