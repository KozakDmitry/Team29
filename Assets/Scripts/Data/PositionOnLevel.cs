using System;
using UnityEngine;

namespace Scripts.Data
{
    [Serializable]
    public class PositionOnLevel
    {
        public string Level;
        public Vector3 Position;

        public PositionOnLevel(string level, Vector3 position)
        {
            Level = level;
            Position = position;
        }

        public PositionOnLevel(string initialLevel)
        {
            Level = initialLevel;
        }
    }
}