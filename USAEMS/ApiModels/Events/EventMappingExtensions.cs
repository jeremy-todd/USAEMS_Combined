using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USAEMS.Core.Models;

namespace USAEMS.ApiModels
{
    public static class EventMappingExtensions
    {
        public static EventModel ToApiModel(this Event thisEvent)
        {
            return new EventModel
            {
                Id = thisEvent.Id,
                EventName = thisEvent.EventName,
                EventType = thisEvent.EventType,
                EventDateTime = thisEvent.EventDateTime,
                EventDescription = thisEvent.EventDescription
            };
        }

        public static Event ToDomainModel(this EventModel eventModel)
        {
            return new Event
            {
                Id = eventModel.Id,
                EventName = eventModel.EventName,
                EventType = eventModel.EventType,
                EventDateTime = eventModel.EventDateTime,
                EventDescription = eventModel.EventDescription
            };
        }

        public static IEnumerable<EventModel> ToApiModels(this IEnumerable<Event> events)
        {
            return events.Select(e => e.ToApiModel());
        }

        public static IEnumerable<Event> ToDomainModels(this IEnumerable<EventModel> eventModels)
        {
            return eventModels.Select(eM => eM.ToDomainModel());
        }
    }
}