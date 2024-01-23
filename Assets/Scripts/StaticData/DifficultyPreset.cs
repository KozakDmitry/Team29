using System;
using UnityEngine;

namespace Scripts.StaticData
{
    [CreateAssetMenu(fileName = "DifficultyPreset", menuName = "StaticData/DifficultyData")]
    public class DifficultyPreset : ScriptableObject
    {
        public int DifficultyUpdateTimer;
        public int Difficulty;
        public float HpMultiplier;
        public float SpeedMultiplier;
    }
}
