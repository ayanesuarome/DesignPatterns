namespace CommandPattern
{
    internal class BankAccount
    {
        private int Balance { get; set; }
        private int OverDraftLimit => -500;

        public void Deposit(int amount)
        {
            Balance += amount;
            WriteLine($"Deposited ${amount}, balance is now {Balance}");
        }
        
        public bool Withdraw(int amount)
        {
            if(Balance - amount < OverDraftLimit)
            {
                return false;
            }

            Balance -= amount;
            WriteLine($"Withdrew ${amount}, balance is now {Balance}");
            return true;
        }

        public override string ToString()
        {
            return $"{nameof(Balance)}: {Balance}";
        }
    }
}
