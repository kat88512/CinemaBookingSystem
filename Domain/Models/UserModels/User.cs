namespace Domain.Models.UserModels
{
    public class User(string firstName, string lastName, string email)
    {
        public Guid Id { get; private init; } = Guid.NewGuid();
        public string FirstName { get; private set; } = firstName;
        public string LastName { get; private set; } = lastName;
        public string Email { get; private set; } = email;
    }
}
