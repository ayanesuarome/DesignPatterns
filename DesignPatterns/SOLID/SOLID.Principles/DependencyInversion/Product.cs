using System.Collections.Generic;

namespace SOLID.Principles.DependencyInversion
{
    // High level module
    class Product
    {
        public IList<string> getProducts()
        {
            // Not to do. Depending on low level module and keeping tight coopling
            // SqlProductRepository repository = new SqlProductRepository();

            // Depending on abstraction. Loose coopling. Initialize wether using Dependency Injection or Factory Pattern.
            IProductRepository repository = ProductFactory.Create();

            return repository.GetProducts();
        }
    }
}
