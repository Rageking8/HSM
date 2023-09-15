namespace HSM.Core.CustomTransitions
{
    using System;

    using HSM.Core.Transition;
    using HSM.Core.Interfaces;

    using static HSM.Utils.Helpers.DebugUtils;
    using static HSM.Utils.Helpers.DelayUtils;

    // Transition that will happen after a random amount of
    // seconds where the range will be new each time between
    // [minDuration, maxDuration]
    public class RandomTimedTransition<TStateID> :
        Transition<TStateID>, ITimedTransition<TStateID>
    {
        private bool _isTimeUp = false;
        private readonly float _minDuration;
        private readonly float _maxDuration;
        private static readonly Random _random = new();

        public RandomTimedTransition(TStateID fromStateID,
            TStateID toStateID, float minDuration, float maxDuration) :
            base(fromStateID, toStateID)
        {
            Assert(minDuration < maxDuration,
                "`minDuration` must be less than `maxDuration`");

            _minDuration = minDuration;
            _maxDuration = maxDuration;
        }

        public RandomTimedTransition(TStateID fromStateID,
            TStateID toStateID, float minDuration, float maxDuration,
            Action callback) :
            this(fromStateID, toStateID, minDuration, maxDuration)
        {
            SetCallback(callback);
        }

        public void StartTimer()
        {
            _isTimeUp = false;

            float randomRatio = _random.Next() /
                (float)(int.MaxValue - 1);
            float durationRange = _maxDuration - _minDuration;
            float randomDuration = _minDuration +
                (randomRatio * durationRange);

            // Change `isTimeUp` after `time` to transit
            _ = DelayExecute(() => _isTimeUp = true, randomDuration);
        }

        public override bool Conditions()
        {
            return _isTimeUp;
        }
    }

    // A helper class `RandomTimedTransition` with the
    // generic argument defaulted to a common type
    public class RandomTimedTransition :
        RandomTimedTransition<string>, ITimedTransition<string>
    {
        public RandomTimedTransition(string fromStateID,
            string toStateID, float minDuration, float maxDuration) :
            base(fromStateID, toStateID, minDuration, maxDuration)
        {

        }

        public RandomTimedTransition(string fromStateID,
            string toStateID, float minDuration, float maxDuration,
            Action callback) :
            base(fromStateID, toStateID, minDuration, maxDuration, callback)
        {

        }
    }
}
