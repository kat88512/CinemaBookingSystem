using CinemaBookingSystem.Models;

namespace CinemaBookingSystem.Repositories.Interfaces
{
    internal interface IScreeningSeatRepository
    {
        void Add(ScreeningSeat screeningSeat);
        void AddBatch(IEnumerable<ScreeningSeat> screeningSeats);
        IEnumerable<ScreeningSeat> GetAll(Guid screeningId);
        ScreeningSeat? GetById(Guid id);
        void Update(ScreeningSeat screeningSeat);
        int GetSeatsCount(Guid screeningId, bool? isTaken = null);
    }
}
