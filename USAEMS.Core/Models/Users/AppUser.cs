using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace USAEMS.Core.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public int CarrierId { get; set; }
        public bool Student { get; set; }
        public bool Technical { get; set; }
        public int EmployerId { get; set; }
        public bool Active { get; set; }
    }
}