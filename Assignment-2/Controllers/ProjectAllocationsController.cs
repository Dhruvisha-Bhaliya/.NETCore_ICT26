using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment_2.Models;

namespace Assignment_2.Controllers
{
    public class ProjectAllocationsController : Controller
    {
        private readonly Ict2projectAllocationDbContext _context;

        public ProjectAllocationsController(Ict2projectAllocationDbContext context)
        {
            _context = context;
        }

        // GET: ProjectAllocations
        public async Task<IActionResult> Index()
        {
            var ict2projectAllocationDbContext = _context.ProjectAllocations.Include(p => p.Employee).Include(p => p.Project);
            return View(await ict2projectAllocationDbContext.ToListAsync());
        }

        // GET: ProjectAllocations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectAllocation = await _context.ProjectAllocations
                .Include(p => p.Employee)
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.AllocationId == id);
            if (projectAllocation == null)
            {
                return NotFound();
            }

            return View(projectAllocation);
        }

        // GET: ProjectAllocations/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeName");
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectName");
            return View();
        }

        // POST: ProjectAllocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AllocationId,EmployeeId,ProjectId,AllocationDate,Role,IsActive")] ProjectAllocation projectAllocation)
        {
            if (ModelState.IsValid)
            {
                projectAllocation.IsActive = true;
                _context.Add(projectAllocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeName", projectAllocation.EmployeeId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectName", projectAllocation.ProjectId);
            return View(projectAllocation);
        }

        // GET: ProjectAllocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectAllocation = await _context.ProjectAllocations.FindAsync(id);
            if (projectAllocation == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeName", projectAllocation.EmployeeId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectName", projectAllocation.ProjectId);
            return View(projectAllocation);
        }

        // POST: ProjectAllocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AllocationId,EmployeeId,ProjectId,AllocationDate,Role,IsActive")] ProjectAllocation projectAllocation)
        {
            if (id != projectAllocation.AllocationId)
            {
                return NotFound();
            }

                if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectAllocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectAllocationExists(projectAllocation.AllocationId))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeName", projectAllocation.EmployeeId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectName", projectAllocation.ProjectId);
            return View(projectAllocation);
        }

        // GET: ProjectAllocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectAllocation = await _context.ProjectAllocations
                .Include(p => p.Employee)
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.AllocationId == id);
            if (projectAllocation == null)
            {
                return NotFound();
            }

            return View(projectAllocation);
        }

        // POST: ProjectAllocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projectAllocation = await _context.ProjectAllocations.FindAsync(id);
            if (projectAllocation != null)
            {
                _context.ProjectAllocations.Remove(projectAllocation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectAllocationExists(int id)
        {
            return _context.ProjectAllocations.Any(e => e.AllocationId == id);
        }
    }
}
