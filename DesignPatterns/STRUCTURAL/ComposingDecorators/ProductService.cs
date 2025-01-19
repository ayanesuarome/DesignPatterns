namespace ComposingDecorators;

public class ProductService : IProductService
{
    public async Task<Product> GetProduct(int id)
    {
        Console.WriteLine("Retrieving product from database...");

        return new Product
        {
            Id = id,
            Name = "Sample Product"
        };
    }
}