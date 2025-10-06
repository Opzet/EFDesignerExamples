namespace Ex3_Invoicing.Events
{

    /// <summary>
    /// Base class for domain events.
    /// </summary>
    /// <remarks>
    /// In the context of Event Sourcing, domain events represent significant changes in the state of the system.
    /// Events are immutable and are used to capture and persist these state changes.
    /// 
    /// The IEvent class defines the basic structure that all domain events must follow.
    /// It includes properties for a unique identifier (Id) and the date and time when the event occurred (OccurredOn).
    /// 
    /// Implementing this class ensures that all domain events have a consistent structure, which is essential for event storage and processing.
    /// </remarks>
    public abstract class IEvent
    {
        /// <summary>
        /// Gets the unique identifier for the event.
        /// </summary>
        public Guid Id
        {
            get; protected set;
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
        public DateTime OccurredOn
        {
            get; protected set;
        }

        /// <summary>
        /// JSON encoded event with DTO as a string, not columns, flat.
        /// </summary>
        public string EventMetadataAsJson
        {
            get; set;
        }

        protected IEvent()
        {
            Id = Guid.NewGuid();
            OccurredOn = DateTime.UtcNow;
        }
    }
}
