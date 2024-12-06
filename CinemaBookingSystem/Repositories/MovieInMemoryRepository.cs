using CinemaBookingSystem.Models;
using CinemaBookingSystem.Repositories.Interfaces;

namespace CinemaBookingSystem.Repositories
{
    internal class MovieInMemoryRepository : IMovieRepository
    {
        private readonly List<Movie> _movies = [];

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
