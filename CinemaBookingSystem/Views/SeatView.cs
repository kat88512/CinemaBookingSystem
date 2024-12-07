using CinemaBookingSystem.Consts;
using DataAccess.Repositories.ScreeningRepositories;
using Domain.Models.OrderModels;
using Domain.Models.ScreeningModels;
using Services.Requests.OrderRequests;

namespace CinemaBookingSystem.Views
{
    internal class SeatView : IView
    {
        private readonly Guid _requestedScreeningId;

        private readonly ScreeningInMemoryRepository _screeningRepository =
            ScreeningInMemoryRepository.Instance;
        private readonly ScreeningSeatInMemoryRepository _screeningSeatRepository =
            ScreeningSeatInMemoryRepository.Instance;

        private Order _order = null!;
        private Screening _screening = null!;
        private IEnumerable<ScreeningSeat> _screeningSeats;

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
            var screening = _screeningRepository.GetById(_requestedScreeningId);

            if (screening is null)
            {
                throw new Exception("Screening was not found!");
            }

            _screening = screening;
            _screeningSeats = _screeningSeatRepository.GetAll(_screening.Id);
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
            var rowCount = _screening.CinemaRoom.RoomType.RowsCount;

            for (int i = 0; i < rowCount; i++)
            {
                var row = _screeningSeatRepository.GetRow(_screening.Id, i);

                foreach (var seat in row)
                {
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
                Console.WriteLine();
            }
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
