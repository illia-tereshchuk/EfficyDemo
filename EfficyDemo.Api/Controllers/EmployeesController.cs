using Microsoft.AspNetCore.Mvc;
using EfficyDemo.Dal;
using EfficyDemo.Dal.Models;
using Microsoft.EntityFrameworkCore;
using EfficyDemo.Api.DTOs;

namespace EfficyDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EfficyDbContext _context;

        public EmployeesController(EfficyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.Employees
                //.Include(e => e.Team)
                //.Include(e => e.Counters)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }
        // BONUS: Switch employee's team
        [HttpPost("switchTeam")]
        public async Task<IActionResult> SwitchTeam([FromQuery] int employeeId, [FromQuery] int newTeamId)
        {
            var employee = await _context.Employees.FindAsync(employeeId);
            if (employee == null)
            {
                return NotFound(new { message = "Employee not found." });
            }

            var team = await _context.Teams.FindAsync(newTeamId);
            if (team == null)
            {
                return NotFound(new { message = "Team not found." });
            }

            employee.TeamId = newTeamId;
            await _context.SaveChangesAsync();

            return Ok(new { message = "Employee team updated successfully." });
        }
        // Get all employees
        [HttpGet("getAll")]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAll()
        {
            var employees = await _context.Employees
                .Include(e => e.Team)
                .Include(e => e.Counters)
                .ToListAsync();

            var employeeDtos = employees.Select(e => new EmployeeDto
            {
                Id = e.Id,
                Name = e.Name,
                TeamId = e.TeamId,
                TeamName = e.Team.Name,
                TotalSteps = e.Counters.Sum(c => c.Value)
            }).ToList();

            return Ok(employeeDtos);
        }
    }
}
