using CinemaBookingSystem.Models.Enums;

namespace CinemaBookingSystem.Models
{
    public class Order
    {
        public Guid Id { get; private init; } = Guid.NewGuid();
        public OrderStatus Status { get; private set; } = OrderStatus.InProgress;
        public int ValueToPay { get; private set; } = 0;
    }
}
