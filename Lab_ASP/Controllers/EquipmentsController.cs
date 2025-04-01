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
    public class EquipmentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EquipmentsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Equipments
        public async Task<IActionResult> Index()
        {
            var equipments = await _context.Equipments.Include(v => v.EquipmentType).Include(v => v.RentalPoint).ToListAsync();
            var viewModel = _mapper.Map<List<EquipmentItemViewModel>>(equipments);
            return View(viewModel);
        }

        // GET: Equipments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var equipments = await _context.Equipments
                .Include(v => v.EquipmentType)
                .Include(v => v.RentalPoint)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (equipments == null) return NotFound();

            var viewModel = _mapper.Map<EquipmentDetailViewModel>(equipments);
            return View(viewModel);
        }

        // GET: Equipments/Create
        public async Task<IActionResult> Create()
        {
            ViewData["EquipmentTypeId"] = new SelectList(await _context.EquipmentTypes.ToListAsync(), "Id", "Name");
            ViewData["RentalPointId"] = new SelectList(await _context.RentalPoints.ToListAsync(), "Id", "Address");
            return View();
        }

        // POST: Equipments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EquipmentDetailViewModel equip)
        {
            if (!ModelState.IsValid)
            {
                ViewData["EquipmentTypeId"] = new SelectList(await _context.EquipmentTypes.ToListAsync(), "Id", "Name");
                ViewData["RentalPointId"] = new SelectList(await _context.RentalPoints.ToListAsync(), "Id", "Address");
                return View(equip);
            }

            var equipment = _mapper.Map<Equipment>(equip);
            _context.Equipments.Add(equipment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Equipments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var equipment = await _context.Equipments.FindAsync(id);
            if (equipment == null) return NotFound();

            var viewModel = _mapper.Map<EquipmentDetailViewModel>(equipment);
            ViewData["EquipmentTypeId"] = new SelectList(await _context.EquipmentTypes.ToListAsync(), "Id", "Name", equipment.EquipmentTypeId);
            ViewData["RentalPointId"] = new SelectList(await _context.RentalPoints.ToListAsync(), "Id", "Address", equipment.RentalPointId);
            return View(viewModel);
        }

        // POST: Equipments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EquipmentDetailViewModel equip)
        {
            if (id != equip.Id) return NotFound();

            if (!ModelState.IsValid)
            {
                ViewData["EquipmentTypeId"] = new SelectList(await _context.EquipmentTypes.ToListAsync(), "Id", "Name", equip.EquipmentTypeId);
                ViewData["RentalPointId"] = new SelectList(await _context.RentalPoints.ToListAsync(), "Id", "Address", equip.RentalPointId);
                return View(equip);
            }

            try
            {
                var equipment = _mapper.Map<Equipment>(equip);
                _context.Equipments.Update(equipment);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipmentExists(equip.Id)) return NotFound();
                else throw;
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Equipments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var equipment = await _context.Equipments
                .Include(v => v.EquipmentType)
                .Include(v => v.RentalPoint)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (equipment == null) return NotFound();

            var viewModel = _mapper.Map<EquipmentDetailViewModel>(equipment);
            return View(viewModel);
        }

        // POST: Equipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipment = await _context.Equipments.FindAsync(id);
            if (equipment != null)
            {
                _context.Equipments.Remove(equipment);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool EquipmentExists(int id)
        {
            return _context.Equipments.Any(e => e.Id == id);
        }
    }
}
