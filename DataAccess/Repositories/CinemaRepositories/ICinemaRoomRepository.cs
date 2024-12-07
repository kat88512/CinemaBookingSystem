using Domain.Models.CinemaModels;

namespace DataAccess.Repositories.CinemaRepositories
{
    public interface ICinemaRoomRepository
    {
        void Add(CinemaRoom cinemaRoom);
    }
}
