using CinemaBookingSystem.Models;
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
        private IEnumerable<ScreeningSeat> _screeningSeats = [];

        public SeatView(Guid screeningId)
        {
            _requestedScreeningId = screeningId;
        }

        public void Display()
        {
            Console.Clear();

            FetchData();

            PrintSeats();
        }

        private void FetchData()
        {
            var screening = _screeningRepository.GetById(_requestedScreeningId);

            if (screening is null)
            {
                throw new Exception("Screening was not found!");
            }

            _screening = screening;

            _screeningSeats = _screeningSeatRepository.GetAll(screening.Id);
        }

        private void PrintSeats()
        {
            var rowCount = _screening.CinemaRoom.RoomType.RowsCount;

            for (int i = 0; i < rowCount; i++)
            {
                var row = _screeningSeatRepository.GetRow(_screening.Id, i);

                foreach (var seat in row)
                {
                    Console.Write(seat + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
