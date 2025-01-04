using Domain.Models.OrderModels;
using Services.Services;
using UI.DataContext;

namespace UI.ViewModels
{
    internal class SummaryViewModel
    {
        public Order Order { get; private set; } = null!;

        private readonly SessionContext _context;
        private readonly OrderService _orderService;

        public SummaryViewModel(OrderService orderService, SessionContext context)
        {
            _orderService = orderService;
            _context = context;
        }

        public void FetchData()
        {
            Order = _orderService.GetOrderDetails(_context.OrderId).Value!;
        }
    }
}
