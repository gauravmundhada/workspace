using FinalApi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace FinalApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _authContext;
        public UserController(AppDbContext authContext)
        {
            _authContext = authContext;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] User userObj)
        {
            if(userObj == null)
            {
                return BadRequest();
            }
                var user = await _authContext.Users.FirstOrDefaultAsync(x=>x.Email == userObj.Email && x.Password == userObj.Password);
                if(user==null)
                    return NotFound(new { Message = "User Not Found!"});

                
                // Console.WriteLine($"User Id before storing in session: {user.Id}");
                // HttpContext.Session.SetInt32("UserId", user.Id);
               // Console.WriteLine($"User Id before storing in session: {HttpContext.Session.GetInt32("UserId")}");
                user.Token = CreateJwtToken(user);
                
                return Ok(new{
                    Token = user.Token,
                    //Session = HttpContext.Session.GetInt32("UserId"),
                    Message = "Login Success!"
                });
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody]User userObj)
        {
            if(userObj == null)
                return BadRequest();

            await _authContext.Users.AddAsync(userObj);
            await _authContext.SaveChangesAsync();
            return Ok(new{
                Message="User Registered Successfully!"
            });
        }

        private string CreateJwtToken(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("verysecret......");
            var identity = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                    
                }
            );

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddSeconds(10),
                SigningCredentials = credentials
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            
            return jwtTokenHandler.WriteToken(token);
        }

       // [Authorize]
        [HttpGet]
        public async Task<ActionResult<User>> GetAllUsers()
        {
            //var userId = HttpContext.Session.GetInt32("UserId");
            // Console.WriteLine($"User Id retrieved from session: {userId}");
            return Ok(
                await _authContext.Users.ToListAsync()
            );
        }

        [HttpGet("getUserObj/{email}")]
        public async Task<ActionResult<User>> GetRole(string email)
        {
            var user = await _authContext.Users.FirstOrDefaultAsync(x=>x.Email == email);
            //string role = user.Role;
            return Ok(user);
        }


        // [HttpGet("getName/{email}")]
        // public async Task<ActionResult<User>> GetName(string email)
        // {
        //     var user = await _authContext.Users.FirstOrDefaultAsync(x=>x.Email == email);
        //     //string role = user.Role;
        //     return Ok(user);
        // }

    }
}