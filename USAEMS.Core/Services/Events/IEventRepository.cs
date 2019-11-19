using System.Collections.Generic;
using USAEMS.Core.Models;

namespace USAEMS.Core.Services
{
    public interface IEventRepository
    {
        Event Add(Event newEvent);
        Event Update(Event updatedEvent);
        Event Get(int id);
        IEnumerable<Event> GetAll();
        void Remove(Event deleteEvent);
    }
}