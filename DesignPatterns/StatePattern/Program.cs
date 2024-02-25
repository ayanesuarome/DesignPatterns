// See https://aka.ms/new-console-template for more information
using StatePattern;

// The object's behaviour depends on its state.

//Console.WriteLine("Classic Implementation");
//Switch ls = new();
//ls.On();
//ls.Off();
//ls.Off();

//WriteLine("Handmade State Machine");
//HandmadeStateMachine.RunDemo();

//WriteLine("Switch Based State Machine");
//SwitchBasedStateMachine demo = new();
//demo.RunDemo();

//WriteLine("Switch Expressions");
//SwitchExpression.RunDemo();

WriteLine("");
WriteLine("State Machine with stateless");
StateMachineWithStateless stateMachine = new(Health.NonReproductive);
stateMachine.RunDemo();