using Cinema.Backend.Models;

namespace CinemaBookingSystem.Backend.Models
{
    internal class OrderItem
    {
        public ScreeningSeat Seat { get; private set; }
        public int SeatPrice { get; private set; }
    }
}
