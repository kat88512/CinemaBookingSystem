using Domain.Models;

namespace DataAccess.Repositories.Interfaces
{
    public interface ICinemaRepository
    {
        Cinema? GetById(Guid id);
        Cinema? GetFirst();
        IEnumerable<Cinema> GetAll();
        void Add(Cinema cinema);
    }
}
