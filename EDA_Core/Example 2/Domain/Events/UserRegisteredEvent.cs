namespace UserRegistration.Domain.Events
{
    /// <summary>
    /// Event triggered when a user registers.
    /// </summary>
    /// <remarks>
    /// In the context of Event Sourcing, events represent state changes in the system. 
    /// Events are immutable and are used to reconstruct the state of an entity by replaying them.
    /// 
    /// The UserRegisteredEvent class represents the event that is triggered when a user successfully registers.
    /// This event contains the necessary information about the user, such as their username and email.
    /// 
    /// When the RegisterUserCommand is handled, a UserRegisteredEvent is created and persisted to the event store.
    /// This event can then be used to update the read models or trigger other actions in the system.
    /// </remarks>
    [EventMetadata("UserRegisteredEvent", "Event triggered when a user registers.")]
    public class UserRegisteredEvent : IEvent
    {
        /// <summary>
        /// Gets the unique identifier for the event.
        /// </summary>
        public Guid Id
        {
            get; private set;
        }

        /// <summary>
        /// Gets the date and time when the event occurred.
        /// </summary>
        public DateTime OccurredOn
        {
            get; private set;
        }

        /// <summary>
        /// Gets the username of the registered user.
        /// </summary>
        public string Username
        {
            get; private set;
        }

        /// <summary>
        /// Gets the email address of the registered user.
        /// </summary>
        public string Email
        {
            get; private set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRegisteredEvent"/> class.
        /// </summary>
        /// <param name="username">The username of the registered user.</param>
        /// <param name="email">The email address of the registered user.</param>
        public UserRegisteredEvent(string username, string email)
        {
            Id = Guid.NewGuid();
            OccurredOn = DateTime.UtcNow;
            Username = username;
            Email = email;
        }
    }
}