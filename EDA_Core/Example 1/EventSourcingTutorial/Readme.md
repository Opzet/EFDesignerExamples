"Don't store the value.  Instead, store the things you do to the value."


## Event-Driven Architecture

Event-driven architecture is considered to be the holy grail of system design in many ways. Its design is based on events, which are actions around which we can build reactive systems. This leads to asynchronous, decoupled, persistent, fault-tolerant and scalable systems.

Event-sourcing is a powerful pattern that allows you to capture all changes to an application's state as a sequence of events. This approach provides a historical view of the application's state and enables you to reconstruct past states at any point in time. When combined with the Command Query Responsibility Segregation (CQRS) pattern, event-sourcing becomes even more potent.




### Getting Started with Event Sourcing in .NET

https://www.youtube.com/watch?v=n_o-xuuVtmw

https://dometrain.com/course/from-zero-to-hero-event-driven-architecture/




## What is Event-Sourcing and CQRS?
https://mbarkt3sto.hashnode.dev/how-to-implement-event-sourcing-with-cqrs-using-ef-core-and-mediatr

Event-sourcing is a pattern that represents the state of an application as a series of events. Instead of storing the current state of an object, you store a log of events that have occurred, which can be replayed to reconstruct the state at any given point in time. Each event represents a discrete change in the application's state and is immutable.

CQRS, on the other hand, is a pattern that separates the read and write operations in an application. It distinguishes between commands (requests that modify state) and queries (requests that retrieve state). By segregating these concerns, you can optimize the read and write models independently, leading to better performance and scalability.