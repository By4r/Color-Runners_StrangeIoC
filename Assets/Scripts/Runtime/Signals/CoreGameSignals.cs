using strange.extensions.signal.impl;

namespace Runtime.Signals
{
    public class CoreGameSignals
    {
        public Signal onReset = new Signal();
        public Signal onLevelFailed = new Signal();
        public Signal onLevelSuccessful = new Signal();
    }
}