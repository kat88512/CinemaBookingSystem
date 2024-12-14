using DataAccess.Repositories.ScreeningRepositories;
using Domain.Models.ScreeningModels;
using Services.Requests;

namespace Services.Services
{
    public class ScreeningSeatService(IScreeningSeatRepository screeningSeatRepository)
    {
        private readonly IScreeningSeatRepository _screeningSeats = screeningSeatRepository;

        public Response<IEnumerable<ScreeningSeat>> GetScreeningSeats(Guid screeningId)
        {
            var seats = _screeningSeats.GetAll(screeningId);

            return new Response<IEnumerable<ScreeningSeat>>() { IsSuccess = true, Value = seats };
        }
    }
}
