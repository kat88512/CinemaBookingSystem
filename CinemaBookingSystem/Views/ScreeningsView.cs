using Domain.Models.CinemaModels;
using Domain.Models.ScreeningModels;
using Services.Services;
using UI.Consts;
using UI.DataContext;
using UI.Extensions;

namespace UI.Views
{
    internal class ScreeningsView(
        CinemaService cinemaService,
        ScreeningService screeningService,
        SessionContext context
    ) : IView
    {
        private Cinema _cinema = null!;
        private List<Screening> _screenings = [];
        private SessionContext _context = context;

        private readonly CinemaService _cinemaService = cinemaService;
        private readonly ScreeningService _screeningService = screeningService;

        public void Display()
        {
            Console.Clear();

            FetchData();

            PrintScreenings();
            ChooseScreening();

            new SeatPlanView(screening.Id).Display();
        }

        private void FetchData()
        {
            _cinema = _cinemaService.GetCinemaDetails().Value!;
            _screenings = _screeningService.GetCinemaScreenings(_cinema.Id).Value!.ToList();
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

        private void ChooseScreening()
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
                    _context.ScreeningId = _screenings[number].Id;
                }
            }
        }
    }
}
