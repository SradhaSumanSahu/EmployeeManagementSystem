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
    public class DesignationsController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public DesignationsController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: api/Designations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Designations>>> GetEmployeeDesignation()
        {
            return await _context.EmployeeDesignation.ToListAsync();
        }

        // GET: api/Designations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Designations>> GetDesignations(int id)
        {
            var designations = await _context.EmployeeDesignation.FindAsync(id);

            if (designations == null)
            {
                return NotFound();
            }

            return designations;
        }

        // PUT: api/Designations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDesignations(int id, Designations designations)
        {
            if (id != designations.ID)
            {
                return BadRequest();
            }

            _context.Entry(designations).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DesignationsExists(id))
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

        // POST: api/Designations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Designations>> PostDesignations(Designations designations)
        {
            _context.EmployeeDesignation.Add(designations);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDesignations", new { id = designations.ID }, designations);
        }

        // DELETE: api/Designations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Designations>> DeleteDesignations(int id)
        {
            var designations = await _context.EmployeeDesignation.FindAsync(id);
            if (designations == null)
            {
                return NotFound();
            }

            _context.EmployeeDesignation.Remove(designations);
            await _context.SaveChangesAsync();

            return designations;
        }

        private bool DesignationsExists(int id)
        {
            return _context.EmployeeDesignation.Any(e => e.ID == id);
        }
    }
}
