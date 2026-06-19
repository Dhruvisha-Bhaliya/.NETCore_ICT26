using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductSales_Internal2025.Models;

namespace ProductSales_Internal2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesAPIController : ControllerBase
    {
        private readonly IctproductSalesDbContext _context;

        public SalesAPIController(IctproductSalesDbContext context)
        {
            _context = context;
        }

        // GET: api/SalesAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sale>>> GetSales()
        {
            var sales = await _context.Sales
       .Include(s => s.Product)
       .ToListAsync();

            return Ok(sales);
        }

        // GET: api/SalesAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sale>> GetSale(int id)
        {
            var sale = await _context.Sales.FindAsync(id);

            if (sale == null)
            {
                return NotFound();
            }

            return sale;
        }

        // PUT: api/SalesAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSale(int id, Sale sale)
        {
            if (id != sale.SalesId)
            {
                return BadRequest();
            }

            _context.Entry(sale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleExists(id))
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

        // POST: api/SalesAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sale>> PostSale(Sale sale)
        {
            // Correct calculation
            sale.SalePrice = sale.BasePrice - (sale.BasePrice * sale.Discount / 100);

            decimal gstRate = 0;

            if (sale.BasePrice >= 1000 && sale.BasePrice < 3000)
                gstRate = 0.02m;
            else if (sale.BasePrice >= 3000 && sale.BasePrice < 5000)
                gstRate = 0.05m;
            else if (sale.BasePrice >= 5000)
                gstRate = 0.09m;

            sale.Gst = sale.SalePrice * gstRate;
            sale.Totalamount = sale.SalePrice + sale.Gst;

            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSale", new { id = sale.SalesId }, sale);
        }

        // DELETE: api/SalesAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSale(int id)
        {
            var sale = await _context.Sales.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }

            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SaleExists(int id)
        {
            return _context.Sales.Any(e => e.SalesId == id);
        }
    }
}
