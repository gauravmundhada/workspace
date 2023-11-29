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
        public async Task<IActionResult> Authenticate([FromBody User userObj])
        {
            if(userObj == null)
            {
                return BadRequest();
            }
                var user = await _authContext.Users.FirstOrDefaultAsync(x=>x.Username == userObj.Username);
                
        }

    }
}