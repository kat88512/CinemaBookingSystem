using Domain.Models.ScreeningModels;

namespace DataAccess.Repositories.ScreeningRepositories
{
    public interface IScreeningRepository
    {
        Screening? GetById(Guid id);
        IEnumerable<Screening> GetAll(Guid cinemaId);
        void Add(Screening screening);
    }
}
