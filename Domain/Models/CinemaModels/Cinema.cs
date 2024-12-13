namespace Domain.Models.CinemaModels
{
    public class Cinema(string name, string city)
    {
        public Guid Id { get; private init; } = Guid.NewGuid();
        public string Name { get; private set; } = name;
        public string City { get; private set; } = city;
    }
}
