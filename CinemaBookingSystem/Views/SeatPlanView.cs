using UI.Consts;
using UI.Extensions;
using UI.ViewModels;

namespace UI.Views
{
    internal class SeatPlanView(SeatPlanViewModel viewModel, Navigator navigator) : IView
    {
        private bool _userIsOrdering = true;

        private readonly SeatPlanViewModel _viewModel = viewModel;
        private readonly Navigator _navigator = navigator;

        public void Display()
        {
            Console.Clear();
            _viewModel.CreateOrder();
            _viewModel.AddOrderContext(_viewModel.Order.Id);

            while (_userIsOrdering)
            {
                _viewModel.FetchData();

                PrintSeats();
                PrintKey();
                PrintOrderSeats();

                AddSeatToOrder();
                ShowContinueQuestion();
            }

            _navigator.ChangeView<SummaryView>();
        }

        private void PrintSeats()
        {
            var movieName = _viewModel.Screening.Movie.Name;
            var formattedStartDate = _viewModel.Screening.TimeFrom.ToString(Formats.DateTimeFormat);

            Console.WriteLine(
                $"Available seats for screening '{movieName}' on {formattedStartDate}: \n"
            );

            var orderedSeats = _viewModel.ScreeningSeats.OrderBy(s => s.Row).ThenBy(s => s.Number);
            var rowNumber = orderedSeats.First().Row;

            foreach (var seat in orderedSeats)
            {
                var currentRowNumber = seat.Row;
                if (rowNumber != currentRowNumber)
                {
                    Console.WriteLine();
                    rowNumber++;
                }

                if (seat.IsTaken)
                {
                    ConsoleExtensions.WriteInColor(
                        seat + " ",
                        backgroundColor: ConsoleColor.DarkRed
                    );
                }
                else
                {
                    ConsoleExtensions.WriteInColor(
                        seat + " ",
                        backgroundColor: ConsoleColor.DarkGreen
                    );
                }
            }

            Console.WriteLine("\n");
        }

        private void PrintKey()
        {
            Console.WriteLine("Seat availability key:\n");

            ConsoleExtensions.WriteInColor(
                "Seat available",
                backgroundColor: ConsoleColor.DarkGreen
            );

            Console.WriteLine();

            ConsoleExtensions.WriteInColor("Seat taken", backgroundColor: ConsoleColor.DarkRed);
            Console.WriteLine("\n");
        }

        private void PrintOrderSeats()
        {
            Console.Write("Your seats: ");

            if (!_viewModel.Order.Items.Any())
            {
                Console.WriteLine("none!\n");
                return;
            }

            foreach (var item in _viewModel.Order.Items)
            {
                ConsoleExtensions.WriteInColor(
                    $"{item.ScreeningSeat} ",
                    backgroundColor: ConsoleColor.DarkBlue
                );
                Console.Write(" ");
            }

            Console.WriteLine("\n");
        }

        private void AddSeatToOrder()
        {
            while (true)
            {
                Console.Write("Choose available seat: ");
                var input = Console.ReadLine();
                var parseSuccess = int.TryParse(input, out var number);

                var rowNumber = number / 10;
                var seatNumber = number - rowNumber * 10;

                if (!parseSuccess)
                {
                    Console.WriteLine("Incorrect input!");
                    continue;
                }

                var seat = _viewModel.ScreeningSeats.FirstOrDefault(ss =>
                    ss.Row == rowNumber && ss.Number == seatNumber
                );

                if (seat is null)
                {
                    Console.WriteLine("Incorrect number!\n");
                    continue;
                }

                var result = _viewModel.AddScreeningSeatToOrder(seat.Id);

                if (!result.IsSuccess)
                {
                    Console.WriteLine($"{result.ErrorMessage}\n");
                    continue;
                }

                Console.WriteLine($"Added seat {number} to order!\n");
                break;
            }
        }

        private void ShowContinueQuestion()
        {
            while (true)
            {
                Console.Write("Do you want to add more seats? [Y/N]: ");

                var input = Console.ReadLine();

                if (input is null)
                {
                    Console.WriteLine("Please provide value!");
                    continue;
                }

                input = input.ToUpper();
                if (input != "Y" && input != "N")
                {
                    Console.WriteLine("Incorrect key!");
                    continue;
                }

                if (input == "N")
                {
                    _userIsOrdering = false;
                }

                break;
            }
        }
    }
}
