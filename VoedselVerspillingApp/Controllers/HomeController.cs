using System.Collections;
using System.Diagnostics;
using System.Dynamic;
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
        if (User.IsInRole("Employee"))
        {
            ViewBag.CanteenId = _employeeRepository.GetEmployee(User.Identity!.Name!)!.Canteen.Id;
        }

        return View(_mealBoxRepository.GetAvailableMealBoxes());
    }

    [HttpPost]
    public IActionResult AvailableMealBoxes(int id, string email)
    {
        string s = _mealBoxRepository.ReserveMealBox(id, email);
        return RedirectToAction("AvailableMealBoxes");
    }

    [HttpGet]
    public IActionResult ReservedMealBoxes(string email)
    {
        int id = _studentRepository.GetStudent(email)!.Id;
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
        List<Product> list = _productRepository.GetProducts();
        List<CheckBoxItem> listCheck = new List<CheckBoxItem>();
        foreach (Product p in list)
        {
            listCheck.Add(new CheckBoxItem { Name = p.Name, Id = p.Id, IsChecked = false });
        }
        ViewBag.Products = listCheck;
        Employee e = _employeeRepository.GetEmployee(User.Identity!.Name!)!;
        ViewBag.CanteenId = e.CanteenId;
        ViewBag.City = e.Canteen.City;
        ViewBag.ServesWarmMeals = e.Canteen.ServesWarmMeals;
        MealBoxViewModel viewModel = new MealBoxViewModel()
        {
            Products = listCheck
        };
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult CreateMealBox(MealBox mealBox, MealBoxViewModel model)
    {
        List<MealBox_Product> list = new List<MealBox_Product>();
        foreach (var id in model.ProductIds)
        {
            list.Add(new MealBox_Product() { ProductId = id, MealBoxId = mealBox.Id });
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
        var productIds = new List<int>();
        var list = _productRepository.GetProducts();
        var listCheck = new List<CheckBoxItem>();
        foreach (var p in list)
        {
            listCheck.Add(new CheckBoxItem { Name = p.Name, Id = p.Id, IsChecked = false });
        }
        foreach (var p in box.MealBox_Product!)
        {
            productIds.Add(p.ProductId);
        }
        foreach (var c in listCheck)
        {
            if (productIds.Contains(c.Id))
            {
                c.IsChecked = true;
            }
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
        return View(model);
    }

    [HttpPost]
    [Authorize(Roles = "Employee")]
    public IActionResult EditMealBox(MealBox mealBox, string s, MealBoxViewModel model)
    {
        if (s.Equals("edit"))
        {
            if (mealBox.StudentId == null)
            {
                List<MealBox_Product> list = new List<MealBox_Product>();
                foreach (var id in model.ProductIds)
                {
                    list.Add(new MealBox_Product { ProductId = id, MealBoxId = mealBox.Id });
                }
                _mealBoxRepository.RemoveProductsFromMealBox(mealBox.Id);
                mealBox.MealBox_Product = list;
                _mealBoxRepository.EditMealBox(mealBox);
            }
        }
        else if (s.Equals("delete"))
        {
            if (mealBox.StudentId == null)
            {
                _mealBoxRepository.DeleteMealBox(mealBox);
            }
        }

        return RedirectToAction("AvailableMealBoxes");
    }
}