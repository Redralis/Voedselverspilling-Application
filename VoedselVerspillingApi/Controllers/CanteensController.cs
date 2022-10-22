using Domain;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace VoedselVerspillingApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CanteenController : ControllerBase
{
    private readonly ICanteenRepository _canteenRepository;

    public CanteenController(ICanteenRepository canteenRepository)
    {
        _canteenRepository = canteenRepository;
    }
    
    // CREATE: api/Canteens
    [HttpPost]
    public Task<ActionResult<IEnumerable<Canteen>>> CreateCanteen()
    {
        return Task.FromResult<ActionResult<IEnumerable<Canteen>>>(StatusCode(StatusCodes.Status501NotImplemented, new { message = "Functionality for creating not yet implemented." }));
    }
    
    // GET: api/Canteens
    [HttpGet]
    public Task<ActionResult<IEnumerable<Canteen>>> GetCanteens()
    {
        return Task.FromResult<ActionResult<IEnumerable<Canteen>>>(_canteenRepository.GetCanteens());
    }
    
    // GET: api/Canteens/1
    [HttpGet("{id}")]
    public Task<ActionResult<Canteen>> GetCanteens(int id)
    {
        var canteen = _canteenRepository.GetCanteen(id);

        return canteen == null ? Task.FromResult<ActionResult<Canteen>>(NotFound()) : Task.FromResult<ActionResult<Canteen>>(canteen);
    }

    // UPDATE: api/Canteens/1
    [HttpPut("{id}")]
    public Task<ActionResult<IEnumerable<Canteen>>> UpdateCanteens(int id)
    {
        return Task.FromResult<ActionResult<IEnumerable<Canteen>>>(StatusCode(StatusCodes.Status501NotImplemented, new { message = "Functionality for editing not yet implemented." }));
    }

    // DELETE: api/Canteens/1
    [HttpDelete("{id}")]
    public Task<ActionResult<IEnumerable<Canteen>>> DeleteCanteens(int id)
    {
        return Task.FromResult<ActionResult<IEnumerable<Canteen>>>(StatusCode(StatusCodes.Status501NotImplemented, new { message = "Functionality for deleting not yet implemented." }));
    }
}