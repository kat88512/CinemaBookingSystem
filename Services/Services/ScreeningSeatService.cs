using DataAccess.Repositories.ScreeningRepositories;
using Domain.Models.ScreeningModels;
using Services.Requests;

namespace Services.Services
{
    public class ScreeningSeatService
    {
        private readonly IScreeningSeatRepository _screeningSeats;

        public ScreeningSeatService(IScreeningSeatRepository screeningSeatRepository)
        {
            _screeningSeats = screeningSeatRepository;
        }

        public Response<IEnumerable<ScreeningSeat>> GetScreeningSeats(Guid screeningId)
        {
            var seats = _screeningSeats.GetAll(screeningId);

            return new Response<IEnumerable<ScreeningSeat>>() { IsSuccess = true, Value = seats };
        }
    }
}
