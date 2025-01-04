using DataAccess.Repositories.UserRepositories;
using Domain.Models.UserModels;
using Services.Requests;

namespace Services.Services
{
    public class UserService(IUserRepository userRepository)
    {
        private readonly IUserRepository _users = userRepository;

        public Response<User> GetUserDetails()
        {
            var user = _users.GetFirst();

            return new Response<User> { IsSuccess = true, Value = user };
        }
    }
}
