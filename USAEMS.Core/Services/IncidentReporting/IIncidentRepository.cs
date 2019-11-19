using System.Collections.Generic;
using USAEMS.Core.Models;

namespace USAEMS.Core.Services
{
    public interface IIncidentRepository
    {
        Incident Add(Incident newIncident);
        Incident Update(Incident updatedIncident);
        Incident Get(int id);
        IEnumerable<Incident> GetAll();
        void Remove(Incident deleteIncident);
    }
}