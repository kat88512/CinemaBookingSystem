using DataAccess.Repositories.CinemaRepositories;
using DataAccess.Repositories.MovieRepositories;
using DataAccess.Repositories.ScreeningRepositories;
using Domain.Models.ScreeningModels;

namespace Services.Seeders
{
    public class MainSeeder(
        IMovieRepository movieRepository,
        ICinemaRepository cinemaRepository,
        ICinemaRoomRepository cinemaRoomRepository,
        IScreeningRepository screeningRepository,
        IScreeningSeatRepository screeningSeatRepository
    )
    {
        private readonly int _screeningsCount = 8;

        private readonly Random _randomizer = new();

        private readonly IMovieRepository _movieRepository = movieRepository;
        private readonly ICinemaRepository _cinemaRepository = cinemaRepository;
        private readonly ICinemaRoomRepository _cinemaRoomRepository = cinemaRoomRepository;

        private readonly IScreeningRepository _screeningRepository = screeningRepository;
        private readonly IScreeningSeatRepository _screeningSeatRepository =
            screeningSeatRepository;

        public void Seed()
        {
            AddCinema();
            AddCinemaRooms();
            AddMovies();
            AddScreeningsAndSeats(_screeningsCount);
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

                var videoTechnology = (VideoTechnology)_randomizer.Next(0, 2);

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
