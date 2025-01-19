namespace ComposingDecorators;

public interface IProductService
{
    Task<Product> GetProduct(int id);
}
