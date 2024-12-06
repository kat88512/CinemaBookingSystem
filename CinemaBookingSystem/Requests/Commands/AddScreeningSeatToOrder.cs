using CinemaBookingSystem.Models;
using CinemaBookingSystem.Models.Consts;
using CinemaBookingSystem.Repositories;
using CinemaBookingSystem.Repositories.Interfaces;

namespace CinemaBookingSystem.Requests.Commands
{
    internal class AddScreeningSeatToOrder
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

        public CommandResult Execute()
        {
            var order = _orderRepository.GetById(OrderId);

            if (order is null)
            {
                return new CommandResult { Success = false, ErrorMessage = "Order does not exist" };
            }

            var seat = _screeningSeatRepository.GetById(ScreeningSeatId);

            if (seat is null)
            {
                return new CommandResult { Success = false, ErrorMessage = "Seat does not exist" };
            }

            if (seat.IsTaken)
            {
                return new CommandResult
                {
                    Success = false,
                    ErrorMessage = "Seat is already taken"
                };
            }

            seat.ChangeStatus(isTaken: true);
            _screeningSeatRepository.Update(seat);

            order.AddItem(new OrderItem(seat, PriceList.SeatPrice));
            _orderRepository.Update(order);

            return new CommandResult { Success = true };
        }
    }
}
