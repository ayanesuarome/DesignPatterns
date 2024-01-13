namespace CommandPattern
{
    internal class BankAccountCommand : ICommand
    {
        private BankAccount bankAccount;
        private Action action;
        private int amount;
        
        public bool Success { get; set; }

        public enum Action
        {
            Deposit,
            Withdraw
        }

        public BankAccountCommand(BankAccount bankAccount, Action action, int amount)
        {
            ArgumentNullException.ThrowIfNull(bankAccount, nameof(bankAccount));

            this.bankAccount = bankAccount;
            this.action = action;
            this.amount = amount;
        }

        public void Call()
        {
            switch (action)
            {
                case Action.Deposit:
                    bankAccount.Deposit(amount);
                    Success = true;
                    break;
                case Action.Withdraw:
                    Success = bankAccount.Withdraw(amount);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Action not allowed");
            }
        }

        public void Undo()
        {
            if (!Success)
            {
                return;
            }

            switch (action)
            {
                case Action.Deposit:
                    bankAccount.Withdraw(amount);
                    break;
                case Action.Withdraw:
                    bankAccount.Deposit(amount);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Action not allowed");
            }
        }
    }
}
