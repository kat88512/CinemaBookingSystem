using Domain.Models.CinemaModels;
using Domain.Models.MovieModels;

namespace Domain.Models.ScreeningModels
{
    public class Screening(
        Movie movie,
        CinemaRoom cinemaRoom,
        DateTime timeFrom,
        DateTime timeTo,
        VideoTechnology videoTechnology = VideoTechnology.TwoDimensional
    )
    {
        public Guid Id { get; private init; } = Guid.NewGuid();
        public Movie Movie { get; private init; } = movie;
        public CinemaRoom CinemaRoom { get; private init; } = cinemaRoom;
        public DateTime TimeFrom { get; private set; } = timeFrom;
        public DateTime TimeTo { get; private set; } = timeTo;
        public int DurationInMinutes => (TimeTo - TimeFrom).Duration().Minutes;

        public VideoTechnology VideoTechnology { get; private set; } = videoTechnology;
    }
}
