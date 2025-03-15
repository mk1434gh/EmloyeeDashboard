using EmloyeeDashboard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmloyeeDashboard.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = _context.Employees.ToList();
            return Ok(employees);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] Employee updatedEmployee)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return NotFound();

            employee.Name = updatedEmployee.Name;
            await _context.SaveChangesAsync();
            return Ok(new { message = "Employee updated successfully" });
        }

        [HttpPost("AddEmployee")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddEmployee([FromBody] Employee newEmployee)
        {
            var employee = _context.Employees.FirstOrDefault(x => x.Name == newEmployee.Name);
            if (employee != null) return Conflict(new { message = "Employee already exists" });
            _context.Employees.Add(new Employee { Name = newEmployee.Name });
            await _context.SaveChangesAsync();
            return Ok(new { message = "Employee added successfully" });
        }
    }
}
