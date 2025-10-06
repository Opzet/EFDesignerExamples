using OIM.Domain.Events;
using OIM.Infrastructure;

namespace OIM.Services
{
    public class UserService
    {
        private readonly EventStore _eventStore;
        private readonly EventDispatcher _dispatcher;

        public UserService(EventStore eventStore, EventDispatcher dispatcher)
        {
            _eventStore = eventStore;
            _dispatcher = dispatcher;
        }

        public void RegisterUser(string username, string email)
        {
            // Create a new UserRegisteredEvent
            //var userRegisteredEvent = new InventoryAdjusted(username, email);

            //// Append the event to the event store
            //_eventStore.Append(userRegisteredEvent);

            //// Dispatch the event to notify all registered handlers
            //_dispatcher.Dispatch(userRegisteredEvent);
        }
    }
}