#if HSM_CONSOLE_MAIN
namespace HSM
{
    using System;

    using HSM.Core.Misc;
    using HSM.Core.StateMachine;
    using HSM.Core.CustomStates;
    using HSM.Core.CustomTransitions;

    using static HSM.Utils.Helpers.RepeatUtils;

    public static class Program
    {
        private static StateMachine? _stateMachine;
        private static uint _id = 0;

        private static void Update()
        {
            _stateMachine?.Update();
        }

        private static void Start()
        {
            _stateMachine = new StateMachine("Main",
                new IdleState("Idle"),

                new GenericState("Patrol",
                    new ActionEntry("Update", () =>
                    {
                        Console.WriteLine("Patrolling " + _id);
                        _id++;
                    })
                ),

                new FixedTimedTransition("Idle", "Patrol", 2f),
                new FixedTimedTransition("Patrol", "Idle", 2f)
            );

            _stateMachine.SetStartState("Idle");
            _stateMachine.Enter();
        }

        private static void Main()
        {
            Start();

            // Update at a frequency of 0.1s
            _ = InvokeLoop(() => Update(), 0.1f);

            Console.ReadLine();
        }
    }
}
#endif
