using System.Numerics;
using EventAnnotator;
using UserRegistration.Domain.Model;
using UserRegistration.Infrastructure;
using UserRegistration.Services;

namespace UserRegistration
{
 
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize the event store and dispatcher
            var eventStore = new EventStore();
            var dispatcher = new EventDispatcher();
            var userService = new UserService(eventStore, dispatcher);

            // Register event handler for UserRegisteredEvent
            dispatcher.RegisterHandler<User>(e =>
            {
                Console.WriteLine($"User registered: {e.Username}, {e.Email}");
            });

            // Register a user, which will create and store an event, then dispatch it
            userService.RegisterUser("john_doe", "john@example.com");


            // Update event documentation
            UpdateEventDocumentation();
        }

        // 
        // https://www.asyncapi.com/en

        // Lightweight event store
        //https://github.com/nats-io/nats.net

        private static void UpdateEventDocumentation()
        {
            // EventCatalog provides a set of scripts to help you generate, serve, and deploy your catalog.

            // It does not generate and save event MDX documentation from application C# source code
            // to be consumbed by 'eventcatalog build' command to bootstrap the catalog

            CatalogGenerator.ReGenerateMDXDocumentation();
            

            
            //EventCatalogSDK manage and update event schemas and documentation.
            //Its purpose is to facilitate the generation and maintenance of documentation for events in an event-driven system.
            var eventSchemas = EventSchemaRegistry.GetEventSchema("UserRegisteredEvent");
            if (eventSchemas != null)
            {
                
                // Once your catalog is bootstrapped, the source will contain the EventCatalog scripts that you can invoke with your package manager:
                // Events are just markdown files
                //eventcatalog build
                //Compiles your site for production.

                //EventCatalogSDK.UpdateEventSchema("UserRegisteredEvent", eventSchemas);

                    //Reference
                    // https://www.asyncapi.com/tools/generator 
                    // We have Events and Commands in C#, need to generate for Eventcatalog which works per standard specs and markdown
                    // generation and maintenance of documentation for events in an event-driven system

            }
        }
    }
}