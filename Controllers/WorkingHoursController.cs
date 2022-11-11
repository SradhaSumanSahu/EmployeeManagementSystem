using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Models;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingHoursController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public WorkingHoursController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: api/WorkingHours
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkingHour>>> GetWorkingHour()
        {
            return await _context.WorkingHour.ToListAsync();
        }

        // GET: api/WorkingHours/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkingHour>> GetWorkingHour(int id)
        {
            var workingHour = await _context.WorkingHour.FindAsync(id);

            if (workingHour == null)
            {
                return NotFound();
            }

            return workingHour;
        }

        // PUT: api/WorkingHours/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkingHour(int id, WorkingHour workingHour)
        {
            if (id != workingHour.CustoemerID)
            {
                return BadRequest();
            }

            _context.Entry(workingHour).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkingHourExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/WorkingHours
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WorkingHour>> PostWorkingHour(WorkingHour workingHour)
        {
            _context.WorkingHour.Add(workingHour);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkingHour", new { id = workingHour.CustoemerID }, workingHour);
        }

        // DELETE: api/WorkingHours/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WorkingHour>> DeleteWorkingHour(int id)
        {
            var workingHour = await _context.WorkingHour.FindAsync(id);
            if (workingHour == null)
            {
                return NotFound();
            }

            _context.WorkingHour.Remove(workingHour);
            await _context.SaveChangesAsync();

            return workingHour;
        }

        private bool WorkingHourExists(int id)
        {
            return _context.WorkingHour.Any(e => e.CustoemerID == id);
        }
    }
}
