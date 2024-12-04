using Cinema.Backend.Models.Enums;

namespace Cinema.Backend.Models
{
    public class Screening
    {
        public Guid Id { get; private init; }
        public Movie Movie { get; private init; }
        public CinemaRoom CinemaRoom { get; private init; }

        public List<SeatStatus> Occupancy { get; private set; }

        public DateTime TimeFrom { get; private set; }
        public DateTime TimeTo { get; private set; }
        public int DurationInMinutes => (TimeTo - TimeFrom).Duration().Minutes;

        public VideoTechnology VideoTechnology { get; private set; }
    }
}
