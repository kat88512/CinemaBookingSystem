using Domain.Models.OrderModels;
using Services.Requests;

namespace Services.Services
{
    public interface IOrderService
    {
        Response<Order> AddOrder();
        Response<Order> AddScreeningSeatToOrder(Guid orderId, Guid screeningSeatId);
    }
}
