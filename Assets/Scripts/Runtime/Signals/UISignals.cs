using strange.extensions.signal.impl;
using UnityEngine;

namespace Runtime.Signals
{
    public class UISignals
    {
        public Signal<byte> onSetStageColor = new Signal<byte>();
        public Signal<byte> onSetNewLevelValue = new Signal<byte>();
        public Signal onPlay = new Signal();
    }
}