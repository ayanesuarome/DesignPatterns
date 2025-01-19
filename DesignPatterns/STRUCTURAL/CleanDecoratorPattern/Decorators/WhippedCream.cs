using CleanDecoratorPattern.Decorators;
using DecoratorPattern;

public class WhippedCream(ICoffee coffee) : CoffeeDecorator(coffee)
{
    public override string GetDescription()
    {
        return coffee.GetDescription() + ", Whipped Cream";
    }

    public override double GetCost()
    {
        return coffee.GetCost() + 0.70; // Additional cost for whipped cream
    }
}