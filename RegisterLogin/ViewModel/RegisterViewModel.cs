using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RegisterLogin.ViewModel
{
    public class RegisterViewModel
    {
        
        [Display(Name = "Enter Name")]
        [Required(ErrorMessage = "Enter Username")]
        [RegularExpression("[a-zA-Z\\s.]{1,10}" , ErrorMessage = "Enter in proper format")]
        public string userName {set;get;}
        
        
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter Password")]
        public string password { get; set; }
        
        
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter Password")]
        [Compare("Password" , ErrorMessage ="Passwords do not match")]
        public string ConfirmPassword {set;get;}
        
        
        [DataType(DataType.EmailAddress)]
        public string emailId { get; set; }

        [Required]
        public string role { get;set; }
    }
}