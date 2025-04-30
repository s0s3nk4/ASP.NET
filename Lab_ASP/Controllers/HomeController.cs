using AutoMapper;
using Lab_ASP.Data;
using Lab_ASP.Models;
using Lab_ASP.Models.ViewModels;
using Lab_ASP.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Lab_ASP.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IMapper mapper)
    {
        _logger = logger;
        _context = context;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        var equipments = await _context.Equipments
        .Include(e => e.EquipmentType)
        .ToListAsync();

        var viewModel = _mapper.Map<List<EquipmentItemViewModel>>(equipments);
        return View(viewModel);
    }

    public async Task<IActionResult> Details(int id)
    {
        var equipment = await _context.Equipments
        .Include(e => e.EquipmentType)
        .FirstOrDefaultAsync(e => e.Id == id);

        if (equipment == null)
        {
            return NotFound();
        }

        var viewModel = _mapper.Map<EquipmentDetailViewModel>(equipment);
        return View(viewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
