namespace HSM.Core.Base
{
    using System;

    // Used for keeping track of actions tied to
    // a particular `StateMessageMethod`
    public enum StateMessageMethod
    {
#if HSM_CONSOLE
        Enter,

        // Update message methods
        Update,

        Exit,
#elif HSM_UNTIY          
        Enter,

        // Update message methods
        Update,
        FixedUpdate,
        LateUpdate,

        Exit,
#endif
    }

    // Used for binding actions to multiple
    // `StateMessageMethod`s at once
    [Flags]
    public enum StateMessageMethodFlag
    {
#if HSM_CONSOLE
        Enter = 1 << 0,

        // Update message methods
        Update = 1 << 1,

        Exit = 1 << 2,
#elif HSM_UNITY
        Enter = 1 << 0,

        // Update message methods
        Update = 1 << 1,
        FixedUpdate = 1 << 2,
        LateUpdate = 1 << 3,

        Exit = 1 << 4,
#endif
    }
}
