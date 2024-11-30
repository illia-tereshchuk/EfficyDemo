using EfficyDemo.Api.DTOs;
using EfficyDemo.Dal;
using EfficyDemo.Dal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EfficyDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountersController : ControllerBase
    {
        private readonly EfficyDbContext _context;
        public CountersController(EfficyDbContext context)
        {
            _context = context;
        }
        [HttpPost("addCounter")]
        public async Task<IActionResult> AddCounter([FromQuery] int employeeId, [FromQuery] int value)
        {
            var counter = new Counter
            {
                Value = value,
                EmployeeId = employeeId
            };
            _context.Counters.Add(counter);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(new { message = "Counter added successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while adding the counter", details = ex.Message });
            }
        }
        // 2. Increase counter
        [HttpPatch("increaseCounter")]
        public async Task<IActionResult> IncreaseCounter([FromQuery] int counterId, [FromQuery] int value)
        {
            var counter = await _context.Counters.FindAsync(counterId);
            if (counter == null)
            {
                return NotFound();
            }
            counter.Value += value;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!_context.Counters.Any(e => e.Id == counterId))
            {
                return NotFound();
            }
            return NoContent();
        }
        // 7. Delete counter
        [HttpDelete("deleteCounter")]
        public async Task<IActionResult> DeleteCounter([FromQuery] int counterId)
        {
            var counter = await _context.Counters.FindAsync(counterId);
            if (counter == null)
            {
                return NotFound();
            }
            _context.Counters.Remove(counter);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        // 8. Get counters for employee
        [HttpGet("getForEmployee")]
        public async Task<ActionResult<IEnumerable<CounterDto>>> GetCountersForEmployee([FromQuery] int employeeId)
        {
            var counters = await _context.Counters
                .Where(c => c.EmployeeId == employeeId)
                .Select(c => new CounterDto
                {
                    Id = c.Id,
                    Value = c.Value,
                    EmployeeId = c.EmployeeId
                })
                .ToListAsync();
            if (counters == null || !counters.Any())
            {
                return NotFound();
            }
            return counters;
        }
    }
}
