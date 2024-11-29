using Microsoft.AspNetCore.Mvc;
using EfficyDemo.Dal;
using EfficyDemo.Dal.Models;
using Microsoft.EntityFrameworkCore;

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
                //.Include(e => e.Team)
                //.Include(e => e.Counters)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }
    }
}
