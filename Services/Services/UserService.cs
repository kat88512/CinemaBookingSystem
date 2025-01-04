using DataAccess.Repositories.UserRepositories;
using Domain.Models.UserModels;
using Services.Requests;

namespace Services.Services
{
    public class UserService
    {
        private readonly IUserRepository _users;

        public UserService(IUserRepository userRepository)
        {
            _users = userRepository;
        }

        public Response<User> GetUserDetails()
        {
            var user = _users.GetFirst();

            return new Response<User> { IsSuccess = true, Value = user };
        }
    }
}
