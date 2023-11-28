using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Authen.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
        private Users AuthenticateUser(Users user)
        {
            Users _user = null;
            if(user.Username == "admin" &&  user.Password == "12345")
            {
                _user = new Users{ Username = "Gaurav Mundhada"};
            }
            return _user;

            private string GenerateToken(Users users)
            {
                var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

                // Create Token

                var token = new JwtSecurityToken()
            }
        }
    }
}