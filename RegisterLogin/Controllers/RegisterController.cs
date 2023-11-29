using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RegisterLogin.Models;

namespace RegisterLogin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController : ControllerBase
    {
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
{
    // Validate model and create a new user
    var user = new User { UserName = model.UserName, Email = model.Email };
    var result = await _userManager.CreateAsync(user, model.Password);
 
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