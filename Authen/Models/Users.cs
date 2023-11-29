using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Authen.Models
{
    public class Users
    {
        [Key]
        public int userId { get;set; }
        public string Username { get;set; }
        public string Password { get;set; }
    }
}