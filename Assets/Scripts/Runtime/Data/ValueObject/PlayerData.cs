using System;
using Unity.Mathematics;

namespace Runtime.Data.ValueObject
{
    [Serializable]
    public struct PlayerData
    {
        public PlayerMovementData MovementData;
        public PlayerMeshData MeshData;
        public PlayerForceData ForceData;
    }

    [Serializable]
    public struct PlayerMeshData
    {
        public float ScaleCounter;
    }

    [Serializable]
    public struct PlayerMovementData
    {
        public float ForwardSpeed;
        public float SidewaysSpeed;
    }

    [Serializable]
    public struct PlayerForceData
    {
        public float2 ForwardForceCounter;
    }
}