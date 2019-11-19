using System;
using System.Collections.Generic;
using System.Text;
using USAEMS.Core.Models;

namespace USAEMS.Core.Services
{
    public class IncidentService : IIncidentService
    {
        private readonly IIncidentRepository _incidentRepository;

        public IncidentService(IIncidentRepository incidentRepository)
        {
            _incidentRepository = incidentRepository;
        }

        public Incident Add(Incident newIncident)
        {
            return _incidentRepository.Add(newIncident);
        }

        public Incident Get(int id)
        {
            return _incidentRepository.Get(id);
        }

        public IEnumerable<Incident> GetAll()
        {
            return _incidentRepository.GetAll();
        }

        public void Remove(Incident deleteIncident)
        {
            _incidentRepository.Remove(deleteIncident);
        }

        public Incident Update(Incident updatedIncident)
        {
            return _incidentRepository.Update(updatedIncident);
        }
    }
}