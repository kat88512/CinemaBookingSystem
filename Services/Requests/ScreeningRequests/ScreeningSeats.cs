using DataAccess.Repositories.ScreeningRepositories;
using Domain.Models.ScreeningModels;

namespace Services.Requests.ScreeningRequests
{
    public class ScreeningSeats : IRequest<IEnumerable<ScreeningSeat>>
    {
        private readonly Guid _screeningId;

        private readonly IScreeningSeatRepository _screeningSeats =
            ScreeningSeatInMemoryRepository.Instance;

        public ScreeningSeats(Guid screeningId)
        {
            _screeningId = screeningId;
        }

        public RequestResult<IEnumerable<ScreeningSeat>> Execute()
        {
            var seats = _screeningSeats.GetAll(_screeningId);

            return new RequestResult<IEnumerable<ScreeningSeat>>()
            {
                IsSuccess = true,
                Value = seats
            };
        }
    }
}
