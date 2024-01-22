using System;
using System.Collections.Generic;

namespace SOLID.Principles.DependencyInversion
{
    // Low level module
    class SqlProductRepository : IProductRepository
    {
        public IList<string> GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
