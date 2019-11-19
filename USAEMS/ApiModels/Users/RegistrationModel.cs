using System;

namespace USAEMS.ApiModels
{
    public class RegistrationModel
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int CarrierId { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int EmployerId { get; set; }
        public bool Student { get; set; }
        public bool Technical { get; set; }
        public int SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
    }
}