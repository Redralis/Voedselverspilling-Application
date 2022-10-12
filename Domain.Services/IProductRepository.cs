namespace Domain.Services;

public interface IProductRepository
{
    public Product CreateProduct(Product product);
    
    public Product GetProduct(int id);

    public Product EditProduct(Product product);

    public Product DeleteProduct(int id);

}