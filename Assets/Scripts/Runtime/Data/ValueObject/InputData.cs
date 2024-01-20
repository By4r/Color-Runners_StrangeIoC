using System;
using Vector2 = UnityEngine.Vector2;

namespace Runtime.Data.ValueObject
{
    [Serializable]
    public class InputData
    {
        public float HorizontalInputSpeed;
        public float ClampSpeed;
        public Vector2 ClampPosition;
    }
}