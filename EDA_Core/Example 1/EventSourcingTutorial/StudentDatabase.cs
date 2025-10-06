using System.Net.WebSockets;
using System.Text.Json;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using EventSourcingTutorial.Events;

namespace EventSourcingTutorial;

public class StudentDatabase
{
    // In Memory store for student events
    private readonly Dictionary<Guid, SortedList<DateTime, Event>> _studentEvents = new();

    // In Memory store for student View
    private readonly Dictionary<Guid, Student> _students = new Dictionary<Guid, Student>();


    public async Task AppendAsync<T>(T @event) where T : Event
    {
        var stream = _studentEvents!.GetValueOrDefault(@event.StreamId);
      
        if (stream is null)
        {
            _studentEvents.Add(@event.StreamId, new SortedList<DateTime, Event>());
        }
        @event.CreatedAtUtc = DateTime.UtcNow;

        // Apply Current Event
        _studentEvents[@event.StreamId].Add(@event.CreatedAtUtc, @event);
        // Save to EF Database


        var studentView = await GetStudentAsync(@event.StreamId) ?? new Student();
      
    }

   

    public async Task<Student?> GetStudentAsync(Guid studentId)
    {
        if(!_studentEvents.ContainsKey(studentId))
        {
            return null;
        }

       var student = new Student();

        var studentEvents = _studentEvents[studentId];

        //Apply all previous events
        foreach (var @event in studentEvents.Values)
        {
            student.Apply(@event);
        }
        return student;
    }

    internal async Task<List<Event>> GetAllEventsAsync(Guid studentId)
    {
        // Get all Events e.g StudentCreated, StudentUpdated, StudentEnrolled, StudentUnEnrolled, etc
        if (!_studentEvents.ContainsKey(studentId))
        {
            return new List<Event>();
        }

        return _studentEvents[studentId].Values.ToList();
    }
}
