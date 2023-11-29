using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using FinalApi.Models;

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
                var user = _authContext.Users.FirstOrDefault(x=>x.Username == userObj.Username && x.Password == userObj.Password);
                if(user==null)
                    return NotFound(new { Message = "User Not Found!"});

                return Ok(new{
                    Message = "Login Success!"
                });
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody]User userObj)
        {
            if(userObj == null)
                return BadRequest();

            await _authContext.Users.AddAsync(userObj);
            _authContext.SaveChangesAsync();
            return Ok(new{
                Message="User Registered Successfully!"
            });
        }

    }
}