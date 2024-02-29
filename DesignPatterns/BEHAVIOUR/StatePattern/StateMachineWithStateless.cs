using Stateless;

namespace StatePattern
{
    enum Health
    {
        NonReproductive,
        Pregnant,
        Reproductive
    }

    enum HealthTrigger
    {
        GiveBirth,
        ReachPuberty,
        HaveAbortion,
        HaveUnprotectedSex,
        Historectomy
    }

    // In real scenarios you can use the framework features instead of writting your own states
    // Install nuget package: stateless-4.0 (hierarchical state machine)
    internal class StateMachineWithStateless(Health health)
    {
        public bool ParentsNotWatching()
        {
            return true;
        }

        public StateMachine<Health, HealthTrigger> StateMachine = new(health);

        internal void ConfiguredMachineState()
        {
            StateMachine.Configure(Health.NonReproductive)
                .Permit(HealthTrigger.ReachPuberty, Health.Reproductive);

            StateMachine = new(Health.NonReproductive);

            StateMachine.Configure(Health.NonReproductive)
                .Permit(HealthTrigger.ReachPuberty, Health.Reproductive);

            StateMachine.Configure(Health.Reproductive)
                .Permit(HealthTrigger.Historectomy, Health.NonReproductive)
                .PermitIf(HealthTrigger.HaveUnprotectedSex, Health.Pregnant,
                () => ParentsNotWatching());

            StateMachine.Configure(Health.Pregnant)
                .Permit(HealthTrigger.GiveBirth, Health.Reproductive)
                .Permit(HealthTrigger.HaveAbortion, Health.Reproductive);
        }

        internal void RunDemo()
        {
            WriteLine($"Current state {StateMachine.State}");
            ConfiguredMachineState();

            WriteLine($"Transition to {HealthTrigger.ReachPuberty.ToString()}");
            StateMachine.Fire(HealthTrigger.ReachPuberty);
            WriteLine($"Current state {StateMachine.State}");

            WriteLine($"Transition to {HealthTrigger.HaveUnprotectedSex.ToString()}");
            StateMachine.Fire(HealthTrigger.HaveUnprotectedSex);
            WriteLine($"Current state {StateMachine.State}");

            WriteLine($"Transition to {HealthTrigger.GiveBirth.ToString()}");
            StateMachine.Fire(HealthTrigger.GiveBirth);
            WriteLine($"Current state {StateMachine.State}");

            WriteLine($"Can transition from {StateMachine.State} to {HealthTrigger.HaveAbortion}:");
            WriteLine(StateMachine.CanFire(HealthTrigger.HaveAbortion));
        }
    }
}
