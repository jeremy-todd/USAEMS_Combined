using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USAEMS.Core.Models;

namespace USAEMS.ApiModels
{
    public static class IncidentMappingExtensions
    {
        public static IncidentModel ToApiModel(this Incident incident)
        {
            return new IncidentModel
            {
                Id = incident.Id,
                IncidentEventId = incident.IncidentEventId,
                IncidentLocation = incident.IncidentLocation,
                IncidentTime = incident.IncidentTime,
                PatronFirstName = incident.PatronFirstName,
                PatronLastName = incident.PatronLastName,
                PatronAddress = incident.PatronAddress,
                PatronCity = incident.PatronCity,
                PatronState = incident.PatronState,
                PatronZIP = incident.PatronZIP,
                PatronPhone = incident.PatronPhone,
                PatronDOB = incident.PatronDOB,
                PatronEmail = incident.PatronEmail,
                IncidentDescription = incident.IncidentDescription,
                EmployeeId = incident.EmployeeId,
                IncidentCaseNumber = incident.IncidentCaseNumber
            };
        }

        public static Incident ToDomainModel(this IncidentModel incidentModel)
        {
            return new Incident
            {
                Id = incidentModel.Id,
                IncidentEventId = incidentModel.IncidentEventId,
                IncidentLocation = incidentModel.IncidentLocation,
                IncidentTime = incidentModel.IncidentTime,
                PatronFirstName = incidentModel.PatronFirstName,
                PatronLastName = incidentModel.PatronLastName,
                PatronAddress = incidentModel.PatronAddress,
                PatronCity = incidentModel.PatronCity,
                PatronState = incidentModel.PatronState,
                PatronZIP = incidentModel.PatronZIP,
                PatronPhone = incidentModel.PatronPhone,
                PatronDOB = incidentModel.PatronDOB,
                PatronEmail = incidentModel.PatronEmail,
                IncidentDescription = incidentModel.IncidentDescription,
                EmployeeId = incidentModel.EmployeeId,
                IncidentCaseNumber = incidentModel.IncidentCaseNumber
            };
        }

        public static IEnumerable<IncidentModel> ToApiModels(this IEnumerable<Incident> incidents)
        {
            return incidents.Select(i => i.ToApiModel());
        }

        public static IEnumerable<Incident> ToDomainModels(this IEnumerable<IncidentModel> incidentModels)
        {
            return incidentModels.Select(i => i.ToDomainModel());
        }
    }
}