using System.Collections;
using System.Diagnostics;
using System.Dynamic;
using Domain;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VoedselVerspillingApp.Models;

namespace VoedselVerspillingApp.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMealBoxRepository _mealBoxRepository;
    private readonly IProductRepository _productRepository;

    public HomeController(ILogger<HomeController> logger, IMealBoxRepository mealBoxRepository, IProductRepository productRepository)
    {
        _logger = logger;
        _mealBoxRepository = mealBoxRepository;
        _productRepository = productRepository;
    }

    [AllowAnonymous]
    public IActionResult Index()
    {
        return View();
    }

    [AllowAnonymous]
    [HttpGet]
    public IActionResult AvailableMealBoxes()
    {
        return View(_mealBoxRepository.GetAvailableMealBoxes());
    }

    [HttpGet]
    public IActionResult CreateMealBox()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateMealBox(MealBox mealBox)
    {
        _mealBoxRepository.CreateMealBox(mealBox);
        return RedirectToAction("AvailableMealBoxes");
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    [HttpGet]
    public IActionResult EditMealBox(int id)
    {
        return View(_mealBoxRepository.GetMealBox(id));
    }

    [HttpPost]
    public IActionResult EditMealBox(MealBox mealBox, string s)
    {
        if (s.Equals("edit"))
        {
            _mealBoxRepository.EditMealBox(mealBox);
        } else if (s.Equals("delete"))
        {
            _mealBoxRepository.DeleteMealBox(mealBox);
        }
        return RedirectToAction("AvailableMealBoxes");
    }
}