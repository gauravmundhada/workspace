using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Data;
using Microsoft.EntityFrameworkCore;
using API.Models;


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
        // [Route("ListEmp")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _context.Employees.ToListAsync();
            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employeeRequest)
        {
            await _context.AddAsync(employeeRequest);
            await _context.SaveChangesAsync();
            return Ok(employeeRequest);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetEmployee(string id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x=>x.Id==id);

            if(employee==null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateEmployee(string id, Employee updateEmployeeRequest)
        {
            var employee = await _context.Employees.FindAsync(id);

            if(employee==null)
            {
                return NotFound();
            }

            employee.Name = updateEmployeeRequest.Name;
            employee.Email = updateEmployeeRequest.Email;
            employee.Phone = updateEmployeeRequest.Phone;
            employee.Salary = updateEmployeeRequest.Salary;
            employee.Department = updateEmployeeRequest.Department;

            await _context.SaveChangesAsync();
            return Ok(employee);
            
        }
    }
}