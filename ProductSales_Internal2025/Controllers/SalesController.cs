using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductSales_Internal2025.Models;

namespace ProductSales_Internal2025.Controllers
{
    public class SalesController : Controller
    {
        private readonly IctproductSalesDbContext _context;

        public SalesController(IctproductSalesDbContext context)
        {
            _context = context;
        }

        // GET: Sales
        public async Task<IActionResult> Index()
        {
            var ictproductSalesDbContext = _context.Sales.Include(s => s.Product);
            return View(await ictproductSalesDbContext.ToListAsync());
        }



        // GET: Sales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _context.Sales
                .Include(s => s.Product)
                .FirstOrDefaultAsync(m => m.SalesId == id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // GET: Sales/Create    
        public async Task<IActionResult> Create(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            Sale sale = new Sale()
            {
                ProductId = product.ProductId,
                BasePrice = product.BasePrice
            };

            ViewBag.Name = product.ProductName;
            ViewBag.Price = product.BasePrice;

            return View(sale);
        }

        // POST: Sales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,SaleDate,Discount,BasePrice,SalePrice,Gst,Totalamount")] Sale sale)
        {
            sale.SalePrice = sale.BasePrice - (sale.BasePrice * sale.Discount / 100);

            decimal gstRate = 0;

            if (sale.BasePrice >= 1000 && sale.BasePrice < 3000)
                gstRate = 2;
            else if (sale.BasePrice >= 3000 && sale.BasePrice < 5000)
                gstRate = 5;
            else if (sale.BasePrice >= 5000)
                gstRate = 9;

            sale.Gst = sale.SalePrice * gstRate / 100;
            sale.Totalamount = sale.SalePrice + sale.Gst;

            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // GET: Sales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _context.Sales.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", sale.ProductId);
            return View(sale);
        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,SaleDate,Discount,BasePrice,SalePrice,Gst,Totalamount")] Sale sale)
        {
            if (id != sale.SalesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleExists(sale.SalesId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", sale.ProductId);
            return View(sale);
        }

        // GET: Sales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _context.Sales
                .Include(s => s.Product)
                .FirstOrDefaultAsync(m => m.SalesId == id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sale = await _context.Sales.FindAsync(id);
            if (sale != null)
            {
                _context.Sales.Remove(sale);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleExists(int id)
        {
            return _context.Sales.Any(e => e.SalesId == id);
        }
    }
}
