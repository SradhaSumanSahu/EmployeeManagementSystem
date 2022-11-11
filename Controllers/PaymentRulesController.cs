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
    public class PaymentRulesController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public PaymentRulesController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: api/PaymentRules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentRule>>> GetPaymentRules()
        {
            return await _context.PaymentRules.ToListAsync();
        }

        // GET: api/PaymentRules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentRule>> GetPaymentRule(int id)
        {
            var paymentRule = await _context.PaymentRules.FindAsync(id);

            if (paymentRule == null)
            {
                return NotFound();
            }

            return paymentRule;
        }

        // PUT: api/PaymentRules/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentRule(int id, PaymentRule paymentRule)
        {
            if (id != paymentRule.PaymentID)
            {
                return BadRequest();
            }

            _context.Entry(paymentRule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentRuleExists(id))
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

        // POST: api/PaymentRules
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PaymentRule>> PostPaymentRule(PaymentRule paymentRule)
        {
            _context.PaymentRules.Add(paymentRule);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentRule", new { id = paymentRule.PaymentID }, paymentRule);
        }

        // DELETE: api/PaymentRules/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PaymentRule>> DeletePaymentRule(int id)
        {
            var paymentRule = await _context.PaymentRules.FindAsync(id);
            if (paymentRule == null)
            {
                return NotFound();
            }

            _context.PaymentRules.Remove(paymentRule);
            await _context.SaveChangesAsync();

            return paymentRule;
        }

        private bool PaymentRuleExists(int id)
        {
            return _context.PaymentRules.Any(e => e.PaymentID == id);
        }
    }
}
