using CinemaBookingSystem.Models;
using CinemaBookingSystem.Repositories;
using CinemaBookingSystem.Repositories.Interfaces;

namespace CinemaBookingSystem.Requests.Commands
{
    internal class AddOrder : IRequest<Order>
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
