using System.Diagnostics;
using Domain;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    [Authorize(Roles = "Student")]
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
    [Authorize(Roles = "Student")]
    public IActionResult ReservedMealBoxes(string email)
    {
        var id = _studentRepository.GetStudentByEmail(email)!.Id;
        return View(_mealBoxRepository.GetReservedMealBoxes(id));
    }

    [HttpPost]
    [Authorize(Roles = "Student")]
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
        var e = _employeeRepository.GetEmployeeByEmail(User.Identity!.Name!)!;
        ViewBag.Products = listCheck;
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
        if (ModelState.IsValid)
        {
            var list = model.ProductIds.Select(id => _productRepository.GetProduct(id)).ToList() ??
                       new List<Product?>();
            foreach (var id in model.ProductIds.Where(id => _productRepository.GetProduct(id)!.IsAlcoholic))
            {
                mealBox.IsEighteen = true;
            }

            mealBox.Products = list;
            _mealBoxRepository.CreateMealBox(mealBox);
            return RedirectToAction("AvailableMealBoxes");
        }

        // Code has to be repeated from create meal box or forms won't be validated.
        var productList = _productRepository.GetProducts();
        var listCheck = productList.Select(p => new CheckBoxItem { Name = p.Name, Id = p.Id, IsChecked = false })
            .ToList();
        var e = _employeeRepository.GetEmployeeByEmail(User.Identity!.Name!)!;
        ViewBag.Products = listCheck;
        ViewBag.CanteenId = e.CanteenId;
        ViewBag.City = e.Canteen.City;
        ViewBag.ServesWarmMeals = e.Canteen.ServesWarmMeals;
        model.Products = listCheck;
        return View(model);
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
        var productIds = box.Products.Select(p => p.Id).ToList();
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
        if (ModelState.IsValid)
        {
            switch (s)
            {
                case "edit":
                {
                    if (mealBox.StudentId == null)
                    {
                        var alcoholicProductsCount =
                            model.ProductIds.Count(id => _productRepository.GetProduct(id)!.IsAlcoholic);

                        var box = new MealBox()
                        {
                            Name = model.Name,
                            City = model.City,
                            PickUpTime = model.PickUpTime,
                            PickUpBy = model.PickUpBy,
                            IsEighteen = alcoholicProductsCount > 0,
                            Price = model.Price,
                            MealType = model.MealType,
                            CanteenId = model.CanteenId,
                            Products = model.ProductIds.Select(id => _productRepository.GetProduct(id)!).ToList()
                        };

                        _mealBoxRepository.DeleteMealBox(_mealBoxRepository.GetMealBox(model.Id)!);
                        _mealBoxRepository.CreateMealBox(box);
                        return RedirectToAction("AvailableMealBoxes");
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
        // Code needs to be repeated for validation to function
        var oldBox = _mealBoxRepository.GetMealBox(mealBox.Id)!;
        var list = _productRepository.GetProducts();
        var e = _employeeRepository.GetEmployeeByEmail(User.Identity!.Name!)!;
        ViewBag.ServesWarmMeals = e.Canteen.ServesWarmMeals;
        var listCheck = list.Select(p => new CheckBoxItem { Name = p.Name, Id = p.Id, IsChecked = false }).ToList();
        var productIds = oldBox.Products.Select(p => p.Id).ToList();
        foreach (var c in listCheck.Where(c => productIds.Contains(c.Id)))
        {
            c.IsChecked = true;
        }
        model.Products = listCheck;
        return View(model);
    }
}