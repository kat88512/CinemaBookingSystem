using CinemaBookingSystem.Models;
using CinemaBookingSystem.Models.Consts;
using CinemaBookingSystem.Repositories;

namespace CinemaBookingSystem.Views
{
    internal class MainView : IView
    {
        public static MainView Instance => _instance;

        private static readonly MainView _instance = new MainView();

        private readonly ScreeningInMemoryRepository _screeningRepository =
            ScreeningInMemoryRepository.Instance;
        private readonly CinemaInMemoryRepository _cinemaRepository =
            CinemaInMemoryRepository.Instance;
        private readonly ScreeningSeatInMemoryRepository _screeningSeatRepository =
            ScreeningSeatInMemoryRepository.Instance;

        private Cinema _cinema = null!;
        private List<Screening> _screenings = [];

        private MainView() { }

        public void Display()
        {
            Console.Clear();

            FetchData();

            PrintScreenings();
            var screening = ChooseScreening();

            new SeatView(screening.Id).Display();
        }

        private void FetchData()
        {
            _cinema = _cinemaRepository.GetFirst()!;
            _screenings = _screeningRepository.GetAll(_cinema.Id).ToList();
        }

        private void PrintScreenings()
        {
            Console.WriteLine($"Welcome to {_cinema.Name} in {_cinema.City}! \n");

            Console.WriteLine($"Available screenings: \n");

            for (int i = 0; i < _screenings.Count; i++)
            {
                var s = _screenings[i];
                var movieName = s.Movie.Name;
                var formattedStartDate = s.TimeFrom.ToString(Formats.DateTimeFormat);
                var cinemaRoomType = s.CinemaRoom.RoomType;

                Console.WriteLine($"{i}. {movieName} on {formattedStartDate}");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Cinema room type: {cinemaRoomType.Name}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private Screening ChooseScreening()
        {
            while (true)
            {
                Console.Write($"\nPlease choose a screening [0-{_screenings.Count - 1}]: ");

                var input = Console.ReadLine();
                var parseSuccess = int.TryParse(input, out var number);

                if (!parseSuccess || _screenings.ElementAtOrDefault(number) is null)
                {
                    Console.WriteLine("Incorrect number!");
                }
                else
                {
                    return _screenings[number];
                }
            }
        }
    }
}
