using CinemaBookingSystem.Models;

namespace CinemaBookingSystem.Repositories.Interfaces
{
    internal interface ICinemaRepository
    {
        void Add(Cinema cinema);

        Cinema? GetById(Guid id);
    }
}
