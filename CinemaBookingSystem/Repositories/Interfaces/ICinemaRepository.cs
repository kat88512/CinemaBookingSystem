using CinemaBookingSystem.Models;

namespace CinemaBookingSystem.Repositories.Interfaces
{
    internal interface ICinemaRepository
    {
        Cinema? GetById(Guid id);
        Cinema? GetFirst();
        IEnumerable<Cinema> GetAll();
        void Add(Cinema cinema);
    }
}
