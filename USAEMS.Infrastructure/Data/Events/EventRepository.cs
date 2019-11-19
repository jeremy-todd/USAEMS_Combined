using System;
using System.Collections.Generic;
using System.Text;
using USAEMS.Core.Services;
using USAEMS.Core.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace USAEMS.Infrastructure.Data
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext _dbContext;
        public EventRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Event> GetAll()
        {
            return _dbContext.Events
                .ToList();
        }

        public Event Get(int id)
        {
            return _dbContext.Events
                .Include(e => e.Incidents)
                .Include(e => e.Workers)
                .SingleOrDefault(e => e.Id == id);
        }

        public Event Add(Event newEvent)
        {
            _dbContext.Events.Add(newEvent);
            _dbContext.SaveChanges();
            return newEvent;
        }

        public Event Update(Event updatedEvent)
        {
            //get the Event object in the current list with this id
            var exisitingEvent = _dbContext.Events.Find(updatedEvent.Id);

            //return null if the Event to update is not found
            if (exisitingEvent == null) return null;

            //copy the property values from the changed Event into the one in the db
            _dbContext.Entry(exisitingEvent)
                .CurrentValues
                .SetValues(updatedEvent);

            //update the Event and save
            _dbContext.Events.Update(exisitingEvent);
            _dbContext.SaveChanges();
            return exisitingEvent;
        }

        public void Remove(Event deleteEvent)
        {
            _dbContext.Events.Remove(deleteEvent);
            _dbContext.SaveChanges();
        }
    }
}
