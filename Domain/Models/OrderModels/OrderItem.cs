using Domain.Models.ScreeningModels;

namespace Domain.Models.OrderModels
{
    public class OrderItem
    {
        public ScreeningSeat ScreeningSeat { get; private set; }
        public int SeatPrice { get; private set; }

        public OrderItem(ScreeningSeat screeningSeat, int seatPrice)
        {
            ScreeningSeat = screeningSeat;
            SeatPrice = seatPrice;
        }
    }
}
