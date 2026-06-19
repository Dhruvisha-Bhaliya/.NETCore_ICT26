using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeAPI.Models;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncrementDetailsController : ControllerBase
    {
        private readonly Internal2024EmployeeDbContext _context;

        public IncrementDetailsController(Internal2024EmployeeDbContext context)
        {
            _context = context;
        }

        // GET: api/IncrementDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IncrementDetail>>> GetIncrementDetails()
        {
            return await _context.IncrementDetails.ToListAsync();
        }

        // GET: api/IncrementDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IncrementDetail>> GetIncrementDetail(int id)
        {
            var incrementDetail = await _context.IncrementDetails.FindAsync(id);

            if (incrementDetail == null)
            {
                return NotFound();
            }

            return incrementDetail;
        }

        // PUT: api/IncrementDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncrementDetail(int id, IncrementDetail incrementDetail)
        {
            if (id != incrementDetail.IncrementId)
            {
                return BadRequest();
            }

            _context.Entry(incrementDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncrementDetailExists(id))
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

        // POST: api/IncrementDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IncrementDetail>> PostIncrementDetail(IncrementDetail incrementDetail)
        {
            _context.IncrementDetails.Add(incrementDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIncrementDetail", new { id = incrementDetail.IncrementId }, incrementDetail);
        }

        // DELETE: api/IncrementDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncrementDetail(int id)
        {
            var incrementDetail = await _context.IncrementDetails.FindAsync(id);
            if (incrementDetail == null)
            {
                return NotFound();
            }

            _context.IncrementDetails.Remove(incrementDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IncrementDetailExists(int id)
        {
            return _context.IncrementDetails.Any(e => e.IncrementId == id);
        }
    }
}
