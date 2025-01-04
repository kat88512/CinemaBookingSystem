using Domain.Models.OrderModels;
using Domain.Models.ScreeningModels;
using Services.Requests;
using Services.Services;
using UI.DataContext;

namespace UI.ViewModels
{
    internal class SeatPlanViewModel
    {
        public Order Order { get; private set; } = null!;
        public Screening Screening { get; private set; } = null!;
        public IEnumerable<ScreeningSeat> ScreeningSeats { get; private set; } = [];

        private readonly SessionContext _context;

        private readonly ScreeningService _screeningService;
        private readonly ScreeningSeatService _screeningSeatService;
        private readonly OrderService _orderService;

        public SeatPlanViewModel(
            ScreeningService screeningService,
            ScreeningSeatService screeningSeatService,
            OrderService orderService,
            SessionContext context
        )
        {
            _screeningService = screeningService;
            _screeningSeatService = screeningSeatService;
            _orderService = orderService;
            _context = context;
        }

        public void FetchData()
        {
            Screening = _screeningService.GetScreeningDetails(_context.ScreeningId).Value!;
            ScreeningSeats = _screeningSeatService.GetScreeningSeats(_context.ScreeningId).Value!;
        }

        public void CreateOrder()
        {
            Order = _orderService.AddOrder(_context.UserId).Value!;
            _context.OrderId = Order.Id;
        }

        public Response<Order> AddScreeningSeatToOrder(Guid seatId)
        {
            return _orderService.AddScreeningSeatToOrder(Order.Id, seatId);
        }
    }
}
