using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Authen.Models
{
    public class Users : IdentityUser
    {
        public int userId { get;set; }
    
        public string userName { get;set; }
        
        public string password { get;set; }
        
        public string emailId { get;set; }
        
        public string role { get;set; }
    }
}