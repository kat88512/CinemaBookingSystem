using Domain.Models.UserModels;

namespace DataAccess.Repositories.UserRepositories
{
    public interface IUserRepository
    {
        User? GetById(Guid id);
        User? GetFirst();
        void Add(User user);
    }
}
