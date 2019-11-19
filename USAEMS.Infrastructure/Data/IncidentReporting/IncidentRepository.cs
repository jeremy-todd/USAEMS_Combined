using System;
using System.Collections.Generic;
using System.Text;
using USAEMS.Core.Services;
using USAEMS.Core.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace USAEMS.Infrastructure.Data
{
    public class IncidentRepository : IIncidentRepository
    {
        private readonly AppDbContext _dbContext;
        public IncidentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Incident> GetAll()
        {
            return _dbContext.Incidents
                .ToList();
        }

        public Incident Get(int id)
        {
            return _dbContext.Incidents
                .SingleOrDefault(i => i.Id == id);
        }

        public Incident Add(Incident newIncident)
        {
            _dbContext.Incidents.Add(newIncident);
            _dbContext.SaveChanges();
            return newIncident;
        }

        public Incident Update(Incident updatedIncident)
        {
            //get the Incident object in the current list with this id
            var exisitingIncident = _dbContext.Incidents.Find(updatedIncident.Id);

            //return null if the Incident to update is not found
            if (exisitingIncident == null) return null;

            //copy the property values from the changed Incident into the one in the db
            _dbContext.Entry(exisitingIncident)
                .CurrentValues
                .SetValues(updatedIncident);

            //update the Incident and save
            _dbContext.Incidents.Update(exisitingIncident);
            _dbContext.SaveChanges();
            return exisitingIncident;
        }

        public void Remove(Incident deleteIncident)
        {
            _dbContext.Incidents.Remove(deleteIncident);
            _dbContext.SaveChanges();
        }
    }
}