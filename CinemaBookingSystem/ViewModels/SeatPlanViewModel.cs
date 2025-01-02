﻿using Domain.Models.OrderModels;
using Domain.Models.ScreeningModels;
using Services.Requests;
using Services.Services;
using UI.DataContext;

namespace UI.ViewModels
{
    internal class SeatPlanViewModel(
        ScreeningService screeningService,
        ScreeningSeatService screeningSeatService,
        OrderService orderService,
        SessionContext context
    )
    {
        public Order Order { get; private set; }
        public Screening Screening { get; private set; }
        public IEnumerable<ScreeningSeat> ScreeningSeats { get; private set; }

        private SessionContext _context = context;

        private readonly ScreeningService _screeningService = screeningService;
        private readonly ScreeningSeatService _screeningSeatService = screeningSeatService;
        private readonly OrderService _orderService = orderService;

        public void FetchData()
        {
            Screening = _screeningService.GetScreeningDetails(_context.ScreeningId).Value!;
            ScreeningSeats = _screeningSeatService.GetScreeningSeats(_context.ScreeningId).Value!;
        }

        public void CreateOrder()
        {
            Order = _orderService.AddOrder().Value!;
        }

        public Response<Order> AddScreeningSeatToOrder(Guid seatId)
        {
            return _orderService.AddScreeningSeatToOrder(Order.Id, seatId);
        }

        public void AddOrderContext(Guid orderId)
        {
            _context.OrderId = orderId;
        }
    }
}
