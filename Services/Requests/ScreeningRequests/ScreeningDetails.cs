using DataAccess.Repositories.ScreeningRepositories;
using Domain.Models.ScreeningModels;

namespace Services.Requests.ScreeningRequests
{
    public class ScreeningDetails : IRequest<Screening>
    {
        public Guid ScreeningId { get; set; }

        private readonly IScreeningRepository _screenings = ScreeningInMemoryRepository.Instance;

        public ScreeningDetails(Guid screeningId)
        {
            ScreeningId = screeningId;
        }

        public RequestResult<Screening> Execute()
        {
            var screening = _screenings.GetById(ScreeningId);

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
