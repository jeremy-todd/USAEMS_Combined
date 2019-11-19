using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USAEMS.Core.Models;

namespace USAEMS.ApiModels
{
    public class EventModel
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public EventType EventType { get; set; }
        public DateTime EventDateTime { get; set; }
        public string EventDescription { get; set; }
    }
}