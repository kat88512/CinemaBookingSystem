﻿using Domain.Models.OrderModels;
using Services.Services;
using UI.DataContext;
using UI.Extensions;

namespace UI.Views
{
    internal class SummaryView(OrderService orderService, SessionContext context) : IView
    {
        private Order _order = null!;
        private SessionContext _context = context;

        private readonly OrderService _orderService = orderService;

        public void Display()
        {
            Console.Clear();

            FetchData();

            PrintOrderSummary();
        }

        private void FetchData()
        {
            _order = _orderService.GetOrderDetails(_context.OrderId).Value!;
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
