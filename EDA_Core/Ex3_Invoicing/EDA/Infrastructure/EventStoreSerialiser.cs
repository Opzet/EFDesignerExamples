using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


    public static class EventStoreDBSerializer
    {
        private static readonly JsonSerializerSettings SerializerSettings;

        //static EventStoreDBSerializer()
        //{
        //    SerializerSettings =
        //        new JsonSerializerSettings().WithNonDefaultConstructorContractResolver();

        //    SerializerSettings.Converters.Add(new EventStoreDBEventMetadataJsonConverter());
        //}

        //public static T? Deserialize<T>(this ResolvedEvent resolvedEvent) where T : class =>
        //    Deserialize(resolvedEvent) as T;

        //public static object? Deserialize(this ResolvedEvent resolvedEvent)
        //{
        //    // get type
        //    var eventType = EventTypeMapper.Instance.ToType(resolvedEvent.IEvent.EventType);

        //    if (eventType == null)
        //        return null;

        //    // deserialize event
        //    return JsonConvert.DeserializeObject(
        //        Encoding.UTF8.GetString(resolvedEvent.IEvent.Data.Span),
        //        eventType,
        //        SerializerSettings
        //    )!;
        //}

        //public static PropagationContext? DeserializePropagationContext(this ResolvedEvent resolvedEvent)
        //{
        //    // get type
        //    var eventType = EventTypeMapper.Instance.ToType(resolvedEvent.IEvent.EventType);

        //    if (eventType == null)
        //        return null;

        //    // deserialize event
        //    return JsonConvert.DeserializeObject<PropagationContext>(
        //        Encoding.UTF8.GetString(resolvedEvent.IEvent.Metadata.Span),
        //        SerializerSettings
        //    );
        //}

        //public static EventData ToJsonEventData(this object @event, object? metadata = null) =>
        //    new(
        //        Uuid.NewUuid(),
        //        EventTypeMapper.Instance.ToName(@event.GetType()),
        //        Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event, SerializerSettings)),
        //        Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(metadata ?? new
        //        {
        //        }, SerializerSettings))
        //    );
    }