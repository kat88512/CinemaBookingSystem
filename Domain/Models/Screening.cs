using Domain.Models.Enums;

namespace Domain.Models
{
    public class Screening
    {
        public Guid Id { get; private init; } = Guid.NewGuid();
        public Movie Movie { get; private init; }
        public CinemaRoom CinemaRoom { get; private init; }
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
            TimeFrom = timeFrom;
            TimeTo = timeTo;
            VideoTechnology = videoTechnology;
        }
    }
}
