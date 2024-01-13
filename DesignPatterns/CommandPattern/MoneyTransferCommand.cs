using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    internal class MoneyTransferCommand : CompositeBankAccountCommand
    {
        public MoneyTransferCommand(BankAccount from, BankAccount to, int amount)
        {
            AddRange(
                new[]
                {
                    new BankAccountCommand(from, BankAccountCommand.Action.Withdraw, amount),
                    new BankAccountCommand(to, BankAccountCommand.Action.Deposit, amount),
                });
        }

        public override void Call()
        {
            BankAccountCommand? last = null;
            
            foreach(BankAccountCommand command in this)
            {
                if(last == null || last.Success)
                {
                    command.Call();
                    last = command;
                }
                else
                {
                    command.Undo();
                    break;
                }
            }
        }
    }
}
