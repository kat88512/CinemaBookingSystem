using CinemaBookingSystem.Extensions;
using Domain.Models.OrderModels;
using Services.Requests.OrderRequests;

namespace CinemaBookingSystem.Views
{
    internal class SummaryView : IView
    {
        private readonly Guid _orderId;

        private Order _order = null!;

        public SummaryView(Guid orderId)
        {
            _orderId = orderId;
        }

        public void Display()
        {
            Console.Clear();

            FetchData();

            PrintOrderSummary();
        }

        private void FetchData()
        {
            _order = new OrderDetails(_orderId).Execute().Value!;
        }

        private void PrintOrderSummary()
        {
            Console.WriteLine("Your order summary: \n");
            ConsoleExtensions.WriteLineInColor("Seats:\n", foregroundColor: ConsoleColor.Cyan);

            foreach (var item in _order.Items)
            {
                ConsoleExtensions.WriteInColor(
                    $"{item.ScreeningSeat} ",
                    backgroundColor: ConsoleColor.DarkBlue
                );
                Console.WriteLine($": {item.SeatPrice / 100.0} zł");
            }

            Console.WriteLine();
            ConsoleExtensions.WriteInColor("Value to pay: ", foregroundColor: ConsoleColor.Cyan);
            Console.WriteLine($"{_order.ValueToPay / 100.0} zł");
        }
    }
}
