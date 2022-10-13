namespace Domain.Services;

public interface IProductRepository
{
    public void CreateProduct(Product? product);
    
    public Product? GetProduct(int id);

    public void EditProduct(Product product);

    public void DeleteProduct(Product product);

    public ICollection<Product?> GetProducts();

}