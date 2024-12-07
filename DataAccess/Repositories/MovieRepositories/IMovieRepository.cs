using Domain.Models.MovieModels;

namespace DataAccess.Repositories.MovieRepositories
{
    public interface IMovieRepository
    {
        void Add(Movie movie);
    }
}
