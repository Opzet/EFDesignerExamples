
// Example event: UserRegistered
using UserRegistration.Domain.Events;


namespace UserRegistration.Domain.Model
{

    public class User : UserRegisteredEvent
    {
        public string Username
        {
            get; private set;
        }
        public string Email
        {
            get; private set;
        }

        public User(string username, string email) : base(username, email)
        {
            Username = username;
            Email = email;
        }
    }
}