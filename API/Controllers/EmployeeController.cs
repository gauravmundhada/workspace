using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Data;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDbContext _context;
        public EmployeeController(EmployeeDbContext context)
        {
            _context = context;
        }
         
        [HttpGet]
        public IActionResult GetAllEmployees()
        {

        }
    }
}