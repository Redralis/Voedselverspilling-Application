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
        if (_mealBoxRepository.GetMealBoxes() == null)
        {
            return Task.FromResult<ActionResult<IEnumerable<MealBox>>>(NotFound());
        }

        return Task.FromResult<ActionResult<IEnumerable<MealBox>>>(_mealBoxRepository.GetMealBoxes());
    }
    
    // GET: api/Mealboxes/1
    [HttpGet("{id}")]
    public Task<ActionResult<MealBox>> GetMealBoxes(int id)
    {
        if (_mealBoxRepository.GetMealBoxes() == null)
        {
            return Task.FromResult<ActionResult<MealBox>>(NotFound());
        }
        var mealBox = _mealBoxRepository.GetMealBox(id);

        if (mealBox == null)
        {
            return Task.FromResult<ActionResult<MealBox>>(NotFound());
        }

        return Task.FromResult<ActionResult<MealBox>>(mealBox);
    }

    // UPDATE: api/Mealboxes/1
    [HttpPut("{id}")]
    public Task<ActionResult<IEnumerable<MealBox>>> UpdateMealBoxes(int id)
    {
        return Task.FromResult<ActionResult<IEnumerable<MealBox>>>(StatusCode(StatusCodes.Status501NotImplemented, new { message = "Functionality for editing not yet implemented." }));
    }

    // DELETE: api/Mealboxes/1
    [HttpDelete("{id}")]
    public Task<ActionResult<IEnumerable<MealBox>>> DeleteMealBoxes(int id)
    {
        return Task.FromResult<ActionResult<IEnumerable<MealBox>>>(StatusCode(StatusCodes.Status501NotImplemented, new { message = "Functionality for deleting not yet implemented." }));
    }
}