
using Scripts.Data;
using Scripts.Enemy;
using Scripts.Infostructure.Factory;
using UnityEngine;

namespace Scripts.Enemies
{
    public class LootSpawner :MonoBehaviour
    {
        public EnemyDeath enemyDeath;
        private IGameFactory _gameFactory;

        private void Awake()
        {
            enemyDeath.Happened += SpawnLoot;
        }

        public void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public void SpawnLoot() 
        {
            LootDrop drop = _gameFactory.CreateLoot();
            drop.transform.position = transform.position;

            drop.Initialize(new Loot());
        }
    }
}
