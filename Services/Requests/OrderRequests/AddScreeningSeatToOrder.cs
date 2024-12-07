using DataAccess.Repositories.OrderRepositories;
using DataAccess.Repositories.ScreeningRepositories;
using Domain.Consts;
using Domain.Models.OrderModels;

namespace Services.Requests.OrderRequests
{
    public class AddScreeningSeatToOrder : IRequest<Order>
    {
        public Guid ScreeningSeatId { get; set; }
        public Guid OrderId { get; set; }

        private readonly IScreeningSeatRepository _screeningSeatRepository =
            ScreeningSeatInMemoryRepository.Instance;
        private readonly IOrderRepository _orderRepository = OrderInMemoryRepository.Instance;

        public AddScreeningSeatToOrder(Guid screeningSeatId, Guid orderId)
        {
            ScreeningSeatId = screeningSeatId;
            OrderId = orderId;
        }

        public RequestResult<Order> Execute()
        {
            var order = _orderRepository.GetById(OrderId);

            if (order is null)
            {
                return new RequestResult<Order>
                {
                    IsSuccess = false,
                    ErrorMessage = "Order does not exist"
                };
            }

            var itemsCount = order.Items.Count();
            var maxItemsCount = Order.MaxOrderItemsCount;

            if (itemsCount >= maxItemsCount)
            {
                return new RequestResult<Order>
                {
                    IsSuccess = false,
                    ErrorMessage =
                        $"Order has {itemsCount} seats reserved. Order cannot have more than {maxItemsCount} seats"
                };
            }

            var seat = _screeningSeatRepository.GetById(ScreeningSeatId);

            if (seat is null)
            {
                return new RequestResult<Order>
                {
                    IsSuccess = false,
                    ErrorMessage = "Seat does not exist"
                };
            }

            if (seat.IsTaken)
            {
                return new RequestResult<Order>
                {
                    IsSuccess = false,
                    ErrorMessage = "Seat is already taken"
                };
            }

            seat.ChangeStatus(isTaken: true);
            _screeningSeatRepository.Update(seat);

            order.AddItem(new OrderItem(seat, PriceList.SeatPrice));
            _orderRepository.Update(order);

            return new RequestResult<Order> { IsSuccess = true, Value = order };
        }
    }
}
