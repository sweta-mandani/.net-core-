using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRM.DATA
{
    public class AppUser : IdentityUser
    {

        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public string Password { get; set; }

    }
}
