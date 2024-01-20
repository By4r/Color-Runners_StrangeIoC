using strange.extensions.signal.impl;

namespace Runtime.Signals
{
    public class LevelSignals
    {
        public Signal onInitializeLevel = new Signal();
        public Signal onDestroyLevel = new Signal();
        public Signal onNextLevel = new Signal();
        public Signal onRestartLevel = new Signal();
    }
}