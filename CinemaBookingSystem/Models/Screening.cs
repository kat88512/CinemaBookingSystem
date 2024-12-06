using CinemaBookingSystem.Models.Enums;

namespace CinemaBookingSystem.Models
{
    public class Screening
    {
        public Guid Id { get; private init; } = Guid.NewGuid();
        public Movie Movie { get; private init; }
        public Cinema Cinema { get; private init; }
        public CinemaRoom CinemaRoom { get; private init; }
        public ICollection<ScreeningSeat> AvailableSeats { get; private set; }
        public DateTime TimeFrom { get; private set; }
        public DateTime TimeTo { get; private set; }
        public int DurationInMinutes => (TimeTo - TimeFrom).Duration().Minutes;

        public VideoTechnology VideoTechnology { get; private set; }

        public Screening(
            Movie movie,
            Cinema cinema,
            CinemaRoom cinemaRoom,
            DateTime timeFrom,
            DateTime timeTo,
            VideoTechnology videoTechnology = VideoTechnology.TwoDimensional
        )
        {
            Movie = movie;
            Cinema = cinema;
            CinemaRoom = cinemaRoom;
            TimeFrom = timeFrom;
            TimeTo = timeTo;
            VideoTechnology = videoTechnology;
            AvailableSeats = GenerateAvailableSeats();
        }

        private List<ScreeningSeat> GenerateAvailableSeats()
        {
            return CinemaRoom
                .RoomSeats.Select(rs => new ScreeningSeat(Id, rs.Row, rs.Number))
                .ToList();
        }
    }
}
