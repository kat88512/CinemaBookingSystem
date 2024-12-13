using DataAccess.Repositories.OrderRepositories;
using DataAccess.Repositories.ScreeningRepositories;
using Domain.Consts;
using Domain.Models.OrderModels;

namespace Services.Requests.OrderRequests
{
    public class AddScreeningSeatToOrder(Guid screeningSeatId, Guid orderId) : IRequest<Order>
    {
        public Guid ScreeningSeatId { get; set; } = screeningSeatId;
        public Guid OrderId { get; set; } = orderId;

        private readonly IScreeningSeatRepository _screeningSeatRepository =
            ScreeningSeatInMemoryRepository.Instance;
        private readonly IScreeningRepository _screeningRepository =
            ScreeningInMemoryRepository.Instance;
        private readonly IOrderRepository _orderRepository = OrderInMemoryRepository.Instance;

        public Response<Order> Execute()
        {
            var order = _orderRepository.GetById(OrderId);

            if (order is null)
            {
                return new Response<Order>
                {
                    IsSuccess = false,
                    ErrorMessage = "Order does not exist"
                };
            }

            var itemsCount = order.Items.Count();
            var maxItemsCount = Order.MaxOrderItemsCount;

            if (itemsCount >= maxItemsCount)
            {
                return new Response<Order>
                {
                    IsSuccess = false,
                    ErrorMessage =
                        $"Order has {itemsCount} seats reserved. Order cannot have more than {maxItemsCount} seats"
                };
            }

            var seat = _screeningSeatRepository.GetById(ScreeningSeatId);

            if (seat is null)
            {
                return new Response<Order>
                {
                    IsSuccess = false,
                    ErrorMessage = "Seat does not exist"
                };
            }

            var screening = _screeningRepository.GetById(seat.ScreeningId)!;

            if (screening.TimeFrom < DateTime.Now)
            {
                return new Response<Order>
                {
                    IsSuccess = false,
                    ErrorMessage = "Screening start date is in the past"
                };
            }

            if (seat.IsTaken)
            {
                return new Response<Order>
                {
                    IsSuccess = false,
                    ErrorMessage = "Seat is already taken"
                };
            }

            seat.ChangeStatus(isTaken: true);
            _screeningSeatRepository.Update(seat);

            order.AddItem(new OrderItem(seat, PriceList.SeatPrice));
            _orderRepository.Update(order);

            return new Response<Order> { IsSuccess = true, Value = order };
        }
    }
}
