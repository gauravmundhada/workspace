using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Authen.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Authen.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        //Injected Configuration
        private IConfiguration _config;
        public LoginController(IConfiguration configuration)
        {
            _config = configuration;
        }

        //Autnenticate the users
        // private Users AuthenticateUser(Users user)
        // {
        //     Users _user = null;
        //     if(user.Username == "admin" &&  user.Password == "12345")
        //     {
        //         _user = new Users{ Username = "Gaurav Mundhada"};
        //     }
        //     return _user;   
        // }

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


        private string GenerateToken(Users users)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.userId),
                    new Claim(ClaimTypes.Name, user.userName),
                    // Add additional claims as needed
                };
                
                var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

                // Create Token
                var token = new JwtSecurityToken(_config["Jwt:Issuer"],_config["Jwt:Audience"],null,expires: DateTime.Now.AddMinutes(1),
                signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }

            //Login Method
            [AllowAnonymous]
            [HttpPost]

            public IActionResult Login(Users user)
            {
                IActionResult response = Unauthorized();
                var user_ = AuthenticateUser(user);
                if(user_ != null)
                {
                    var token = GenerateToken(user_);
                    response = Ok( new { token = token }); 
                }
                return response;
            }
    }
}