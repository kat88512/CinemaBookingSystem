using CinemaBookingSystem.Models;
using CinemaBookingSystem.Models.Consts;
using CinemaBookingSystem.Repositories;

namespace CinemaBookingSystem.Views
{
    internal class SeatView
    {
        private readonly Guid _requestedScreeningId;

        private readonly ScreeningInMemoryRepository _screeningRepository =
            ScreeningInMemoryRepository.Instance;
        private readonly ScreeningSeatInMemoryRepository _screeningSeatRepository =
            ScreeningSeatInMemoryRepository.Instance;

        private Screening _screening = null!;
        private IEnumerable<ScreeningSeat> _screeningSeats;

        public SeatView(Guid screeningId)
        {
            _requestedScreeningId = screeningId;
        }

        public void Display()
        {
            Console.Clear();

            FetchData();

            PrintSeats();
            PrintKey();

            ChooseSeats();
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

                Console.WriteLine();
            }

            Console.BackgroundColor = ConsoleColor.Black;
        }

        private void PrintKey()
        {
            Console.WriteLine("Seat availability key:\n");

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Seat available");

            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Seat taken\n");

            Console.BackgroundColor = ConsoleColor.Black;
        }

        private void ChooseSeats()
        {
            while (true)
            {
                Console.WriteLine("Choose available seat: ");
                var input = Console.ReadLine();
                var parseSuccess = int.TryParse(input, out var number);

                var rowNumber = number / 10;
                var seatNumber = number - (rowNumber * 10);

                if (
                    !parseSuccess
                    || !_screeningSeats.Any(ss => ss.Row == rowNumber && ss.Number == seatNumber)
                )
                {
                    Console.WriteLine("Incorrect number!");
                    continue;
                }

                var seatId = _screeningSeats.FirstOrDefault();
            }
        }
    }
}
