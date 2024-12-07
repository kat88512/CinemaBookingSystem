using Domain.Models.CinemaModels;

namespace DataAccess.Repositories.CinemaRepositories
{
    public class CinemaInMemoryRepository : ICinemaRepository
    {
        public static CinemaInMemoryRepository Instance => _instance;

        private static readonly CinemaInMemoryRepository _instance = new();
        private readonly List<Cinema> _cinemas = [];

        private CinemaInMemoryRepository() { }

        public Cinema? GetById(Guid id)
        {
            return _cinemas.FirstOrDefault(c => c.Id == id);
        }

        public Cinema? GetFirst()
        {
            return _cinemas.FirstOrDefault();
        }

        public IEnumerable<Cinema> GetAll()
        {
            return _cinemas;
        }

        public void Add(Cinema cinema)
        {
            _cinemas.Add(cinema);
        }
    }
}
