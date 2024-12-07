using CinemaBookingSystem.Consts;
using Domain.Models.CinemaModels;
using Domain.Models.ScreeningModels;
using Services.Requests.CinemaRequests;
using Services.Requests.ScreeningRequests;

namespace CinemaBookingSystem.Views
{
    internal class MainView : IView
    {
        public static MainView Instance => _instance;

        private static readonly MainView _instance = new MainView();

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
            _cinema = new CinemaDetails().Execute().Value!;
            _screenings = new CinemaScreenings(_cinema.Id).Execute().Value!.ToList();
        }

        private void PrintScreenings()
        {
            Console.WriteLine($"Welcome to {_cinema.Name} in {_cinema.City}! \n");

            Console.WriteLine($"Available screenings: \n");

            for (int i = 0; i < _screenings.Count(); i++)
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
