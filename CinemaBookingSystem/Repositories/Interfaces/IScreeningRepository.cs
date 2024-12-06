using CinemaBookingSystem.Models;

namespace CinemaBookingSystem.Repositories.Interfaces
{
    internal interface IScreeningRepository
    {
        Screening GetById(Guid id);
        IEnumerable<Screening> GetAll(Guid cinemaId);
    }
}
