using CinemaBookingSystem.Models;
using CinemaBookingSystem.Repositories.Interfaces;

namespace CinemaBookingSystem.Repositories
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
