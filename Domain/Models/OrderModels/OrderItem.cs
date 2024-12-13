using Domain.Models.ScreeningModels;

namespace Domain.Models.OrderModels
{
    public class OrderItem(ScreeningSeat screeningSeat, decimal seatPrice)
    {
        public ScreeningSeat ScreeningSeat { get; private set; } = screeningSeat;
        public decimal SeatPrice { get; private set; } = seatPrice;
    }
}
