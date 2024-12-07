using DataAccess.Repositories.ScreeningRepositories;
using Domain.Models.ScreeningModels;

namespace Services.Requests.ScreeningRequests
{
    public class ScreeningDetails : IRequest<Screening>
    {
        private readonly Guid _screeningId;

        private readonly IScreeningRepository _screenings = ScreeningInMemoryRepository.Instance;

        public ScreeningDetails(Guid screeningId)
        {
            _screeningId = screeningId;
        }

        public RequestResult<Screening> Execute()
        {
            var screening = _screenings.GetById(_screeningId);

            if (screening is null)
            {
                return new RequestResult<Screening>()
                {
                    IsSuccess = false,
                    ErrorMessage = "Screening does not exist"
                };
            }
            else
            {
                return new RequestResult<Screening>() { IsSuccess = true, Value = screening };
            }
        }
    }
}
