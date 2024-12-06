using CinemaBookingSystem.Models;
using CinemaBookingSystem.Repositories;
using CinemaBookingSystem.Repositories.Interfaces;

namespace CinemaBookingSystem.Views
{
    internal class SeatView
    {
        private readonly Guid _requestedScreeningId;
        private readonly IScreeningRepository _screeningRepository;
        private readonly IScreeningSeatRepository _screeningSeatRepository;

        private Screening _screening = null!;
        private IEnumerable<ScreeningSeat> _screeningSeats = [];

        public SeatView(Guid screeningId)
        {
            _requestedScreeningId = screeningId;
            _screeningRepository = ScreeningInMemoryRepository.Instance;
            _screeningSeatRepository = ScreeningSeatInMemoryRepository.Instance;
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
            var seats = _screeningSeats.OrderBy(ss => ss.Row).ThenBy(ss => ss.Number);

            foreach (var s in seats)
            {
                Console.Write(s + " ");
            }
        }
    }
}
