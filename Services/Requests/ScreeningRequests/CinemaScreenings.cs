using DataAccess.Repositories.ScreeningRepositories;
using Domain.Models.ScreeningModels;

namespace Services.Requests.ScreeningRequests
{
    public class CinemaScreenings : IRequest<IEnumerable<Screening>>
    {
        private readonly Guid _cinemaId;

        private readonly IScreeningRepository _screenings = ScreeningInMemoryRepository.Instance;

        public CinemaScreenings(Guid cinemaId)
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
