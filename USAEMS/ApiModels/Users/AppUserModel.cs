using System;
using System.Collections.Generic;

namespace USAEMS.ApiModels
{
    public class AppUserModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int CarrierId { get; set; }
        public bool Student { get; set; }
        public bool Technical { get; set; }
        public int EmployerId { get; set; }
        public bool Active { get; set; }
    }
}