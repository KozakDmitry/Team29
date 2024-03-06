
using UnityEngine.Tilemaps;

namespace Scripts.Data
{
    public class PlayerProgress
    {
        public WorldData WorldData;
        public Stats HeroStats;
        public LootData LootData;
        public PlayerProgress(string initialLevel)
        {

            HeroStats = new Stats();
            LootData = new LootData();
            WorldData = new WorldData(initialLevel);
        }
    }
}