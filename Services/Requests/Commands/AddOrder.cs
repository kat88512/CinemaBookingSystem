using DataAccess.Repositories;
using DataAccess.Repositories.Interfaces;
using Domain.Models;

namespace Services.Requests.Commands
{
    public class AddOrder : IRequest<Order>
    {
        private readonly IOrderRepository _orderRepository = OrderInMemoryRepository.Instance;

        public RequestResult<Order> Execute()
        {
            var order = new Order();
            _orderRepository.Add(order);

            return new RequestResult<Order> { IsSuccess = true, Value = order };
        }
    }
}
