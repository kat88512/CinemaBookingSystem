using DataAccess.Repositories.ScreeningRepositories;
using Domain.Models.ScreeningModels;

namespace Services.Requests.ScreeningRequests
{
    public class CinemaScreenings : IRequest<IEnumerable<Screening>>
    {
        public Guid CinemaId { get; set; }

        private readonly IScreeningRepository _screenings = ScreeningInMemoryRepository.Instance;

        public CinemaScreenings(Guid cinemaId)
        {
            CinemaId = cinemaId;
        }

        public Response<IEnumerable<Screening>> Execute()
        {
            var screenings = _screenings.GetAll(CinemaId);

            return new Response<IEnumerable<Screening>> { IsSuccess = true, Value = screenings };
        }
    }
}
