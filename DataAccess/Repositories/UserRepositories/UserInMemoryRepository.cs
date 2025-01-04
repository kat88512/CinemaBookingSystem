using Domain.Models.UserModels;

namespace DataAccess.Repositories.UserRepositories
{
    public class UserInMemoryRepository : IUserRepository
    {
        private readonly List<User> _users = [];

        public void Add(User user)
        {
            _users.Add(user);
        }

        public User? GetById(Guid id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public User? GetFirst()
        {
            return _users.FirstOrDefault();
        }
    }
}
