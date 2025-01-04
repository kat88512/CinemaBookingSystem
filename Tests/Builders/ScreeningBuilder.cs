using Domain.Models.CinemaModels;
using Domain.Models.MovieModels;
using Domain.Models.ScreeningModels;

namespace Tests.Builders
{
    public class ScreeningBuilder
    {
        private Movie _movie;
        private CinemaRoom _cinemaRoom;
        private DateTime _timeFrom;
        private DateTime _timeTo;
        private VideoTechnology _videoTechnology;

        private ScreeningBuilder() { }

        public static ScreeningBuilder Create()
        {
            return new ScreeningBuilder();
        }

        public Screening Build()
        {
            return new Screening(_movie, _cinemaRoom, _timeFrom, _timeTo, _videoTechnology);
        }

        public ScreeningBuilder WithDefaultData()
        {
            var tomorrow = DateTime.Now.AddDays(1);

            _movie = new Movie("Test movie name");
            _cinemaRoom = new CinemaRoom(Guid.NewGuid(), 1, CinemaRoomType.Large);
            _timeFrom = tomorrow;
            _timeTo = _timeFrom.AddHours(2);
            _videoTechnology = VideoTechnology.TwoDimensional;

            return this;
        }

        public ScreeningBuilder WithTime(DateTime timeFrom, TimeSpan duration)
        {
            _timeFrom = timeFrom;
            _timeTo = timeFrom.Add(duration);

            return this;
        }

        public ScreeningBuilder WithVideoTechnology(VideoTechnology videoTechnology)
        {
            _videoTechnology = videoTechnology;

            return this;
        }
    }
}
