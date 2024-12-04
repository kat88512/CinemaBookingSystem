using Cinema.Backend.Models.Enums;

namespace Cinema.Backend.Models
{
    public class Screening
    {
        public Guid MovieId { get; private set; }
        public Guid CinemaId { get; private set; }
        public Guid CinemaRoomId { get; private set; }

        public DateTime TimeFrom { get; private set; }
        public DateTime TimeTo { get; private set; }
        public int DurationInMinutes => (TimeTo - TimeFrom).Duration().Minutes;
        public VideoTechnology VideoTechnology { get; private set; }
    }
}
