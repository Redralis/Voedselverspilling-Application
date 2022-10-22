using System.Diagnostics;
using Domain;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VoedselVerspillingApp.Models;
using VoedselVerspillingApp.ViewModels;

namespace VoedselVerspillingApp.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMealBoxRepository _mealBoxRepository;
    private readonly IStudentRepository _studentRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IProductRepository _productRepository;

    public HomeController(ILogger<HomeController> logger, IMealBoxRepository mealBoxRepository,
        IStudentRepository studentRepository,
        IEmployeeRepository employeeRepository, IProductRepository productRepository)
    {
        _logger = logger;
        _mealBoxRepository = mealBoxRepository;
        _studentRepository = studentRepository;
        _employeeRepository = employeeRepository;
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
        if (User != null)
        {
            if (User.IsInRole("Employee"))
            {
                ViewBag.CanteenId = _employeeRepository.GetEmployeeByEmail(User.Identity!.Name!)!.Canteen.Id;
            }
        }
        
        return View(_mealBoxRepository.GetAvailableMealBoxes());
    }

    [HttpPost]
    public IActionResult AvailableMealBoxes(int id, string email)
    {
        var s = _mealBoxRepository.ReserveMealBox(id, email);
        TempData["Message"] = s;
        if (s == "Maaltijdbox gereserveerd!")
        {
            return RedirectToAction("AvailableMealBoxes");
        }
        return RedirectToAction("Error");
    }

    [HttpGet]
    public IActionResult ReservedMealBoxes(string email)
    {
        var id = _studentRepository.GetStudentByEmail(email)!.Id;
        return View(_mealBoxRepository.GetReservedMealBoxes(id));
    }

    [HttpPost]
    public IActionResult ReservedMealBoxes(int id)
    {
        _mealBoxRepository.CancelReservationForMealBox(id);
        return RedirectToAction("AvailableMealBoxes");
    }

    [HttpGet]
    public IActionResult CreateMealBox()
    {
        var list = _productRepository.GetProducts();
        var listCheck = list.Select(p => new CheckBoxItem { Name = p.Name, Id = p.Id, IsChecked = false }).ToList();
        ViewBag.Products = listCheck;
        var e = _employeeRepository.GetEmployeeByEmail(User.Identity!.Name!)!;
        ViewBag.CanteenId = e.CanteenId;
        ViewBag.City = e.Canteen.City;
        ViewBag.ServesWarmMeals = e.Canteen.ServesWarmMeals;
        var viewModel = new MealBoxViewModel()
        {
            Products = listCheck
        };
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult CreateMealBox(MealBox mealBox, MealBoxViewModel model)
    {
        var list = model.ProductIds.Select(id => new MealBox_Product() { ProductId = id, MealBoxId = mealBox.Id })
            .ToList();
        foreach (var id in model.ProductIds)
        {
            if (_productRepository.GetProduct(id)!.IsAlcoholic)
            {
                mealBox.IsEighteen = true;
            }
        }
        mealBox.MealBox_Product = list;
        _mealBoxRepository.CreateMealBox(mealBox);
        return RedirectToAction("AvailableMealBoxes");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpGet]
    [Authorize(Roles = "Employee")]
    public IActionResult EditMealBox(int id)
    {
        var model = new MealBoxViewModel();
        var box = _mealBoxRepository.GetMealBox(id)!;
        var list = _productRepository.GetProducts();
        var e = _employeeRepository.GetEmployeeByEmail(User.Identity!.Name!)!;
        ViewBag.ServesWarmMeals = e.Canteen.ServesWarmMeals;
        var listCheck = list.Select(p => new CheckBoxItem { Name = p.Name, Id = p.Id, IsChecked = false }).ToList();
        var productIds = box.MealBox_Product!.Select(p => p.ProductId).ToList();
        foreach (var c in listCheck.Where(c => productIds.Contains(c.Id)))
        {
            c.IsChecked = true;
        }

        model.Id = box.Id;
        model.Name = box.Name;
        model.PickUpTime = box.PickUpTime;
        model.PickUpBy = box.PickUpBy;
        model.IsEighteen = box.IsEighteen;
        model.Price = box.Price;
        model.MealType = box.MealType;
        model.StudentId = box.StudentId;
        model.Products = listCheck;
        model.CanteenId = box.CanteenId;
        model.IsWarmMeal = box.IsWarmMeal;
        return View(model);
    }

    [HttpPost]
    [Authorize(Roles = "Employee")]
    public IActionResult EditMealBox(MealBox mealBox, string s, MealBoxViewModel model)
    {
        switch (s)
        {
            case "edit":
            {
                if (mealBox.StudentId == null)
                {
                    var list = model.ProductIds
                        .Select(id => new MealBox_Product { ProductId = id, MealBoxId = mealBox.Id }).ToList();
                    _mealBoxRepository.RemoveProductsFromMealBox(mealBox.Id);
                    mealBox.MealBox_Product = list;
                    var alcoholicProductsCount = 0;
                    foreach (var id in model.ProductIds)
                    {
                        if (_productRepository.GetProduct(id)!.IsAlcoholic)
                        {
                            alcoholicProductsCount++;
                        }
                    }
                    mealBox.IsEighteen = alcoholicProductsCount > 0;
                    _mealBoxRepository.EditMealBox(mealBox);
                }

                break;
            }
            case "delete":
            {
                if (mealBox.StudentId == null)
                {
                    _mealBoxRepository.DeleteMealBox(mealBox);
                }

                break;
            }
        }

        return RedirectToAction("AvailableMealBoxes");
    }
}