using Domain.Models.ScreeningModels;
using Services.Requests;

namespace Services.Services
{
    public interface IScreeningSeatService
    {
        Response<IEnumerable<ScreeningSeat>> GetScreeningSeats(Guid screeningId);
    }
}
