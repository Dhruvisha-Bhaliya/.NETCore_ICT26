using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeMVC.Models;

namespace EmployeeMVC.Controllers
{
    public class IncrementDetailsController : Controller
    {
        private readonly Internal2024EmployeeDbContext _context;

        public IncrementDetailsController(Internal2024EmployeeDbContext context)
        {
            _context = context;
        }

        // GET: IncrementDetails
        public async Task<IActionResult> Index()
        {
            var internal2024EmployeeDbContext = _context.IncrementDetails.Include(i => i.Employee);
            return View(await internal2024EmployeeDbContext.ToListAsync());
        }

        // GET: IncrementDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incrementDetail = await _context.IncrementDetails
                .Include(i => i.Employee)
                .FirstOrDefaultAsync(m => m.IncrementId == id);
            if (incrementDetail == null)
            {
                return NotFound();
            }

            return View(incrementDetail);
        }

        // GET: IncrementDetails/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Name");
            return View();
        }

        // POST: IncrementDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IncrementId,EmployeeId,BasicSalary,Increment,NewBasicSalary")] IncrementDetail incrementDetail)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == incrementDetail.EmployeeId);
            decimal percent = 0;

            if (employee.Designation == Designation.GeneralManager)
                percent = 5;
            else if (employee.Designation == Designation.ProjectManager)
                percent = 10;
            else if (employee.Designation == Designation.TeamLeader)
                percent = 15;
            else if (employee.Designation == Designation.Developer)
                percent = 20;
            else if (employee.Designation == Designation.Tester)
                percent = 20;

            incrementDetail.Increment = incrementDetail.BasicSalary * percent / 100;
            incrementDetail.NewBasicSalary = incrementDetail.BasicSalary + incrementDetail.Increment;
            
            if (ModelState.IsValid)
            {
                _context.Add(incrementDetail);
                await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Name", incrementDetail.EmployeeId);
            return View(incrementDetail);
        }

        // GET: IncrementDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incrementDetail = await _context.IncrementDetails.FindAsync(id);
            if (incrementDetail == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Name", incrementDetail.EmployeeId);
            return View(incrementDetail);
        }

        // POST: IncrementDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IncrementId,EmployeeId,BasicSalary,Increment,NewBasicSalary")] IncrementDetail incrementDetail)
        {
            if (id != incrementDetail.IncrementId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(incrementDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncrementDetailExists(incrementDetail.IncrementId))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Name", incrementDetail.EmployeeId);
            return View(incrementDetail);
        }

        // GET: IncrementDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incrementDetail = await _context.IncrementDetails
                .Include(i => i.Employee)
                .FirstOrDefaultAsync(m => m.IncrementId == id);
            if (incrementDetail == null)
            {
                return NotFound();
            }

            return View(incrementDetail);
        }

        // POST: IncrementDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var incrementDetail = await _context.IncrementDetails.FindAsync(id);
            if (incrementDetail != null)
            {
                _context.IncrementDetails.Remove(incrementDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IncrementDetailExists(int id)
        {
            return _context.IncrementDetails.Any(e => e.IncrementId == id);
        }
    }
}
