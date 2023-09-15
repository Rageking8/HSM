#if HSM_CONSOLE
namespace HSM.Utils.Helpers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    // Only for use in console versions
    public static class RepeatUtils
    {
        public static async Task InvokeLoop(Action action, float duration)
        {
            PeriodicTimer timer =
                new(TimeSpan.FromSeconds(duration));

            while (await timer.WaitForNextTickAsync())
            {
                action();
            }
        }
    }
}
#endif
