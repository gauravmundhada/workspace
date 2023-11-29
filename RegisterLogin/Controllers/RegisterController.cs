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

        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            // Find the user by their username or email
            var user = await _userManager.FindByNameAsync(model.userName);
        
            if (user == null)
            {
                // User not found
                return NotFound("Invalid username or password");
            }
        
            // Check if the password is valid
            var result = await _signInManager.CheckPasswordSignInAsync(user, model.password, false);
        
            if (result.Succeeded)
            {
                // Password is correct, generate token or perform login actions
                // You might use a token service or another method to generate and return a token.
                var token = GenerateToken(user);
        
                return Ok(new { Token = token });
            }
            else
            {
                // Password is incorrect
                return Unauthorized("Invalid username or password");
            }
        }


        private string GenerateToken(User user)
        {
            // Sample code, use a token library like IdentityServer4 in production
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.userId),
                new Claim(ClaimTypes.Name, user.userName),
                // Add additional claims as needed
            };
        
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your-secret-key"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        
            var token = new JwtSecurityToken(
                issuer: "your-issuer",
                audience: "your-audience",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );
        
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}