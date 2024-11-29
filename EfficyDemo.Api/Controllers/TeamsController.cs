using EfficyDemo.Api.DTOs;
using EfficyDemo.Dal;
using EfficyDemo.Dal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EfficyDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly EfficyDbContext _context;
        public TeamsController(EfficyDbContext context)
        {
            _context = context;
        }
        //3. Steps by team
        [HttpGet("steps/{id}")]
        public async Task<ActionResult<int>> GetTotalSteps(int id)
        {
            var team = await _context.Teams
                .Include(t => t.Employees)
                .ThenInclude(e => e.Counters)
                .FirstOrDefaultAsync(t => t.Id == id);
            if (team == null)
            {
                return NotFound();
            }
            var totalSteps = team.Employees
                .SelectMany(e => e.Counters)
                .Sum(c => c.Value);
            return Ok(totalSteps);
        }
        // 4. List all teams with steps summarized
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<TeamsAllDto>>> GetTeamsWithStepCounts()
        {
            var teams = await _context.Teams
                .Include(t => t.Employees)
                .ThenInclude(e => e.Counters)
                .ToListAsync();
            var teamStepCounts = teams.Select(t => new TeamsAllDto
            {
                Id = t.Id,
                Name = t.Name,
                TotalSteps = t.Employees.SelectMany(e => e.Counters).Sum(c => c.Value)
            }).ToList();
            return Ok(teamStepCounts);
        }
        // 5. For single team, list all employees with steps
        [HttpGet("{id}/employees")]
        public async Task<ActionResult<TeamEmployeesDto>> GetTeamWithEmployees(int id)
        {
            var team = await _context.Teams
                .Include(t => t.Employees)
                .ThenInclude(e => e.Counters)
                .FirstOrDefaultAsync(t => t.Id == id);
            if (team == null)
            {
                return NotFound();
            }
            var employeeStepCounts = team.Employees.Select(e => new EmployeeStepsDto
            {
                Id = e.Id,
                Name = e.Name,
                TotalSteps = e.Counters.Sum(c => c.Value)
            }).ToList();
            var result = new TeamEmployeesDto
            {
                Id = team.Id,
                Name = team.Name,
                EmployeesSteps = employeeStepCounts
            };

            return Ok(result);
        }
    }
}
