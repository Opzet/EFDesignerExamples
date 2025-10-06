using System.Text.Json.Serialization;

namespace EventSourcingTutorial.Events;

public abstract class Event
{
    public abstract Guid StreamId { get; }
    
    public DateTime CreatedAtUtc { get; set; }

}



