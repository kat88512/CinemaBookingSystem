using Cinema.Backend.Models.Enums;

namespace Cinema.Backend.Models
{
    public class Screening
    {
        public Guid Id { get; private init; } = Guid.NewGuid();
        public Movie Movie { get; private init; }
        public CinemaRoom CinemaRoom { get; private init; }

        public List<SeatStatus> SeatOccupancy { get; private set; }

        public DateTime TimeFrom { get; private set; }
        public DateTime TimeTo { get; private set; }
        public int DurationInMinutes => (TimeTo - TimeFrom).Duration().Minutes;

        public VideoTechnology VideoTechnology { get; private set; }

        public Screening(
            Movie movie,
            CinemaRoom cinemaRoom,
            DateTime timeFrom,
            DateTime timeTo,
            VideoTechnology videoTechnology = VideoTechnology.TwoDimensional
        )
        {
            Movie = movie;
            CinemaRoom = cinemaRoom;
            SeatOccupancy = cinemaRoom.Seats.Select(s => new SeatStatus(s)).ToList();
            TimeFrom = timeFrom;
            TimeTo = timeTo;
            VideoTechnology = videoTechnology;
        }
    }
}
