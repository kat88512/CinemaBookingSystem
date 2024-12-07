using DataAccess.Repositories.ScreeningRepositories;
using Domain.Models.ScreeningModels;

namespace Services.Requests.ScreeningRequests
{
    public class GetScreenings : IRequest<IEnumerable<Screening>>
    {
        private readonly IScreeningRepository _screenings = ScreeningInMemoryRepository.Instance;
        private readonly Guid _cinemaId;

        public GetScreenings(Guid cinemaId)
        {
            _cinemaId = cinemaId;
        }

        public RequestResult<IEnumerable<Screening>> Execute()
        {
            var screenings = _screenings.GetAll(_cinemaId);

            return new RequestResult<IEnumerable<Screening>>
            {
                IsSuccess = true,
                Value = screenings
            };
        }
    }
}
