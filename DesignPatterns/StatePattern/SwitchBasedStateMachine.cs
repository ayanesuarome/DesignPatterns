using System.Text;

namespace StatePattern
{
    // If you have a very simple State Machine having a switch is a more understandable approach.
    internal enum StateEnum
    {
        Locked,
        Failed,
        Unlocked
    }

    internal class SwitchBasedStateMachine(StateEnum State = StateEnum.Locked)
    {
        private string Code => "1234";
        public StateEnum State = State;

        public void RunDemo()
        {
            StringBuilder entry = new();

            while(true)
            {
                switch(State)
                {
                    case StateEnum.Locked:
                        entry.Append(ReadKey().KeyChar);
                        if(entry.ToString() == Code)
                        {
                            State = StateEnum.Unlocked;
                            break;
                        }

                        if (!Code.StartsWith(entry.ToString(), StringComparison.Ordinal))
                        {
                            //State = StateEnum.Failed;
                            goto case StateEnum.Failed;
                        }

                        break;
                    case StateEnum.Failed:
                        Console.CursorLeft = 0;
                        WriteLine("FAILED");
                        entry.Clear();
                        State = StateEnum.Locked;
                        break;
                    case StateEnum.Unlocked:
                        Console.CursorLeft = 0;
                        WriteLine("UNLOCKED");
                        return;
                }
            }
        }
    }
}
