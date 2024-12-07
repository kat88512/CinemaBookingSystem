using Domain.Models.CinemaModels;

namespace DataAccess.Repositories.CinemaRepositories
{
    public interface ICinemaRepository
    {
        Cinema? GetById(Guid id);
        Cinema? GetFirst();
        IEnumerable<Cinema> GetAll();
        void Add(Cinema cinema);
    }
}
