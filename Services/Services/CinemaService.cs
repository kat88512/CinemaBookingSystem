using DataAccess.Repositories.CinemaRepositories;
using Domain.Models.CinemaModels;
using Services.Requests;

namespace Services.Services
{
    public class CinemaService
    {
        private readonly ICinemaRepository _cinemas;

        public CinemaService(ICinemaRepository cinemaRepository)
        {
            _cinemas = cinemaRepository;
        }

        public Response<Cinema> GetCinemaDetails()
        {
            var cinema = _cinemas.GetFirst();

            return new Response<Cinema> { IsSuccess = true, Value = cinema };
        }
    }
}
