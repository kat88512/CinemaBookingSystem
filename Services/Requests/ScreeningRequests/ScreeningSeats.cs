using DataAccess.Repositories.ScreeningRepositories;
using Domain.Models.ScreeningModels;

namespace Services.Requests.ScreeningRequests
{
    public class ScreeningSeats : IRequest<IEnumerable<ScreeningSeat>>
    {
        public Guid ScreeningId { get; set; }

        private readonly IScreeningSeatRepository _screeningSeats =
            ScreeningSeatInMemoryRepository.Instance;

        public ScreeningSeats(Guid screeningId)
        {
            ScreeningId = screeningId;
        }

        public RequestResult<IEnumerable<ScreeningSeat>> Execute()
        {
            var seats = _screeningSeats.GetAll(ScreeningId);

            return new RequestResult<IEnumerable<ScreeningSeat>>()
            {
                IsSuccess = true,
                Value = seats
            };
        }
    }
}
