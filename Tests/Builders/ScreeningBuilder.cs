using Domain.Models.CinemaModels;
using Domain.Models.MovieModels;
using Domain.Models.ScreeningModels;

namespace Tests.Builders
{
    public class ScreeningBuilder
    {
        private Movie Movie { get; set; }
        private CinemaRoom CinemaRoom { get; set; }
        private DateTime TimeFrom { get; set; }
        private DateTime TimeTo { get; set; }
        private VideoTechnology VideoTechnology { get; set; }

        private ScreeningBuilder() { }

        public static ScreeningBuilder Create()
        {
            return new ScreeningBuilder();
        }

        public Screening Build()
        {
            return new Screening(Movie, CinemaRoom, TimeFrom, TimeTo, VideoTechnology);
        }

        public ScreeningBuilder WithDefaultData()
        {
            var tomorrow = DateTime.Now.AddDays(1);

            Movie = new Movie("Test movie name");
            CinemaRoom = new CinemaRoom(Guid.NewGuid(), 1, CinemaRoomType.Large);
            TimeFrom = tomorrow;
            TimeTo = TimeFrom.AddHours(2);
            VideoTechnology = VideoTechnology.TwoDimensional;

            return this;
        }

        public ScreeningBuilder WithTime(DateTime timeFrom, TimeSpan duration)
        {
            TimeFrom = timeFrom;
            TimeTo = timeFrom.Add(duration);

            return this;
        }

        public ScreeningBuilder WithVideoTechnology(VideoTechnology videoTechnology)
        {
            VideoTechnology = videoTechnology;

            return this;
        }
    }
}
