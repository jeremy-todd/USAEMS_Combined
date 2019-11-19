using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace USAEMS.Core.Models
{
    public class Event
    {
        public Event()
        {

        }
        //All Events should have an Id, Name, and DateTime
        public int Id { get; set; }
        [Required]
        public string EventName { get; set; }
        [Required]
        public EventType EventType { get; set; }
        [Required]
        public DateTime EventDateTime { get; set; }
        public string EventDescription { get; set; }

        //Events will have collections of Incidents and AppUsers (Workers) associated with them
        public ICollection<Incident> Incidents { get; set; }
        public ICollection<AppUser> Workers { get; set; }
    }
}