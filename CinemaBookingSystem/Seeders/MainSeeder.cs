using CinemaBookingSystem.Models;
using CinemaBookingSystem.Models.Enums;
using CinemaBookingSystem.Repositories.Interfaces;

namespace CinemaBookingSystem.Seeders
{
    internal class MainSeeder
    {
        public readonly IMovieRepository _movieRepository;
        public readonly ICinemaRepository _cinemaRepository;
        public readonly ICinemaRoomRepository _cinemaRoomRepository;
        public readonly IScreeningRepository _screeningRepository;

        private readonly Random _randomizer = new();

        public MainSeeder(
            IMovieRepository movieRepository,
            ICinemaRepository cinemaRepository,
            ICinemaRoomRepository cinemaRoomRepository,
            IScreeningRepository screeningRepository
        )
        {
            _movieRepository = movieRepository;
            _cinemaRepository = cinemaRepository;
            _cinemaRoomRepository = cinemaRoomRepository;
            _screeningRepository = screeningRepository;
        }

        public void Seed()
        {
            var screeningsCount = 8;

            AddCinema();
            AddCinemaRooms();
            AddMovies();
            AddScreenings(screeningsCount);
        }

        private void AddCinema()
        {
            _cinemaRepository.Add(SeedData.Cinema);
        }

        private void AddCinemaRooms()
        {
            foreach (var room in SeedData.CinemaRooms)
            {
                _cinemaRoomRepository.Add(room);
            }
        }

        private void AddMovies()
        {
            foreach (var movie in SeedData.Movies)
            {
                _movieRepository.Add(movie);
            }
        }

        private void AddScreenings(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var movieIndex = _randomizer.Next(SeedData.Movies.Count);
                var movie = SeedData.Movies[movieIndex];

                var cinemaRoomIndex = _randomizer.Next(SeedData.CinemaRooms.Count);
                var cinemaRoom = SeedData.CinemaRooms[cinemaRoomIndex];

                var daysToAdd = _randomizer.Next(1, 5);
                var hoursToAdd = _randomizer.Next(0, 24);
                var minutesToAdd = _randomizer.Next(0, 60);

                var startDate = DateTime
                    .Now.AddDays(daysToAdd)
                    .AddHours(hoursToAdd)
                    .AddMinutes(minutesToAdd);

                var screeningLength = _randomizer.Next(60, 180);
                var endDate = startDate.AddMinutes(screeningLength);

                var videoTechnology = (VideoTechnology)_randomizer.Next(0, 1);

                _screeningRepository.Add(
                    new Screening(movie, cinemaRoom, startDate, endDate, videoTechnology)
                );
            }
        }
    }
}
