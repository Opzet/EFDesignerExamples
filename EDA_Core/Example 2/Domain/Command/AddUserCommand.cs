
using EventAnnotator;

namespace UserRegistration.Domain.Commands
{
    /// <summary>
    /// Command to register a new user.
    /// </summary>
    /// <remarks>
    /// In the context of Event Sourcing, commands are used to encapsulate all the information needed to perform an action or trigger a state change in the system.
    /// Commands are part of the Command Query Responsibility Segregation (CQRS) pattern, where they represent the "write" side of the application.
    /// 
    /// When a command is issued, it is handled by a command handler, which performs the necessary business logic and generates one or more events.
    /// These events are then persisted to an event store and used to update the state of the application.
    /// 
    /// The RegisterUserCommand class encapsulates the data required to register a new user, including the user's name, email, and password.
    /// When this command is handled, it will result in an event (e.g., UserRegisteredEvent) that represents the successful registration of the user.
    /// </remarks>
    [CommandMetadata(
        domain: "RegisterUser",
        name: "RegisterUser",
        description: "Command to register a new user.",
        version: "1.0",
        summary: "Registers a new user in the system.",
        owners: new[] { "admin@example.com" },
        address: "https://api.example.com/register",
        protocols: new[] { "HTTP", "HTTPS" },
        environments: new[] { "Production", "Staging" },
        channelOverview: "User registration channel"
    )]
    public class AddUserCommand
    {
        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        public string UserName
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        public string Email
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password
        {
            get; set;
        }
    }
}
