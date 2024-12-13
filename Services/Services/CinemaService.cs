using DataAccess.Repositories.CinemaRepositories;
using Domain.Models.CinemaModels;
using Services.Requests;

namespace Services.Services
{
    public class CinemaService(ICinemaRepository cinemaRepository) : ICinemaService
    {
        private readonly ICinemaRepository _cinemas = cinemaRepository;

        public Response<Cinema> GetCinemaDetails()
        {
            var cinema = _cinemas.GetFirst();

            return new Response<Cinema> { IsSuccess = true, Value = cinema };
        }
    }
}
