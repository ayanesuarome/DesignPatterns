using Microsoft.Extensions.Caching.Memory;

namespace ComposingDecorators.Decorators;

public class CachingProductServiceDecorator(
    IProductService inner,
    IMemoryCache cache) : IProductService
{
    public async Task<Product> GetProduct(int id)
    {
        if (cache.TryGetValue(id, out Product product))
        {
            Console.WriteLine("Returning product from cache...");

            return product;
        }

        product = await inner.GetProduct(id);

        cache.Set(id, product, TimeSpan.FromMinutes(5));

        return product;
    }
}