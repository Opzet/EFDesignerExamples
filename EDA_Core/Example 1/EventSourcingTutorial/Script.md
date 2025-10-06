

Welcome, I'll explain and demo event sourcing in software applications.  

I’m going to break down event sourcing into simple terms. 

Issue is it is often presented in a way that seems overly complex, but at its core, it’s actually quite straightforward.  

Sometimes, the fancy terminology surrounding event sourcing can be a barrier to understanding. 

So, I am going to strip away that jargon for now and focus on the essence. 

Once the concept is clear, we’ll bring the terminology back in.  

Event-driven architecture (EDA) is often considered the "holy grail" of system design.

Why? Because it enables asynchronous, decoupled, persistent, fault-tolerant, and scalable systems. 

At its core, EDA architecture revolves around *events*—actions or occurrences that the system can react to.  

It allows you to capture all changes to an application's state as a sequence of events. 

This gives you a complete historical record of the application's state and lets you reconstruct any past state at any point in time. 

When paired with the Command Query Responsibility Segregation (CQRS) pattern, event sourcing becomes even more effective.  

### Event Sourcing / Event Driven Architecture (EDA) 
Event-sourcing is a pattern that represents the state of an application as a series of events. 
Instead of storing the current state of an object, you store a log of events that have occurred, which can be replayed to reconstruct the state at any given point in time. 
Each event represents a discrete change in the application's state and is immutable.

### Command Query Responsibility Segregation (CQRS)
CQRS, on the other hand, is a pattern that separates the read and write operations in an application. 
It distinguishes between commands (requests that modify state) and queries (requests that retrieve state). 
By segregating these concerns, you can optimize the read and write models independently, leading to better performance and scalability.

**Here’s the main idea behind event sourcing:**

In most applications, the state is typically represented as a row in a database that gets updated over time. 

With event sourcing, we take a different approach.  

So instead of just storing the *value*, we store the *actions*—everything that happens to that value. Think of it like this:  

### Summary:
**"Don’t store the final result. Instead, store all the steps that led to that result."**  

These actions, or events, are stored in the database in an *append-only* fashion. 

This means we never go back and update past events, because each event reflects something that truly happened at a specific point in time.  

If we later decide to reverse or correct an event, we don’t erase or alter the original event. Instead, we add a new "reversal" event. 

This way, the original event remains part of the historical record. After all, it *did* happen, and at the time, it was valid.

---

**Now, let’s bring this concept to life with a relatable demo.**  

Imagine opening your bank app and seeing a balance of $10. 

That $10 didn’t just appear out of nowhere—it’s the result of a series of events: 

1. You opened your account with a balance of $0.  
2. Someone transferred $100 to you, so your balance became $100.  
3. You spent $50 on something, leaving $50 in your account.  
4. Then $10 was deposited, bringing your balance to $60.  
5. Finally, $50 was withdrawn, leaving you with the current balance of $10.  

Each of these actions—deposits, withdrawals, and even refunds—are *events*. 

Your balance at any moment is simply the result of all these events added together.  

If you need to reverse an event, like getting a refund for a purchase, you don’t erase the original event. 

Instead, you add a new event to reflect the refund. By summing up all the events from the starting balance, you always arrive at the current state.  

**This process may seem inefficient at first, especially if we were to recount every event each time we needed the balance. 

In real-world systems, there are optimizations to avoid recalculating everything repeatedly, but the fundamental principle remains: 

**state is built from events.**

---

**Let’s Dive into Some Code**  

The best way to understand event sourcing is to see it in action. 

I’ll demonstrate this with a simple example of managing students in a system using an in-memory database, e.g simple class storage.  

1. **Setting Up Events**  
   First, we’ll create a base `Event` class to represent the events in our system. Events need:  
   - A timestamp (`createdAtUTC`) to record when the event occurred.  
   - A `streamId` to identify the entity (e.g., a student) the event is associated with.  

   ```csharp
   public abstract class Event
   {
       public DateTime CreatedAtUTC { get; set; }
       public Guid StreamId { get; }
   }
   ```

2. **Defining Specific Events**  
   Now, let’s create specific events for actions such as creating a student, updating their profile, enrolling them in a course, and unenrolling them. Each event extends the `Event` class:  

   ```csharp
   public class StudentCreated : Event
   {
       public Guid StudentId { get; set; }
       public string FullName { get; set; }
       public string Email { get; set; }
       public DateTime DateOfBirth { get; set; }

       public override Guid StreamId => StudentId;
   }

   public class StudentUpdated : Event
   {
       public Guid StudentId { get; set; }
       public string FullName { get; set; }
       public string Email { get; set; }

       public override Guid StreamId => StudentId;
   }

   public class StudentEnrolled : Event
   {
       public Guid StudentId { get; set; }
       public string CourseName { get; set; }

       public override Guid StreamId => StudentId;
   }

   public class StudentUnenrolled : Event
   {
       public Guid StudentId { get; set; }
       public string CourseName { get; set; }

       public override Guid StreamId => StudentId;
   }
   ```

