using DataAccess.Repositories.Interfaces;
using Domain.Models;

namespace DataAccess.Repositories
{
    public class MovieInMemoryRepository : IMovieRepository
    {
        public static MovieInMemoryRepository Instance => _instance;

        private static readonly MovieInMemoryRepository _instance = new();
        private readonly List<Movie> _movies = [];

        private MovieInMemoryRepository() { }

        public void Add(Movie movie)
        {
            _movies.Add(movie);
        }

        public Movie? GetById(Guid id)
        {
            return _movies.FirstOrDefault(s => s.Id == id);
        }
    }
}
