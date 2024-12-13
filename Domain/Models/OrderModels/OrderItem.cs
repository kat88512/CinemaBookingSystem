using Domain.Models.ScreeningModels;

namespace Domain.Models.OrderModels
{
    public class OrderItem(ScreeningSeat screeningSeat, int seatPrice)
    {
        public ScreeningSeat ScreeningSeat { get; private set; } = screeningSeat;
        public int SeatPrice { get; private set; } = seatPrice;
    }
}
