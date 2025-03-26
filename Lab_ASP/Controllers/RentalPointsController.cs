using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab_ASP.Data;
using Lab_ASP.Models;

namespace Lab_ASP.Controllers
{
    public class RentalPointsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RentalPointsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RentalPoints
        public async Task<IActionResult> Index()
        {
            return View(await _context.RentalPoints.ToListAsync());
        }

        // GET: RentalPoints/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalPoint = await _context.RentalPoints
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rentalPoint == null)
            {
                return NotFound();
            }

            return View(rentalPoint);
        }

        // GET: RentalPoints/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RentalPoints/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address")] RentalPoint rentalPoint)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rentalPoint);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rentalPoint);
        }

        // GET: RentalPoints/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalPoint = await _context.RentalPoints.FindAsync(id);
            if (rentalPoint == null)
            {
                return NotFound();
            }
            return View(rentalPoint);
        }

        // POST: RentalPoints/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address")] RentalPoint rentalPoint)
        {
            if (id != rentalPoint.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentalPoint);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalPointExists(rentalPoint.Id))
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
            return View(rentalPoint);
        }

        // GET: RentalPoints/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalPoint = await _context.RentalPoints
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rentalPoint == null)
            {
                return NotFound();
            }

            return View(rentalPoint);
        }

        // POST: RentalPoints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rentalPoint = await _context.RentalPoints.FindAsync(id);
            if (rentalPoint != null)
            {
                _context.RentalPoints.Remove(rentalPoint);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalPointExists(int id)
        {
            return _context.RentalPoints.Any(e => e.Id == id);
        }
    }
}
