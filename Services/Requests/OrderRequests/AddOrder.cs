using DataAccess.Repositories.OrderRepositories;
using Domain.Models.OrderModels;

namespace Services.Requests.OrderRequests
{
    public class AddOrder : IRequest<Order>
    {
        private readonly IOrderRepository _orderRepository = OrderInMemoryRepository.Instance;

        public Response<Order> Execute()
        {
            var order = new Order();
            _orderRepository.Add(order);

            return new Response<Order> { IsSuccess = true, Value = order };
        }
    }
}
