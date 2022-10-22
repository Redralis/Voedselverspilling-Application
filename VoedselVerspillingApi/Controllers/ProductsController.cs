using Domain;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace VoedselVerspillingApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    // CREATE: api/Products
    [HttpPost]
    public Task<ActionResult<IEnumerable<Product>>> CreateProduct()
    {
        return Task.FromResult<ActionResult<IEnumerable<Product>>>(StatusCode(StatusCodes.Status501NotImplemented, new { message = "Functionality for creating not yet implemented." }));
    }
    
    // GET: api/Products
    [HttpGet]
    public Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        if (_productRepository.GetProducts() == null)
        {
            return Task.FromResult<ActionResult<IEnumerable<Product>>>(NotFound());
        }

        return Task.FromResult<ActionResult<IEnumerable<Product>>>(_productRepository.GetProducts());
    }
    
    // GET: api/Products/1
    [HttpGet("{id}")]
    public Task<ActionResult<Product>> GetProducts(int id)
    {
        if (_productRepository.GetProducts() == null)
        {
            return Task.FromResult<ActionResult<Product>>(NotFound());
        }
        var product = _productRepository.GetProduct(id);

        if (product == null)
        {
            return Task.FromResult<ActionResult<Product>>(NotFound());
        }

        return Task.FromResult<ActionResult<Product>>(product);
    }

    // UPDATE: api/Products/1
    [HttpPut("{id}")]
    public Task<ActionResult<IEnumerable<Product>>> UpdateProducts(int id)
    {
        return Task.FromResult<ActionResult<IEnumerable<Product>>>(StatusCode(StatusCodes.Status501NotImplemented, new { message = "Functionality for editing not yet implemented." }));
    }

    // DELETE: api/Products/1
    [HttpDelete("{id}")]
    public Task<ActionResult<IEnumerable<Product>>> DeleteProducts(int id)
    {
        return Task.FromResult<ActionResult<IEnumerable<Product>>>(StatusCode(StatusCodes.Status501NotImplemented, new { message = "Functionality for deleting not yet implemented." }));
    }
}