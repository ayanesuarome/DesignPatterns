﻿namespace CommandPattern
{
    public class Command
    {
        public enum Action
        {
            Deposit,
            Withdraw
        }

        public Action TheAction;
        public int Amount;
        public bool Success;
    }

    public class Account
    {
        public int Balance { get; set; }

        public void Process(Command c)
        {
            switch (c.TheAction)
            {
                case Command.Action.Deposit:
                    Balance += c.Amount;
                    c.Success = true;
                    break;
                case Command.Action.Withdraw:
                    c.Success = Balance > c.Amount;
                    if (c.Success)
                    {
                        Balance -= c.Amount;
                    }
                    break;
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}
