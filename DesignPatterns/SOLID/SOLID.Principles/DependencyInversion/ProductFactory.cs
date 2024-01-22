namespace SOLID.Principles.DependencyInversion
{
    static class ProductFactory
    {
        public static IProductRepository Create()
        {
            return new SqlProductRepository();
        }
    }
}
