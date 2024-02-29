namespace CommandPattern
{
    // Command patter encapsulates a request as an object where the object contains information about the request, action to perform, undo/redo operation, etc
    // Command patter encapsulates all the details of an operation in a separate object
    internal class Program
    {
        static void Main(string[] args)
        {
            // without CompositeCommand
            //NoCompositeCommand();

            // Composite command
            CompositeCommand();

            //BankTransferWithCompositeCommand();
        }

        static void NoCompositeCommand()
        {
            BankAccount bankAccount = new();
            List<ICommand> commands = new()
            {
                new BankAccountCommand(bankAccount, BankAccountCommand.Action.Deposit, 100),
                new BankAccountCommand(bankAccount, BankAccountCommand.Action.Withdraw, 1000)
            };

            WriteLine(bankAccount);

            foreach (ICommand command in commands)
            {
                command.Call();
            }

            WriteLine(bankAccount);

            foreach (ICommand command in Enumerable.Reverse(commands))
            {
                command.Undo();
            }

            WriteLine(bankAccount);
        }

        static void CompositeCommand()
        {
            BankAccount bankAccount = new();
            BankAccountCommand deposit = new(bankAccount, BankAccountCommand.Action.Deposit, 100);
            BankAccountCommand withdraw = new(bankAccount, BankAccountCommand.Action.Withdraw, 50);

            var composite = new CompositeBankAccountCommand(new[] { deposit, withdraw });
            composite.Call();
            WriteLine(bankAccount);
            composite.Undo();
            WriteLine(bankAccount);
        }

        static void BankTransferWithCompositeCommand()
        {
            BankAccount from = new();
            from.Deposit(100);
            BankAccount to = new();
            MoneyTransferCommand transfer = new(from, to, 1000);
            
            transfer.Call();
            WriteLine(from);
            WriteLine(to);

            transfer.Undo();
            WriteLine(from);
            WriteLine(to);
        }
    }
}
