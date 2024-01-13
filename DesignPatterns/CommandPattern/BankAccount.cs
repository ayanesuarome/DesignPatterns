namespace CommandPattern
{
    internal class BankAccount
    {
        private int balance;
        private int OverDraftLimit => -500;

        public void Deposit(int amount)
        {
            balance += amount;
            WriteLine($"Deposited ${amount}, balance is now {balance}");
        }
        
        public bool Withdraw(int amount)
        {
            if(balance - amount < OverDraftLimit)
            {
                return false;
            }

            balance -= amount;
            WriteLine($"Withdrew ${amount}, balance is now {balance}");
            return true;
        }

        public override string ToString()
        {
            return $"{nameof(balance)}: {balance}";
        }
    }
}
