using Cinema.Backend.Models;
using CinemaBookingSystem.Backend.Repositories.Interfaces;

namespace CinemaBookingSystem.Backend.Repositories
{
    internal class ScreeningInMemoryRepository : IScreeningRepository
    {
        private readonly ICollection<Screening> _screenings = new List<Screening>();

        public ScreeningInMemoryRepository() { }

        public IEnumerable<Screening> GetAll(Guid cinemaId)
        {
            throw new NotImplementedException();
        }

        public Screening GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
