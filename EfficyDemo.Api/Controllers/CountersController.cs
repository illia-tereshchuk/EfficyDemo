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
        [HttpGet("get/{id}")]
        public async Task<ActionResult<Counter>> GetCounter(int id)
        {
            var counter = await _context.Counters
                .FirstOrDefaultAsync(e => e.Id == id);
            if (counter == null)
            {
                return NotFound();
            }
            return counter;
        }
        // 1. Add counter
        [HttpPost("add")]
        public async Task<ActionResult<Counter>> AddCounter(CounterAddDto counterDto) 
        {
            var counter = new Counter
            {
                Value = counterDto.Value,
                EmployeeId = counterDto.EmployeeId
            };
            _context.Counters.Add(counter);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCounter), new { id = counter.Id }, counter);
        }
        // 2. Increase counter
        [HttpPatch("increase/{id}")]
        public async Task<IActionResult> IncrementCounter(int id, CounterIncreaseDto increaseCounterDto)
        {
            var counter = await _context.Counters.FindAsync(id);
            if (counter == null)
            {
                return NotFound();
            }
            counter.Value += increaseCounterDto.Value;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!_context.Counters.Any(e => e.Id == id))
            {
                return NotFound();
            }
            return NoContent();
        }
        // 7. Delete counter
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCounter(int id)
        {
            var counter = await _context.Counters.FindAsync(id);
            if (counter == null)
            {
                return NotFound();
            }
            _context.Counters.Remove(counter);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        // 8. Get counters for employee
        [HttpGet("employee/{id}")]
        public async Task<ActionResult<IEnumerable<CounterDto>>> GetCountersForEmployee(int id)
        {
            var counters = await _context.Counters
                .Where(c => c.EmployeeId == id)
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
