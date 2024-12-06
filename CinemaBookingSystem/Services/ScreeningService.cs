using CinemaBookingSystem.Repositories.Interfaces;

namespace CinemaBookingSystem.Services
{
    internal class ScreeningService
    {
        private readonly IScreeningRepository _screeningRepository;

        public ScreeningService(IScreeningRepository screeningRepository)
        {
            _screeningRepository = screeningRepository;
        }

        public void PrintAll(Guid cinemaId)
        {
            var screenings = _screeningRepository.GetAll(cinemaId);
            var dateFormat = "dd.MM HH:mm";

            foreach (var screening in screenings)
            {
                Console.WriteLine(
                    $"{screening.TimeFrom.ToString(dateFormat)}: {screening.Movie.Name}"
                );
            }
        }
    }
}
