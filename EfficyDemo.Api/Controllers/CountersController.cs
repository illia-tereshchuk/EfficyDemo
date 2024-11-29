using EfficyDemo.Api.DTOs;
using EfficyDemo.DataAccessLayer;
using EfficyDemo.DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EfficyDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountersController : ControllerBase
    {
        private readonly EfficyDbContext _context;
        private readonly ILogger<CountersController> _logger;
        public CountersController(EfficyDbContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Counter>> GetCounter(int id)
        {
            var counter = await _context.Counters
                //.Include(e => e.Team)
                //.Include(e => e.Counters)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (counter == null)
            {
                return NotFound();
            }

            return counter;
        }
        // Requirement #1 - add new counter for single employee
        [HttpPost]
        public async Task<ActionResult<Counter>> AddCounter(CounterDto counterDto) 
        {
            var counter = new Counter
            {
                Id = counterDto.Id,
                Value = counterDto.Value,
                EmployeeId = counterDto.EmployeeId
            };

            _context.Counters.Add(counter);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCounter), new { id = counter.Id }, counter);
        }
        // Requirement #2 - increment a single counter 
        [HttpPatch("{id}/increment")]
        public async Task<IActionResult> IncrementCounter(int id, IncrementCounterDto incrementCounterDto)
        {
            var counter = await _context.Counters.FindAsync(id);
            if (counter == null)
            {
                return NotFound();
            }
            counter.Value += incrementCounterDto.Value;
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
    }
}
