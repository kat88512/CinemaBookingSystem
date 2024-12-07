using Domain.Models;

namespace DataAccess.Repositories.Interfaces
{
    public interface IScreeningRepository
    {
        Screening? GetById(Guid id);
        IEnumerable<Screening> GetAll(Guid cinemaId);
        void Add(Screening screening);
    }
}
