using DataAccess.Repositories.ScreeningRepositories;
using Domain.Models.ScreeningModels;
using Services.Requests;

namespace Services.Services
{
    public class ScreeningService(IScreeningRepository screeningRepository) : IScreeningService
    {
        private readonly IScreeningRepository _screenings = screeningRepository;

        public Response<IEnumerable<Screening>> GetCinemaScreenings(Guid cinemaId)
        {
            var screenings = _screenings.GetAll(cinemaId);

            return new Response<IEnumerable<Screening>> { IsSuccess = true, Value = screenings };
        }

        public Response<Screening> GetScreeningDetails(Guid screeningId)
        {
            var screening = _screenings.GetById(screeningId);

            if (screening is null)
            {
                return new Response<Screening>()
                {
                    IsSuccess = false,
                    ErrorMessage = "Screening does not exist"
                };
            }
            else
            {
                return new Response<Screening>() { IsSuccess = true, Value = screening };
            }
        }
    }
}
