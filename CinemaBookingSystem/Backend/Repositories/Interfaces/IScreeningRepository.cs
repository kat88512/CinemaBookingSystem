using Cinema.Backend.Models;

namespace CinemaBookingSystem.Backend.Repositories.Interfaces
{
    internal interface IScreeningRepository
    {
        Screening GetById(Guid id);
        IEnumerable<Screening> GetAll(Guid cinemaId);
    }
}
