using CinemaBookingSystem.Models;

namespace CinemaBookingSystem.Repositories.Interfaces
{
    internal interface IOrderRepository
    {
        void Add(Order order);
        Order? GetById(Guid id);
        void Update(Order order);
    }
}
