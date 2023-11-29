using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RegisterLogin.Models
{
    public class User
    {
        [Key]
        public int userId { get;set; }
        [Required]
        public string userName { get;set; }
        [Required]
        public string password { get;set; }
        [Required]
        public string emailId { get;set; }
        [Required]
        public string role { get;set; }
    }
}