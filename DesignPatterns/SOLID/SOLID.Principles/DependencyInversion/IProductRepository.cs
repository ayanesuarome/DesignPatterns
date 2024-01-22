using System.Collections.Generic;

namespace SOLID.Principles.DependencyInversion
{
    interface IProductRepository
    {
        IList<string> GetProducts();
    }
}
