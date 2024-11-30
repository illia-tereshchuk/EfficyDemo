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
        // *. Get team without employees
        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeam(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            return Ok(team);
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
        [HttpGet("getAll")]
        public async Task<ActionResult<IEnumerable<TeamDto>>> GetTeamsWithStepCounts()
        {
            var teams = await _context.Teams
                .Include(t => t.Employees)
                .ThenInclude(e => e.Counters)
                .ToListAsync();
            var teamStepCounts = teams.Select(t => new TeamDto
            {
                Id = t.Id,
                Name = t.Name,
                TotalSteps = t.Employees.SelectMany(e => e.Counters).Sum(c => c.Value)
            }).ToList();
            return Ok(teamStepCounts);
        }
        // 5. For single team, list all employees with steps
        [HttpGet("{id}/employees")]
        public async Task<ActionResult<IEnumerable<EmployeeStepsDto>>> GethEmployeesWithSteps(int id)
        {
            var team = await _context.Teams
                .Include(t => t.Employees)
                .ThenInclude(e => e.Counters)
                .FirstOrDefaultAsync(t => t.Id == id);
            if (team == null)
            {
                return NotFound();
            }
            var result = team.Employees.Select(e => new EmployeeStepsDto
            {
                Id = e.Id,
                Name = e.Name,
                TotalSteps = e.Counters.Sum(c => c.Value)
            }).ToList();
            return Ok(result);
        }
        // 6. Add new team
        [HttpPost("add")]
        public async Task<ActionResult<Team>> AddTeam(string name)
        {
            // Check if a team with the same name already exists
            var existingTeam = await _context.Teams.FirstOrDefaultAsync(t => t.Name == name);
            if (existingTeam != null)
            {
                return Conflict(new { message = "A team with the same name already exists." });
            }
            var team = new Team
            {
                Name = name
            };
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTeam), new { id = team.Id }, team);
        }

        // 6. Delete existing team by Id
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
