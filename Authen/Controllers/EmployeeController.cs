using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authen.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Authen.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext  _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [Authorize]
        [HttpGet]
        [Route("GetData")]
        public string GetData()
        {
            return "Authenticated with Jwt";
        }

        
        [HttpGet]
        [Route("Details")]
        public string Details()
        {
            return "Authenticated with Jwt";
        }

        [Authorize]
        [HttpPost]
        public string AddUser(Users user)
        {
            return "User added with username" + user.Username;
        }
    }
}