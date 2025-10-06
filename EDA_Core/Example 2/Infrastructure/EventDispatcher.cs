using System;
using System.Collections.Generic;
using UserRegistration.Domain.Events;

namespace UserRegistration.Infrastructure
{
    // Event dispatcher to handle event notifications
    public class EventDispatcher
    {
        private readonly Dictionary<Type, List<Action<IEvent>>> _handlers = new();

        // Register a handler for a specific event type
        public void RegisterHandler<TEvent>(Action<TEvent> handler) where TEvent : IEvent
        {
            if (!_handlers.ContainsKey(typeof(TEvent)))
            {
                _handlers[typeof(TEvent)] = new List<Action<IEvent>>();
            }
            _handlers[typeof(TEvent)].Add(e => handler((TEvent)e));
        }

        // Dispatch an event to all registered handlers
        public void Dispatch(IEvent domainEvent)
        {
            var eventType = domainEvent.GetType();
            if (_handlers.ContainsKey(eventType))
            {
                foreach (var handler in _handlers[eventType])
                {
                    handler(domainEvent);
                }
            }
        }
    }
}