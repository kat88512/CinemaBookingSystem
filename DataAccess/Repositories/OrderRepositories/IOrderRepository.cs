using Domain.Models.OrderModels;

namespace DataAccess.Repositories.OrderRepositories
{
    public interface IOrderRepository
    {
        void Add(Order order);
        Order? GetById(Guid id);
        void Update(Order order);
    }
}
