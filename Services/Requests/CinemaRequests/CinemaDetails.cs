using DataAccess.Repositories.CinemaRepositories;
using Domain.Models.CinemaModels;

namespace Services.Requests.CinemaRequests
{
    public class CinemaDetails : IRequest<Cinema>
    {
        private readonly ICinemaRepository _cinemas = CinemaInMemoryRepository.Instance;

        public Response<Cinema> Execute()
        {
            var cinema = _cinemas.GetFirst();

            return new Response<Cinema> { IsSuccess = true, Value = cinema };
        }
    }
}
