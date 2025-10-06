using System;
using System.Collections.Generic;
using UserRegistration.Domain.Events;

namespace UserRegistration.Infrastructure
{
    // Event store to keep track of events
    public class EventStore
    {
        private readonly List<IEvent> _events = new();

        // Append a new event to the store
        public void Append(IEvent domainEvent)
        {
            _events.Add(domainEvent);
            Console.WriteLine($"Event appended: {domainEvent.GetType().Name}");
        }

        // Retrieve all events as a read-only list
        public IReadOnlyList<IEvent> GetAllEvents() => _events.AsReadOnly();
    }
}