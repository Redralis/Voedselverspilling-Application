using System.Collections;
using System.Diagnostics;
using System.Dynamic;
using Domain;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using VoedselVerspillingApp.Models;

namespace VoedselVerspillingApp.Controllers;

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

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult AvailableMealBoxes()
    {
        dynamic model = new ExpandoObject();
        model.mealBoxes = _mealBoxRepository.GetAvailableMealBoxes();
        return View(model);
    }
    
    [HttpGet]
    public IActionResult EditMealBox(int id)
    {
        return View(_mealBoxRepository.GetMealBox(id));
    }

    [HttpPost]
    public IActionResult EditMealBox(MealBox mealBox)
    {
        _mealBoxRepository.EditMealBox(mealBox);
        return View();
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
        return View();
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}