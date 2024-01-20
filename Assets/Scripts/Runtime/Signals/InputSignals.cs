using Runtime.Key;
using strange.extensions.signal.impl;

namespace Runtime.Signals
{
    public class InputSignals
    {
        public Signal onInputTaken = new Signal();
        public Signal onInputReleased = new Signal();
        public Signal<HorizontalInputParams> onInputDragged = new Signal<HorizontalInputParams>();
        public Signal onFirstTimeTouchTaken = new Signal();
        public Signal onEnableInput = new Signal();
        public Signal onDisableInput = new Signal();
    }
}