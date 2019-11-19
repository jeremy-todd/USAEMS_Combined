using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USAEMS.Core.Models;

namespace USAEMS.ApiModels
{
    public class IncidentModel
    {
        public int Id { get; set; }
        public string IncidentEventId { get; set; }
        public string IncidentLocation { get; set; }
        public DateTime IncidentTime { get; set; }
        public string PatronFirstName { get; set; }
        public string PatronLastName { get; set; }
        public string PatronAddress { get; set; }
        public string PatronCity { get; set; }
        public string PatronState { get; set; }
        public int PatronZIP { get; set; }
        public string PatronPhone { get; set; }
        public DateTime PatronDOB { get; set; }
        public string PatronEmail { get; set; }
        public string IncidentDescription { get; set; }
        public string EmployeeId { get; set; }
        public string IncidentCaseNumber { get; set; }
    }
}