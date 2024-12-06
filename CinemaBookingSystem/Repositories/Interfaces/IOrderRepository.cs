using CinemaBookingSystem.Models;

namespace CinemaBookingSystem.Repositories.Interfaces
{
    internal interface IOrderRepository
    {
        void Add(Order order);
        void GetById(Guid id);
        void Update(Guid id, Order order);
    }
}
