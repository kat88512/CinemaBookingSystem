using Domain.Models.ScreeningModels;

namespace Domain.Models.OrderModels
{
    public class OrderItem
    {
        public ScreeningSeat ScreeningSeat { get; private set; }
        public decimal SeatPrice { get; private set; }

        public OrderItem(ScreeningSeat screeningSeat, decimal seatPrice)
        {
            ScreeningSeat = screeningSeat;
            SeatPrice = seatPrice;
        }
    }
}
