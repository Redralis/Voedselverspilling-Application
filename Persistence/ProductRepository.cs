using Domain;
using Domain.Services;

namespace Persistence;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public void CreateProduct(Product? product)
    {
        _context.Product.Add(product);
        _context.SaveChanges();
    }

    public Product? GetProduct(int id)
    {
        return _context.Product.Find(id);
    }

    public void EditProduct(Product product)
    {
        _context.Product.Update(product);
        _context.SaveChanges();
    }

    public void DeleteProduct(Product product)
    {
        _context.Product.Remove(product);
        _context.SaveChanges();
    }

    public ICollection<Product?> GetProducts()
    {
        return _context.Product.ToList();
    }
    
}