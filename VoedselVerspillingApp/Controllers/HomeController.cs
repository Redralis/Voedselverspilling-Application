using System.Collections;
using System.Diagnostics;
using Domain;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using VoedselVerspillingApp.Models;

namespace VoedselVerspillingApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMealBoxRepository _mealBoxRepository;

    public HomeController(ILogger<HomeController> logger, IMealBoxRepository mealBoxRepository)
    {
        _logger = logger;
        _mealBoxRepository = mealBoxRepository;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult BeschikbareMaaltijden()
    {
        IEnumerable<MealBox> list = _mealBoxRepository.GetAvailableMealBoxes();
        return View(list);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}