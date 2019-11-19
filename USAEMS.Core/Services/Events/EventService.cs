using System;
using System.Collections.Generic;
using System.Text;
using USAEMS.Core.Models;

namespace USAEMS.Core.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public Event Add(Event newEvent)
        {
            return _eventRepository.Add(newEvent);
        }

        public Event Get(int id)
        {
            return _eventRepository.Get(id);
        }

        public IEnumerable<Event> GetAll()
        {
            return _eventRepository.GetAll();
        }

        public void Remove(Event deleteEvent)
        {
            _eventRepository.Remove(deleteEvent);
        }

        public Event Update(Event updatedEvent)
        {
            return _eventRepository.Update(updatedEvent);
        }
    }
}