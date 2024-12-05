namespace Cinema.Backend.Models
{
    public class Cinema
    {
        public Guid Id { get; private init; } = Guid.NewGuid();
        public string Name { get; private set; } = string.Empty;
        public string City { get; private set; } = string.Empty;
        public List<CinemaRoom> CinemaRooms { get; private set; } = [];

        public Cinema(string name, string city)
        {
            Name = name;
            City = city;
        }

        public Cinema(string name, string city, List<CinemaRoom> cinemaRooms)
        {
            Name = name;
            City = city;
            CinemaRooms = cinemaRooms;
        }
    }
}
