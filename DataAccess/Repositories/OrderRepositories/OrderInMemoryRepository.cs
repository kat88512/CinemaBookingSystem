using Domain.Models.OrderModels;

namespace DataAccess.Repositories.OrderRepositories
{
    public class OrderInMemoryRepository : IOrderRepository
    {
        private readonly List<Order> _orders = [];

        public void Add(Order order)
        {
            _orders.Add(order);
        }

        public Order? GetById(Guid id)
        {
            return _orders.FirstOrDefault(o => o.Id == id);
        }

        public void Update(Order order)
        {
            var item = _orders.FirstOrDefault(o => o.Id == order.Id);
            item = order;
        }
    }
}
