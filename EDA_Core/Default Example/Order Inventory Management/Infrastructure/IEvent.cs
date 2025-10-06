namespace OIM.Domain.Events
{
    /// <summary>
    /// Interface for domain events.
    /// </summary>
    /// <remarks>
    /// In the context of Event Sourcing, domain events represent significant changes in the state of the system.
    /// Events are immutable and are used to capture and persist these state changes.
    /// 
    /// The IEvent interface defines the basic structure that all domain events must follow.
    /// It includes properties for a unique identifier (Id) and the date and time when the event occurred (OccurredOn).
    /// 
    /// Implementing this interface ensures that all domain events have a consistent structure, which is essential for event storage and processing.
    /// </remarks>
    public interface IEvent
    {
        /// <summary>
        /// Gets the unique identifier for the event.
        /// </summary>
        Guid Id
        {
            get;
        }

        /// <summary>
        /// User Auditing
        /// </summary>
        public string UserId
        {  
            get; set;
        }

        /// <summary>
        /// Gets the date and time when the event occurred.
        /// </summary>
        DateTime OccurredOn
        {
            get;
        }
    }
}