using Lab_ASP.Data;
using Lab_ASP.Models;
using Lab_ASP.Models.ViewModels;
using Lab_ASP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab_ASP.Controllers
{
    public class EquipmentController : Controller
    {
        /*private static readonly List<EquipmentDetailViewModel> equipment = new()
        {
            new EquipmentDetailViewModel { ID = 1, Make = "Cool", Model = "Bike", ImgURL = "/images/bike.jpg" },
            new EquipmentDetailViewModel { ID = 2, Make = "Nice", Model = "Scooter", ImgURL = "/images/scooter.jpg" },
            new EquipmentDetailViewModel { ID = 3, Make = "Epic", Model = "Skateboard", ImgURL = "/images/skateboard.jpg" }
        };*/

        /*public IActionResult Index()
        {
            var equipmentList = equipment.Select(e => new EquipmentItemViewModel
            {
                ID = e.ID,
                Make = e.Make,
                Model = e.Model,
                ImgURL = e.ImgURL
            }).ToList();

            return View(equipmentList);
        }*/
        /*public IActionResult Details(int id)
        {
            var equipmentDetail = equipment.FirstOrDefault(e => e.ID == id);
            if (equipmentDetail == null)
            {
                return NotFound();
            }
            return View(equipmentDetail);
        }*/
        /*private readonly ApplicationDbContext _context;

        public EquipmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var equipments = await _context.Equipments
                .Select(e => new EquipmentItemViewModel
                {
                    ID = e.Id,
                    Make = e.Make,
                    Model = e.Model,
                    ImgURL = e.ImageURL
                }).ToListAsync();

            return View(equipments);
        }

        public async Task<IActionResult> Details(int id)
        {
            var equipmentDetail = await _context.Equipments
                .Where(e => e.Id == id)
                .Select(e => new EquipmentDetailViewModel
                {
                    ID = e.Id,
                    Make = e.Make,
                    Model = e.Model,
                    ImgURL = e.ImageURL,
                    Year = e.Year,
                    Description = e.Description
                }).FirstOrDefaultAsync();
            if (equipmentDetail == null)
            {
                return NotFound();
            }
            return View(equipmentDetail);
        }*/
        private readonly IEquipmentRepository _equipmentRepository;
        public EquipmentController(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public async Task<IActionResult> Index()
        {
            var equipments = await _equipmentRepository.GetAllAsync();
            var viewModel = equipments.Select(e => new EquipmentItemViewModel
            {
                ID = e.Id,
                Make = e.Make,
                Model = e.Model,
                ImgURL = e.ImageURL
            }).ToList();
            return View(viewModel);
        }
        public async Task<IActionResult> Details(int id)
        {
            var equipments = await _equipmentRepository.GetByIdAsync(id);

            if (equipments == null)
            {
                return NotFound();
            }
            var viewModel = new EquipmentDetailViewModel
            {
                ID = equipments.Id,
                Make = equipments.Make,
                Model = equipments.Model,
                ImgURL = equipments.ImageURL,
                Year = equipments.Year,
                Description = equipments.Description
            };
            return View(viewModel);
        }
    }
}
