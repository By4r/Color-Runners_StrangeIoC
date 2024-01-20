using System;
using System.Collections.Generic;

namespace Runtime.Data.ValueObject
{
    [Serializable]
    public class LevelData
    {
        public List<PoolData> PoolData = new List<PoolData>();
    }
}