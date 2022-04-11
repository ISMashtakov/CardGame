using System;

namespace UnityEngine.Events
{
    public class WaitUntilEvent : CustomYieldInstruction
    {
        bool _called = false;
        UnityEvent _observer;

        public WaitUntilEvent(UnityEvent observer)
        {
            _observer = observer;
            _observer.AddListener(Listener);
        }

        public override bool keepWaiting => !_called;

        void Listener()
        {
            _called = true;
        }

        ~WaitUntilEvent()
        {
            _observer.RemoveListener(Listener);
        }
    }
}
