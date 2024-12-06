using CinemaBookingSystem.Models;
using CinemaBookingSystem.Models.Enums;
using CinemaBookingSystem.Repositories;
using CinemaBookingSystem.Repositories.Interfaces;

namespace CinemaBookingSystem.Seeders
{
    internal class MainSeeder
    {
        public readonly IMovieRepository _movieRepository = MovieInMemoryRepository.Instance;
        public readonly ICinemaRepository _cinemaRepository = CinemaInMemoryRepository.Instance;
        public readonly ICinemaRoomRepository _cinemaRoomRepository =
            CinemaRoomInMemoryRepository.Instance;

        public readonly IScreeningRepository _screeningRepository =
            ScreeningInMemoryRepository.Instance;
        public readonly IScreeningSeatRepository _screeningSeatRepository =
            ScreeningSeatInMemoryRepository.Instance;

        private readonly Random _randomizer = new();

        public MainSeeder() { }

        public void Seed()
        {
            var screeningsCount = 8;

            AddCinema();
            AddCinemaRooms();
            AddMovies();
            AddScreeningsAndSeats(screeningsCount);
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

        private void AddScreeningsAndSeats(int count)
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

                var screening = new Screening(
                    movie,
                    cinemaRoom,
                    startDate,
                    endDate,
                    videoTechnology
                );

                _screeningRepository.Add(screening);

                AddScreeningSeats(screening);
            }
        }

        private void AddScreeningSeats(Screening screening)
        {
            var screeningSeats = screening
                .CinemaRoom.RoomSeats.Select(rs => new ScreeningSeat(
                    screening.Id,
                    rs.Row,
                    rs.Number,
                    isTaken: _randomizer.Next(2) == 0
                ))
                .ToList();

            _screeningSeatRepository.AddBatch(screeningSeats);
        }
    }
}
