namespace StatePattern
{
    internal enum PhoneState
    {
        OffHook,
        Connecting,
        Connected,
        OnHOld
    }

    internal enum PhoneTrigger
    {
        CallDialed,
        HungUp,
        CallConnected,
        PlaceOnHold,
        TakenOffHold,
        LeftMessage
    }

    internal static class HandmadeStateMachine
    {
        private static Dictionary<PhoneState, List<(PhoneTrigger, PhoneState)>> Rules = new()
        {
            [PhoneState.OffHook] = new List<(PhoneTrigger, PhoneState)>()
            {
                (PhoneTrigger.CallDialed, PhoneState.Connecting)
            },
            [PhoneState.Connecting] = new List<(PhoneTrigger, PhoneState)>()
            {
                (PhoneTrigger.HungUp, PhoneState.OffHook),
                (PhoneTrigger.CallConnected, PhoneState.Connected)
            },
            [PhoneState.Connected] = new List<(PhoneTrigger, PhoneState)>()
            {
                (PhoneTrigger.LeftMessage, PhoneState.OffHook),
                (PhoneTrigger.HungUp, PhoneState.OffHook),
                (PhoneTrigger.PlaceOnHold, PhoneState.OnHOld)
            },
            [PhoneState.OnHOld] = new List<(PhoneTrigger, PhoneState)>()
            {
                (PhoneTrigger.TakenOffHold, PhoneState.Connected),
                (PhoneTrigger.HungUp, PhoneState.OffHook)
            }
        };

        internal static void RunDemo()
        {
            PhoneState machineState = PhoneState.OffHook;

            while (true)
            {
                WriteLine($"The phone is currently {machineState}");
                WriteLine("Select an option:");

                for (int i = 0; i < HandmadeStateMachine.Rules[machineState].Count; i++)
                {
                    (PhoneTrigger trigger, PhoneState _) = HandmadeStateMachine.Rules[machineState][i];
                    WriteLine($"{i}. {trigger}");
                }

                int input = int.Parse(ReadLine());

                (PhoneTrigger _, PhoneState state) = HandmadeStateMachine.Rules[machineState][input];
                machineState = state;
            }
        }
    }
}