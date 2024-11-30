using EM.API.Data;
using EM.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EM.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EmployeesController : Controller
    {
        private readonly EMDbContext emDbContext;

        public EmployeesController(EMDbContext EmDbContext)
        {
            emDbContext = EmDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await emDbContext.Employees.ToListAsync();
            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employeeRequest)
        {
            employeeRequest.Id = Guid.NewGuid();
            await emDbContext.Employees.AddAsync(employeeRequest);
            await emDbContext.SaveChangesAsync();

            return Ok(employeeRequest);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, [FromBody] Employee employeeRequest)
        {
            var existingEmployee = await emDbContext.Employees.FindAsync(id);
            if (existingEmployee == null)
            {
                return NotFound("Employee not found");
            }

            // Update fields
            existingEmployee.Name = employeeRequest.Name;
            existingEmployee.Email = employeeRequest.Email;
            existingEmployee.Phone = employeeRequest.Phone;
            existingEmployee.Salary = employeeRequest.Salary;
            existingEmployee.Department = employeeRequest.Department;

            // Save changes
            await emDbContext.SaveChangesAsync();
            return Ok(existingEmployee);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var existingEmployee = await emDbContext.Employees.FindAsync(id);
            if (existingEmployee == null)
            {
                return NotFound("Employee not found");
            }

            emDbContext.Employees.Remove(existingEmployee);
            await emDbContext.SaveChangesAsync();
            return Ok($"Employee with ID {id} has been deleted");
        }

    }
}
