namespace StatePattern
{
    // Classic implementation for academic purposes.
    // Not recommended this sort of implementation.
    internal class Switch
    {
        public State State = new OffState();

        public void On()
        {
            State.On(this);
        }

        public void Off()
        {
            State.Off(this);
        }
    }

    internal abstract class State
    {
        public virtual void On(Switch sw)
        {
            WriteLine("Light is already on");
        }
        public virtual void Off(Switch sw)
        {
            WriteLine("Light is already off");
        }
    }

    internal class OnState: State
    {
        public override void Off(Switch sw)
        {
            WriteLine("Turning light off...");
            sw.State = new OffState();
        }
    }

    internal class OffState : State
    {
        public override void On(Switch sw)
        {
            WriteLine("Turning light on...");
            sw.State = new OnState();
        }
    }
}
