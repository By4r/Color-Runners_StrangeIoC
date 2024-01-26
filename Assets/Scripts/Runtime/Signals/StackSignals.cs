using strange.extensions.signal.impl;
using UnityEngine;

namespace Runtime.Signals
{
    public class StackSignals
    {
        public Signal onAddStack = new Signal();
        public Signal<GameObject> onStackCollectable = new Signal<GameObject>();
        public Signal onInteractionObstacle = new Signal();
        //public Signal onInteractionObstacleWithPlayer = new Signal();
        public Signal onInteractionCollectable = new Signal();
        public Signal<Vector2> onStackFollowPlayer = new Signal<Vector2>();
        public Signal<Vector2> onStackMover = new Signal<Vector2>();
        public Signal onUpdateType = new Signal();
        public Signal onInteractionConveyor = new Signal();
        public Signal onUpdateAnimation = new Signal();
    }
}