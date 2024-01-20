using System;
using Runtime.Data.ValueObject;
using strange.extensions.signal.impl;
using UnityEngine;

namespace Runtime.Signals
{
    public class PlayerSignals
    {
        public Signal<Transform, PlayerForceData> onForceCommand = new Signal<Transform, PlayerForceData>();
        public Signal<byte> onStageAreaSuccessful = new Signal<byte>();
    }
}