using CinemaBookingSystem.Extensions;
using Domain.Models.OrderModels;
using Services.Services;

namespace CinemaBookingSystem.Views
{
    internal class SummaryView(OrderService orderService, Guid orderId) : IView
    {
        private Order _order = null!;

        private readonly Guid _orderId = orderId;
        private readonly OrderService _orderService = orderService;

        public void Display()
        {
            Console.Clear();

            FetchData();

            PrintOrderSummary();
        }

        private void FetchData()
        {
            _order = _orderService.GetOrderDetails(_orderId).Value!;
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
                Console.WriteLine($": {item.SeatPrice} zł");
            }

            Console.WriteLine();
            ConsoleExtensions.WriteInColor("Value to pay: ", foregroundColor: ConsoleColor.Cyan);
            Console.WriteLine($"{_order.ValueToPay} zł");
        }
    }
}
