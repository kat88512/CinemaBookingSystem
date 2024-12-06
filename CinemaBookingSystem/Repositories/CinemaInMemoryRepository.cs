using CinemaBookingSystem.Models;
using CinemaBookingSystem.Repositories.Interfaces;

namespace CinemaBookingSystem.Repositories
{
    internal class CinemaInMemoryRepository : ICinemaRepository
    {
        private readonly List<Cinema> _cinemas = new List<Cinema>();

        public void Add(Cinema cinema)
        {
            _cinemas.Add(cinema);
        }

        public Cinema? GetById(Guid id)
        {
            return _cinemas.FirstOrDefault(c => c.Id == id);
        }
    }
}
