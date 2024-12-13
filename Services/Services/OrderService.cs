using DataAccess.Repositories.OrderRepositories;
using DataAccess.Repositories.ScreeningRepositories;
using Domain.Consts;
using Domain.Models.OrderModels;
using Services.Requests;

namespace Services.Services
{
    public class OrderService(
        IOrderRepository orderRepository,
        IScreeningRepository screeningRepository,
        IScreeningSeatRepository screeningSeatRepository
    ) : IOrderService
    {
        private readonly IOrderRepository _orders = orderRepository;
        private readonly IScreeningRepository _screenings = screeningRepository;
        private readonly IScreeningSeatRepository _screeningSeats = screeningSeatRepository;

        public Response<Order> AddOrder()
        {
            var order = new Order();
            _orders.Add(order);

            return new Response<Order> { IsSuccess = true, Value = order };
        }

        public Response<Order> AddScreeningSeatToOrder(Guid orderId, Guid screeningSeatId)
        {
            var order = _orders.GetById(orderId);

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

            var seat = _screeningSeats.GetById(screeningSeatId);

            if (seat is null)
            {
                return new Response<Order>
                {
                    IsSuccess = false,
                    ErrorMessage = "Seat does not exist"
                };
            }

            var screening = _screenings.GetById(seat.ScreeningId)!;

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
            _screeningSeats.Update(seat);

            order.AddItem(new OrderItem(seat, PriceList.SeatPrice));
            _orders.Update(order);

            return new Response<Order> { IsSuccess = true, Value = order };
        }
    }
}
