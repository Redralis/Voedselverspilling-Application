using Domain;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace VoedselVerspillingApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MealBoxesController : ControllerBase
{
    private readonly IMealBoxRepository _mealBoxRepository;

    public MealBoxesController(IMealBoxRepository mealBoxRepository)
    {
        _mealBoxRepository = mealBoxRepository;
    }
    
    // CREATE: api/Mealboxes
    [HttpPost]
    public Task<ActionResult<IEnumerable<MealBox>>> CreateMealBox()
    {
        return Task.FromResult<ActionResult<IEnumerable<MealBox>>>(StatusCode(StatusCodes.Status501NotImplemented, new { message = "Functionality for creating not yet implemented." }));
    }
    
    // GET: api/Mealboxes
    [HttpGet]
    public Task<ActionResult<IEnumerable<MealBox>>> GetMealBoxes()
    {
        return Task.FromResult<ActionResult<IEnumerable<MealBox>>>(_mealBoxRepository.GetMealBoxes());
    }
    
    // GET: api/Mealboxes/1
    [HttpGet("{id}")]
    public Task<ActionResult<MealBox>> GetMealBoxes(int id)
    {
        var mealBox = _mealBoxRepository.GetMealBox(id);
        return mealBox == null ? Task.FromResult<ActionResult<MealBox>>(NotFound()) : Task.FromResult<ActionResult<MealBox>>(mealBox);
    }

    // UPDATE: api/Mealboxes/1 (only reservation on meal box can be edited currently using email)
    [HttpPut("{id}")]
    public JsonResult UpdateMealBoxes(int id, string email)
    {
        _mealBoxRepository.ReserveMealBox(id, email);
        return new JsonResult(Ok("Meal box successfully reserved by " + email + ". No further updating functionality" +
                                 " has been added yet."));
    }

    // DELETE: api/Mealboxes/1
    [HttpDelete("{id}")]
    public Task<ActionResult<IEnumerable<MealBox>>> DeleteMealBoxes(int id)
    {
        return Task.FromResult<ActionResult<IEnumerable<MealBox>>>(StatusCode(StatusCodes.Status501NotImplemented, new { message = "Functionality for deleting not yet implemented." }));
    }
}