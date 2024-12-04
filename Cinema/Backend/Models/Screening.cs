using Cinema.Backend.Models.Enums;

namespace Cinema.Backend.Models
{
    public class Screening
    {
        public Guid Id { get; private init; }
        public Guid MovieId { get; private init; }
        public Guid CinemaId { get; private init; }
        public Guid CinemaRoomId { get; private init; }

        public DateTime TimeFrom { get; private set; }
        public DateTime TimeTo { get; private set; }
        public int DurationInMinutes => (TimeTo - TimeFrom).Duration().Minutes;

        public VideoTechnology VideoTechnology { get; private set; }
        public List<SeatStatus> Occupancy { get; private set; }
    }
}
