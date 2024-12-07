using Domain.Models;

namespace DataAccess.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        void Add(Order order);
        Order? GetById(Guid id);
        void Update(Order order);
    }
}
