using CinemaBookingSystem.Models;
using CinemaBookingSystem.Repositories.Interfaces;

namespace CinemaBookingSystem.Views
{
    internal class SeatView
    {
        private readonly Guid _requestedScreeningId;
        private readonly IScreeningRepository _screeningRepository;

        private Screening _screening = null!;

        public SeatView(Guid screeningId, IScreeningRepository screeningRepository)
        {
            _requestedScreeningId = screeningId;
            _screeningRepository = screeningRepository;
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
        }

        private void PrintSeats() { }
    }
}
