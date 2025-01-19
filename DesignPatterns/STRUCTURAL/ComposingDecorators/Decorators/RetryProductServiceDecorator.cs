using Polly;

namespace ComposingDecorators.Decorators;

public class RetryProductServiceDecorator(
    IProductService inner,
    IAsyncPolicy retryPolicy) : IProductService
{
    public async Task<Product> GetProduct(int id)
    {
        return await retryPolicy.ExecuteAsync(() => inner.GetProduct(id));
    }
}