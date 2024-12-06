using CinemaBookingSystem.Models;
using CinemaBookingSystem.Repositories.Interfaces;

namespace CinemaBookingSystem.Repositories
{
    internal class CinemaInMemoryRepository : ICinemaRepository
    {
        private readonly List<Cinema> _cinemas = new List<Cinema>();

        public Cinema? GetById(Guid id)
        {
            return _cinemas.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Cinema> GetAll()
        {
            return _cinemas;
        }

        public void Add(Cinema cinema)
        {
            _cinemas.Add(cinema);
        }
    }
}
