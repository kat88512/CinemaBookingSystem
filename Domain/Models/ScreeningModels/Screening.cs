using Domain.Models.CinemaModels;
using Domain.Models.MovieModels;

namespace Domain.Models.ScreeningModels
{
    public class Screening
    {
        public Guid Id { get; private init; } = Guid.NewGuid();
        public Movie Movie { get; private init; }
        public CinemaRoom CinemaRoom { get; private init; }
        public DateTime TimeFrom { get; private set; }
        public DateTime TimeTo { get; private set; }
        public int DurationInMinutes => CalculateDurationInMinutes();

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

        private int CalculateDurationInMinutes()
        {
            var duration = (TimeTo - TimeFrom).Duration();
            var minutes = (int)Math.Ceiling(duration.TotalMinutes);

            return minutes;
        }
    }
}
