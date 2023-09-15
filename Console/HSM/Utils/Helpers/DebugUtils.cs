namespace HSM.Utils.Helpers
{
#if HSM_CONSOLE
    using System;
    using System.Diagnostics;
#elif HSM_UNITY
    using UnityEngine;
    using UnityEngine.Assertions;
#endif

    // Helper static class with a bunch of convenience
    // functions for testing and debugging
    public static class DebugUtils
    {
        private static bool _enableLog = true;

        public static void EnableLog()
        {
            _enableLog = true;
        }

        public static void DisableLog()
        {
            _enableLog = false;
        }

        public static void Log(string message)
        {
            if (_enableLog)
            {
#if HSM_CONSOLE
                Console.WriteLine(message);
#elif HSM_UNITY
                Debug.Log(message);
#endif
            }
        }

        public static void Log(int number)
        {
            Log(number.ToString());
        }

        public static void Assert(bool condition, string message)
        {
            InternalAssert(condition, message);
        }

        // A fatal path of code execution was taken
        public static void Fatal(string message)
        {
#if HSM_CONSOLE
            // TODO
#elif HSM_UNITY
            throw new AssertionException(message, message);
#endif
        }

        private static void InternalAssert(bool condition, string message)
        {
#if HSM_CONSOLE
            Debug.Assert(condition, message);
#elif HSM_UNITY
            UnityEngine.Assertions.Assert.IsTrue(condition, message);
#endif
        }
    }
}
