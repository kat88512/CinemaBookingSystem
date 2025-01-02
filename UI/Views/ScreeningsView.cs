using Domain.Models.ScreeningModels;
using UI.Consts;
using UI.Extensions;
using UI.ViewModels;

namespace UI.Views
{
    internal class ScreeningsView(ScreeningViewModel viewModel, Navigator navigator) : IView
    {
        private readonly ScreeningViewModel _viewModel = viewModel;
        private readonly Navigator _navigator = navigator;

        public void Display()
        {
            Console.Clear();

            _viewModel.FetchData();

            PrintScreenings();
            ChooseScreening();

            _navigator.ChangeView<SeatPlanView>();
        }

        private void PrintScreenings()
        {
            Console.WriteLine(
                $"Welcome to {_viewModel.Cinema.Name} in {_viewModel.Cinema.City}! \n"
            );

            Console.WriteLine($"Available screenings: \n");

            for (int i = 0; i < _viewModel.Screenings.Count; i++)
            {
                var s = _viewModel.Screenings[i];
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
                Console.Write(
                    $"\nPlease choose a screening [0-{_viewModel.Screenings.Count - 1}]: "
                );

                var input = Console.ReadLine();
                var parseSuccess = int.TryParse(input, out var number);

                if (!parseSuccess || _viewModel.Screenings.ElementAtOrDefault(number) is null)
                {
                    Console.WriteLine("Incorrect number!");
                }
                else
                {
                    var screeningId = _viewModel.Screenings[number].Id;
                    _viewModel.AddScreeningContext(screeningId);

                    break;
                }
            }
        }
    }
}
