using DecoratorPattern;

namespace CleanDecoratorPattern;

internal class BasicCoffee : ICoffee
{
    public string GetDescription()
    {
        return "Basic Coffee";
    }

    public double GetCost()
    {
        return 2.00; // Base price for a basic coffee
    }
}
