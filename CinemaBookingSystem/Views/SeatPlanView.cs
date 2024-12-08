using CinemaBookingSystem.Consts;
using CinemaBookingSystem.Extensions;
using Domain.Models.OrderModels;
using Domain.Models.ScreeningModels;
using Services.Requests.OrderRequests;
using Services.Requests.ScreeningRequests;

namespace CinemaBookingSystem.Views
{
    internal class SeatPlanView : IView
    {
        private readonly Guid _requestedScreeningId;

        private Order _order = null!;
        private Screening _screening = null!;
        private IEnumerable<ScreeningSeat> _screeningSeats = null!;

        private bool _userIsOrdering = true;

        public SeatPlanView(Guid screeningId)
        {
            _requestedScreeningId = screeningId;
        }

        public void Display()
        {
            Console.Clear();
            CreateOrder();

            while (_userIsOrdering)
            {
                FetchData();

                PrintSeats();
                PrintKey();
                PrintOrderSeats();

                AddSeatToOrder();
                ShowContinueQuestion();
            }

            new SummaryView(_order.Id).Display();
        }

        private void FetchData()
        {
            _screening = new ScreeningDetails(_requestedScreeningId).Execute().Value!;

            _screeningSeats = new ScreeningSeats(_screening.Id).Execute().Value!;
        }

        private void CreateOrder()
        {
            var requestResult = new AddOrder().Execute();

            _order = requestResult.Value!;
        }

        private void PrintSeats()
        {
            var movieName = _screening.Movie.Name;
            var formattedStartDate = _screening.TimeFrom.ToString(Formats.DateTimeFormat);

            Console.WriteLine(
                $"Available seats for screening '{movieName}' on {formattedStartDate}: \n"
            );

            var orderedSeats = _screeningSeats.OrderBy(s => s.Row).ThenBy(s => s.Number);
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

            if (_order.Items.Count() == 0)
            {
                Console.WriteLine("none!\n");
                return;
            }

            foreach (var item in _order.Items)
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
                var seatNumber = number - (rowNumber * 10);

                if (!parseSuccess)
                {
                    Console.WriteLine("Incorrect input!");
                    continue;
                }

                var seat = _screeningSeats.FirstOrDefault(ss =>
                    ss.Row == rowNumber && ss.Number == seatNumber
                );

                if (seat is null)
                {
                    Console.WriteLine("Incorrect number!\n");
                    continue;
                }

                var request = new AddScreeningSeatToOrder(seat.Id, _order.Id);
                var result = request.Execute();

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
