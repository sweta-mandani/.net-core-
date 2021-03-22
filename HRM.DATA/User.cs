using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRM.DATA
{
    public class User: IdentityUser
    { 
        
   public string Name { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; } 
    
    }
}
