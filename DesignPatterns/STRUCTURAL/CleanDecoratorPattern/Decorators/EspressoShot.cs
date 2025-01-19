using DecoratorPattern;

namespace CleanDecoratorPattern.Decorators;

public class EspressoShot(ICoffee coffee) : CoffeeDecorator(coffee)
{
    public override string GetDescription()
    {
        return coffee.GetDescription() + ", Espresso Shot";
    }

    public override double GetCost()
    {
        return coffee.GetCost() + 0.50; // Additional cost for espresso
    }
}
