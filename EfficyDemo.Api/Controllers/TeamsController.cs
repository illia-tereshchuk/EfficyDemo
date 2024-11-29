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
        // Requirement #3 - get total steps for a single team
        [HttpGet("{id}/steps")]
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
        // Requirement #4 - list all teams and show their step counts
        [HttpGet("/teams-with-steps")]
        public async Task<ActionResult<IEnumerable<TeamStepCountDto>>> GetTeamsWithStepCounts()
        {
            var teams = await _context.Teams
                .Include(t => t.Employees)
                .ThenInclude(e => e.Counters)
                .ToListAsync();
            var teamStepCounts = teams.Select(t => new TeamStepCountDto
            {
                Id = t.Id,
                Name = t.Name,
                TotalSteps = t.Employees.SelectMany(e => e.Counters).Sum(c => c.Value)
            }).ToList();
            return Ok(teamStepCounts);
        }
        // Requirement #5 - list all employees and their step count for a certain team
        [HttpGet("{id}/employees-with-steps")]
        public async Task<ActionResult<TeamWithEmployeeStepCountsDto>> GetTeamWithEmployeeStepCounts(int id)
        {
            var team = await _context.Teams
                .Include(t => t.Employees)
                .ThenInclude(e => e.Counters)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (team == null)
            {
                return NotFound();
            }

            var employeeStepCounts = team.Employees.Select(e => new EmployeeStepCountDto
            {
                Id = e.Id,
                Name = e.Name,
                TotalSteps = e.Counters.Sum(c => c.Value)
            }).ToList();

            var result = new TeamWithEmployeeStepCountsDto
            {
                Id = team.Id,
                Name = team.Name,
                Employees = employeeStepCounts
            };

            return Ok(result);
        }
    }
}
