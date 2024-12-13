using CinemaBookingSystem.Consts;
using CinemaBookingSystem.Extensions;
using Domain.Models.CinemaModels;
using Domain.Models.ScreeningModels;
using Services.Requests.CinemaRequests;
using Services.Requests.ScreeningRequests;

namespace CinemaBookingSystem.Views
{
    internal class ScreeningsView : IView
    {
        public static ScreeningsView Instance => _instance;

        private static readonly ScreeningsView _instance = new();

        private Cinema _cinema = null!;
        private List<Screening> _screenings = [];

        private ScreeningsView() { }

        public void Display()
        {
            Console.Clear();

            FetchData();

            PrintScreenings();
            var screening = ChooseScreening();

            new SeatPlanView(screening.Id).Display();
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

            for (int i = 0; i < _screenings.Count; i++)
            {
                var s = _screenings[i];
                var movieName = s.Movie.Name;
                var formattedStartDate = s.TimeFrom.ToString(Formats.DateTimeFormat);
                var cinemaRoomType = s.CinemaRoom.RoomType;

                Console.Write($"{i}. {movieName} on {formattedStartDate}");

                if (s.VideoTechnology == VideoTechnology.ThreeDimensional)
                {
                    Console.Write(" ");
                    ConsoleExtensions.WriteInColor("3D!", backgroundColor: ConsoleColor.Blue);
                }

                Console.WriteLine();

                ConsoleExtensions.WriteLineInColor(
                    $"Cinema room type: {cinemaRoomType.Name}",
                    foregroundColor: ConsoleColor.Cyan
                );
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
