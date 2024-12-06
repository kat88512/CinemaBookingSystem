using CinemaBookingSystem.Models;

namespace CinemaBookingSystem.Repositories.Interfaces
{
    internal interface IScreeningSeatRepository
    {
        void Add(ScreeningSeat screeningSeat);
        void AddBatch(IEnumerable<ScreeningSeat> screeningSeats);
        IEnumerable<ScreeningSeat> GetAll(Guid screeningId);
        ScreeningSeat? GetById(Guid id);
    }
}
