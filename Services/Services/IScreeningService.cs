using Domain.Models.ScreeningModels;
using Services.Requests;

namespace Services.Services
{
    public interface IScreeningService
    {
        Response<IEnumerable<Screening>> GetCinemaScreenings(Guid cinemaId);
        Response<Screening> GetScreeningDetails(Guid screeningId);
    }
}
