using CinemaBookingSystem.Models;
using CinemaBookingSystem.Repositories;
using CinemaBookingSystem.Repositories.Interfaces;

namespace CinemaBookingSystem.Requests.Commands
{
    internal class AddOrder
    {
        private readonly IOrderRepository _orderRepository = OrderInMemoryRepository.Instance;

        public CommandResult<Order> Execute()
        {
            var order = new Order();
            _orderRepository.Add(order);

            return new CommandResult<Order> { IsSuccess = true, Value = order };
        }
    }
}
