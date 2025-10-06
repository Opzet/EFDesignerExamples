using System;
using System.Collections.Generic;
using Ex3_Invoicing.Events;

namespace Ex3_Invoicing.Infrastructure
{
    // Event store to keep track of events
    public class EventStore
    {
        /// <summary>
        /// Note: This is an example of the outbox pattern for Command Bus using EventStoreDB
        /// For production use mature tooling like Wolverine, MassTransit or NServiceBus
        /// </summary>
        private readonly List<IEvent> _events = new();

        // Append a new event to the store
        public void Append(IEvent domainEvent)
        {
            _events.Add(domainEvent);
            Console.WriteLine($"Event [{_events.Count}] appended: {domainEvent.GetType().Name}");
        }

        // Retrieve all events as a read-only list
        public IReadOnlyList<IEvent> GetAllEvents() => _events.AsReadOnly();
    }
}