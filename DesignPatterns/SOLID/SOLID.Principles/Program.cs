using SOLID.Principles.LiskovSubstitution;
using System.Collections;

namespace SOLID.Principles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Labda expression with delegates
            Func<int, int> square = number => number * number;
            Action<int> action = number => Console.WriteLine(number);
            Console.WriteLine(square(5));
            action(5);

            // Pattern: Break up the hierarchy
            Animal bird = new Bird();
            Animal ostrich = new Ostrich();

            var listAnimals = new ArrayList { bird, ostrich };

            foreach (Animal animal in listAnimals)
            {
                animal.ExecuteAction();
            }

            // Pattern: Tell, don't ask.
            Product product = new();
            Product onlineProduct = new OnlineProduct();

            var listProducts = new ArrayList { product, onlineProduct };

            foreach (Product prod in listProducts)
            {
                //if (prod is OnlineProduct onlineProduct)
                //{
                //    onlineProduct.ApplyExtraDiscount();
                //}

                Console.WriteLine(prod.GetDiscount());
            }
        }
    }
}
