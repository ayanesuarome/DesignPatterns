// See https://aka.ms/new-console-template for more information

using CleanDecoratorPattern;
using CleanDecoratorPattern.Decorators;
using DecoratorPattern;

Console.WriteLine("Simple Adapter");

// Basic coffee
ICoffee coffee = new BasicCoffee();

Console.WriteLine($"Basic coffee Description: {coffee.GetDescription()}");
Console.WriteLine($"Basic coffee Cost: $ {coffee.GetCost()}");

// Add an expresso
coffee = new EspressoShot(coffee);

Console.WriteLine($"Espresso coffee Description: {coffee.GetDescription()}");
Console.WriteLine($"Espresso coffee Cost: $ {coffee.GetCost()}");

// add whipped cream
coffee = new WhippedCream(coffee);

Console.WriteLine($"WhippedCream coffee Description: {coffee.GetDescription()}");
Console.WriteLine($"WhippedCream coffee Cost: $ {coffee.GetCost()}");