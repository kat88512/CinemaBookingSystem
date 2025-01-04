using Domain.Models.UserModels;

namespace Tests.Builders
{
    internal class UserBuilder
    {
        private string _firstName;
        private string _lastName;
        private string _email;

        public static UserBuilder Create()
        {
            return new UserBuilder();
        }

        private UserBuilder() { }

        public UserBuilder WithDefaultData()
        {
            _firstName = "Adam";
            _lastName = "Testowy";
            _email = "test@example.com";

            return this;
        }

        public User Build()
        {
            return new User(_firstName, _lastName, _email);
        }
    }
}
