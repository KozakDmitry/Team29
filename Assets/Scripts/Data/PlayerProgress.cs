
using UnityEngine.Tilemaps;

namespace Scripts.Data
{
    public class PlayerProgress
    {

        public Stats HeroStats;
        public LootData LootData;
        public PlayerProgress()
        {

            HeroStats = new Stats();
            LootData = new LootData();

        }
    }
}