using CinemaBookingSystem.Consts;
using Domain.Models.OrderModels;
using Domain.Models.ScreeningModels;
using Services.Requests.OrderRequests;
using Services.Requests.ScreeningRequests;

namespace CinemaBookingSystem.Views
{
    internal class SeatView : IView
    {
        private readonly Guid _requestedScreeningId;

        private Order _order = null!;
        private Screening _screening = null!;
        private IEnumerable<ScreeningSeat> _screeningSeats = null!;

        private bool _userIsOrdering = true;

        public SeatView(Guid screeningId)
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

                AddSeatToOrder();
                ShowContinueQuestion();
            }
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
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine();
                    rowNumber++;
                }

                if (seat.IsTaken)
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                }

                Console.Write(seat + " ");
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\n");
        }

        private void PrintKey()
        {
            Console.WriteLine("Seat availability key:\n");

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("Seat available");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();

            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Write("Seat taken");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
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
