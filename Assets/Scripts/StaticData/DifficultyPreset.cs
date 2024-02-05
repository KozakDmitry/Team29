using System;
using UnityEngine;

namespace Scripts.StaticData
{
    [CreateAssetMenu(fileName = "DifficultyPreset", menuName = "StaticData/DifficultyData")]
    public class DifficultyPreset : ScriptableObject
    {
        [Range (0f,1000f)]
        public int DifficultyUpdateTimer;

        [Range (0f,100f)]
        public int StartDifficulty;

        [Range (0.5f,2.5f)]
        public float HpMultiplier;
        [Range (0.5f, 2.0f)]
        public float SpeedMultiplier;
    }
}
