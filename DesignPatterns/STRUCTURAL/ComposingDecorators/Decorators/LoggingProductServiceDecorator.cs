namespace ComposingDecorators.Decorators;

public class LoggingProductServiceDecorator(
    IProductService inner,
    ILogger<LoggingProductServiceDecorator> logger) : IProductService
{
    public async Task<Product> GetProduct(int id)
    {
        logger.LogInformation("Getting product with ID {Id}", id);

        var product = await inner.GetProduct(id);

        logger.LogInformation("Retrieved product: {ProductName}", product.Name);

        return product;
    }
}