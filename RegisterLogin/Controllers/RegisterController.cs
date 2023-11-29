using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RegisterLogin.Models;
using RegisterLogin.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace RegisterLogin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            // Validate model and create a new user
            var user = new User { userName = model.userName, emailId = model.emailId };
            var result = await _userManager.CreateAsync(user, model.password);
        
            if (result.Succeeded)
            {
                // User registration successful
                return Ok();
            }
            else
            {
                // Handle registration failure
                return BadRequest(result.Errors);
            }
        }
    }
}