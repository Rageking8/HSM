namespace HSM.Utils
{
    using System;
    using System.Threading.Tasks;

    public static class Delay
    {
        public static async Task Execute(Action action,
            float delay)
        {
            await Task.Delay((int)(delay * 1000f));
            action();
        }
    }
}