3. **Building the Event Database**  
   We’ll store events in an in-memory database, grouping them by `streamId` (e.g., student ID).  

   ```csharp
   public class StudentDatabase
   {
       private readonly Dictionary<Guid, SortedList<DateTime, Event>> _studentEvents = new();

       public void Append(Event evnt)
       {
           if (!_studentEvents.TryGetValue(evnt.StreamId, out var eventStream))
           {
               eventStream = new SortedList<DateTime, Event>();
               _studentEvents[evnt.StreamId] = eventStream;
           }
           eventStream.Add(evnt.CreatedAtUTC, evnt);
       }
   }
   ```

4. **Using the Database**  
   Now, let’s simulate some actions:  
   - Create a student.  
   - Enroll them in a course.  
   - Update their email.  

   ```csharp
   var studentDatabase = new StudentDatabase();

   var studentId = Guid.NewGuid();
   var studentCreated = new StudentCreated
   {
       StudentId = studentId,
       FullName = "Nick Jones",
       Email = "nick@example.com",
       DateOfBirth = new DateTime(1990, 1, 1),
       CreatedAtUTC = DateTime.UtcNow
   };
   studentDatabase.Append(studentCreated);

   var studentEnrolled = new StudentEnrolled
   {
       StudentId = studentId,
       CourseName = "From Zero to Hero: Event Sourcing",
       CreatedAtUTC = DateTime.UtcNow
   };
   studentDatabase.Append(studentEnrolled);

   var studentUpdated = new StudentUpdated
   {
       StudentId = studentId,
       FullName = "Nick Jones",
       Email = "nick.Jones@example.com",
       CreatedAtUTC = DateTime.UtcNow
   };
   studentDatabase.Append(studentUpdated);
   ```

5. **Debugging and Visualizing Events**  

By inspecting the `_studentEvents` dictionary, you can see the full sequence of events for each student.  

---

A walkthrough of **event sourcing**, its practical implementation, and how to efficiently manage state through **projections**. 

Here's a summarized breakdown of the key points for better clarity:

---

### **1. Event Sourcing Basics**
- **What It Is:** Captures all changes (events) to an entity (e.g., a student) in a sequence.
- **Why It Matters:** 
  - Maintains a full history of changes (audit trail).
  - Allows rebuilding the state of an entity from its event stream.
- **Core Components:**
  - **Event Stream:** A collection of events for a specific entity (e.g., "Student Created", "Student Enrolled").
  - **Apply Methods:** Specific methods in the entity class to apply changes from each event.

---

### **2. Materializing State**
- **On-the-Fly Materialization:** 
  - Dynamically rebuilds the entity's state by replaying events in the correct order.
  - Example: Rebuilding a `Student` object by sequentially applying `StudentCreated`, `StudentEnrolled`, and `StudentUpdated`.
- **Projections:**
  - Stores the latest state (materialized view) to avoid rebuilding every time.
  - **Synchronous Projection:** Updates the projection immediately as events are appended (requires transactional support).
  - **Asynchronous Projection:** Updates projections asynchronously using mechanisms like **change data capture (CDC)**.

---

### **3. Synchronous Projection with Transactions**
- **Atomicity:** Ensures appending an event and updating the projection happen together or not at all.
- **Implementation in DynamoDB:**
  - Use **TransactWriteItems** to store both:
    - The event in the event stream.
    - The updated projection (current state) in the database.

---

### **4. Asynchronous Projection**
- **How It Works:**
  - Relies on DynamoDB's **streams** (change notifications) to trigger updates to projections.
  - A Lambda function can process these stream records to update the projection asynchronously.
- **Advantages:**
  - Suitable for read-heavy scenarios where eventual consistency is acceptable.
  - Allows decoupling projections from the event storage system.

---

### **5. Key Considerations**
- **Efficiency:** On-the-fly materialization can be costly if the event stream grows large.
- **Flexibility:** You can recalculate projections for new use cases without altering the event stream.
- **Consistency Needs:**
  - **Strong Consistency:** Use synchronous projections with transactional updates.
  - **Eventual Consistency:** Use asynchronous projections with CDC.

---

### **6. Benefits of Event Sourcing**
- Full historical data (auditability).
- Ability to reconstruct state at any point in time.
- Flexibility to adapt to changing requirements without data loss.

---

### **Final Thoughts**
Event sourcing paired with projections offers a robust way to manage state and handle changes. 

The choice between synchronous and asynchronous projections depends on your application’s consistency, performance, and scalability requirements.
