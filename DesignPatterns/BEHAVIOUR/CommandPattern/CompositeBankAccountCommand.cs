namespace CommandPattern
{
    internal class CompositeBankAccountCommand : List<BankAccountCommand>, ICommand
    {
        public CompositeBankAccountCommand()
        {    
        }

        public CompositeBankAccountCommand(IEnumerable<BankAccountCommand> collection)
            : base(collection)
        {
        }

        public bool Success
        {
            get
            {
                return this.All(command => command.Success);
            }
            set
            {
                foreach (ICommand cmd in this)
                {
                    cmd.Success = value;
                }
            }
        }

        public virtual void Call()
        {
            ForEach(command => command.Call());
        }

        public virtual void Undo()
        {
            foreach(ICommand command in ((IEnumerable<BankAccountCommand>) this).Reverse())
            {
                if(command.Success)
                {
                    command.Undo();
                }
            }
        }
    }
}
