using DataAccess.Repositories.OrderRepositories;
using Domain.Models.OrderModels;

namespace Services.Requests.OrderRequests
{
    public class OrderDetails : IRequest<Order>
    {
        public Guid OrderId { get; set; }

        private readonly IOrderRepository _orders = OrderInMemoryRepository.Instance;

        public OrderDetails(Guid orderId)
        {
            OrderId = orderId;
        }

        public RequestResult<Order> Execute()
        {
            var order = _orders.GetById(OrderId);

            if (order is null)
            {
                return new RequestResult<Order>
                {
                    IsSuccess = false,
                    ErrorMessage = "Order does not exist"
                };
            }
            else
            {
                return new RequestResult<Order> { IsSuccess = true, Value = order, };
            }
        }
    }
}
