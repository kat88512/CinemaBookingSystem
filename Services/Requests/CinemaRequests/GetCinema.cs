using DataAccess.Repositories.CinemaRepositories;
using Domain.Models.CinemaModels;

namespace Services.Requests.CinemaRequests
{
    public class GetCinema : IRequest<Cinema>
    {
        private readonly ICinemaRepository _cinemas = CinemaInMemoryRepository.Instance;

        public RequestResult<Cinema> Execute()
        {
            var cinema = _cinemas.GetFirst();

            return new RequestResult<Cinema> { IsSuccess = true, Value = cinema };
        }
    }
}
