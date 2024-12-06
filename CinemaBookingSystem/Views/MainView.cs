using CinemaBookingSystem.Models;
using CinemaBookingSystem.Repositories.Interfaces;

namespace CinemaBookingSystem.Views
{
    internal class MainView
    {
        private readonly IScreeningRepository _screeningRepository;
        private readonly ICinemaRepository _cinemaRepository;
        private readonly string _printDateFormat = "dd.MM HH:mm";

        private Cinema _cinema;
        private List<Screening> _screenings;

        public MainView(
            IScreeningRepository screeningRepository,
            ICinemaRepository cinemaRepository
        )
        {
            _screeningRepository = screeningRepository;
            _cinemaRepository = cinemaRepository;
        }

        public void Display()
        {
            FetchData();

            PrintScreenings();
            GetScreeningChoice();
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
                var number = i;
                var movieName = _screenings[i].Movie.Name;
                var formattedStartDate = _screenings[i].TimeTo.ToString(_printDateFormat);

                Console.WriteLine($"{number}. {movieName} on {formattedStartDate}");
            }
        }

        private Screening GetScreeningChoice()
        {
            while (true)
            {
                Console.Write($"\nPlease choose a screening [0-{_screenings.Count - 1}]: ");
                var input = Console.ReadLine();
                var parseResult = int.TryParse(input, out var number);

                if (parseResult is false || _screenings.ElementAtOrDefault(number) is null)
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
