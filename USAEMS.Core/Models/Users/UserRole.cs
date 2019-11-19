using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace USAEMS.Core.Models
{
    public class UserRole
    {
        public string UserId { get; set; }
        public string RoleName { get; set; }
    }
}