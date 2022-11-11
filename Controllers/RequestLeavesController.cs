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
    public class RequestLeavesController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public RequestLeavesController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: api/RequestLeaves
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequestLeave>>> GetRequestLeaves()
        {
            return await _context.RequestLeaves.ToListAsync();
        }

        // GET: api/RequestLeaves/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RequestLeave>> GetRequestLeave(int id)
        {
            var requestLeave = await _context.RequestLeaves.FindAsync(id);

            if (requestLeave == null)
            {
                return NotFound();
            }

            return requestLeave;
        }

        // PUT: api/RequestLeaves/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequestLeave(int id, RequestLeave requestLeave)
        {
            if (id != requestLeave.RequestLeaveId)
            {
                return BadRequest();
            }

            _context.Entry(requestLeave).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestLeaveExists(id))
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

        // POST: api/RequestLeaves
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RequestLeave>> PostRequestLeave(RequestLeave requestLeave)
        {
            _context.RequestLeaves.Add(requestLeave);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequestLeave", new { id = requestLeave.RequestLeaveId }, requestLeave);
        }

        // DELETE: api/RequestLeaves/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RequestLeave>> DeleteRequestLeave(int id)
        {
            var requestLeave = await _context.RequestLeaves.FindAsync(id);
            if (requestLeave == null)
            {
                return NotFound();
            }

            _context.RequestLeaves.Remove(requestLeave);
            await _context.SaveChangesAsync();

            return requestLeave;
        }

        private bool RequestLeaveExists(int id)
        {
            return _context.RequestLeaves.Any(e => e.RequestLeaveId == id);
        }
    }
}
