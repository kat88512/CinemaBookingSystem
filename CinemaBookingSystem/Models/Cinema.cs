namespace CinemaBookingSystem.Models
{
    public class Cinema
    {
        public Guid Id { get; private init; } = Guid.NewGuid();
        public string Name { get; private set; } = string.Empty;
        public string City { get; private set; } = string.Empty;

        public Cinema(string name, string city)
        {
            Name = name;
            City = city;
        }
    }
}
