using DecoratorPattern;

namespace CleanDecoratorPattern.Decorators;

public abstract class CoffeeDecorator(ICoffee coffe) : ICoffee
{
    public virtual double GetCost()
    {
        return coffe.GetCost();
    }

    public virtual string GetDescription()
    {
        return coffe.GetDescription();
    }
}
