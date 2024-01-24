using strange.extensions.signal.impl;
using UnityEngine;

namespace Runtime.Signals
{
    public class StackSignals
    {
        public Signal<GameObject> onAddStack = new Signal<GameObject>();
        public Signal<GameObject> onInteractionATM = new Signal<GameObject>();
        public Signal<GameObject> onInteractionObstacle = new Signal<GameObject>();
        public Signal<GameObject> onInteractionCollectable = new Signal<GameObject>();
        public Signal onInteractionObstacleWithPlayer = new Signal();
        public Signal<Vector2> onStackFollowPlayer = new Signal<Vector2>();
        public Signal onUpdateType = new Signal();
        public Signal onInteractionConveyor = new Signal();
        public Signal onUpdateAnimation = new Signal();
    }
}