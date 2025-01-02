using Domain.Models.OrderModels;
using Services.Services;
using UI.DataContext;

namespace UI.ViewModels
{
    internal class SummaryViewModel(OrderService orderService, SessionContext context)
    {
        public Order Order { get; private set; }

        private SessionContext _context = context;
        private readonly OrderService _orderService = orderService;

        public void FetchData()
        {
            Order = _orderService.GetOrderDetails(_context.OrderId).Value!;
        }
    }
}
