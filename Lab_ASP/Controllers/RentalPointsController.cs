using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab_ASP.Data;
using Lab_ASP.Models;
using AutoMapper;
using Lab_ASP.Models.ViewModels;

namespace Lab_ASP.Controllers
{
    public class RentalPointsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RentalPointsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: RentalPoints
        public async Task<IActionResult> Index()
        {
            var rentalPoints = await _context.RentalPoints.ToListAsync();
            var viewModel = _mapper.Map<List<RentalPointViewModel>>(rentalPoints);
            return View(viewModel);
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

            var viewModel = _mapper.Map<RentalPointViewModel>(rentalPoint);
            return View(viewModel);
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
        public async Task<IActionResult> Create([Bind("Id,Name,Address,PhoneNumber,Email")] RentalPointViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var rentalPoint = _mapper.Map<RentalPoint>(model);
            _context.Add(rentalPoint);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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

            var viewModel = _mapper.Map<RentalPointViewModel>(rentalPoint);
            return View(viewModel);
        }

        // POST: RentalPoints/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,PhoneNumber,Email")] RentalPointViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
               return View(model);
            }
            try
            {
                var rentalPoint = _mapper.Map<RentalPoint>(model);
                _context.Update(rentalPoint);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentalPointExists(model.Id))
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

            var viewModel = _mapper.Map<RentalPointViewModel>(rentalPoint);
            return View(viewModel);
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
