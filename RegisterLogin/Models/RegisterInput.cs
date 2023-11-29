using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RegisterLogin.Models
{
    public class RegisterInput
    {
    [Key]
    public int userId { get;set; }
    
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string userName { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public string Role { get;set; }
}