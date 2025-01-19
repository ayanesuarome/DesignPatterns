using DecoratorPattern;

namespace CleanDecoratorPattern.Decorators;

public class Milk(ICoffee coffee) : CoffeeDecorator(coffee)
{
    public override string GetDescription()
    {
        return coffee.GetDescription() + ", Milk";
    }

    public override double GetCost()
    {
        return coffee.GetCost() + 0.30; // Additional cost for milk
    }
}
