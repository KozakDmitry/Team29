
using Scripts.Infostructure.Factory;
using Scripts.Infostructure.Services;
using Scripts.StaticData;
using System.Collections;
using UnityEngine;

namespace Scripts.Logic
{
    public class EnemySpawner : MonoBehaviour
    {
        
        public GameObject enemyPrefab;
        public MoveArea area; 
        public bool spawning = true;

        public float spawnRange;
        public float delay;

        public MonsterTypeID MonsterTypeID;
        private string _id;
        private Transform player;

        private IGameFactory _factory;


        private void Awake()
        {
            _factory = AllServices.Container.Single<IGameFactory>();
        }

        public void Construct(GameObject playerObject)
        {
            player = playerObject.transform;
            StartSpawning();
        }
        public void StartSpawning()
        { 
            StartCoroutine(Spawn());
        }

        bool ValidSpawnPoint(Vector3 position)
        {
            if (position.x < area.center.x - area.size.x * 0.5f || position.x > area.center.x + area.size.x * 0.5f)
                return false;

            if (position.z < area.center.z - area.size.z * 0.5f || position.z > area.center.z + area.size.z * 0.5f)
                return false;

            return true;
        }


        private Vector3 GetEnemyPosition()
        {
            Vector3 spawnPosition = player.position;
            Vector3 randomPosition = new Vector3(Random.Range(-spawnRange, spawnRange), 0, Random.Range(-spawnRange, spawnRange));

            spawnPosition += randomPosition;

            //while (!ValidSpawnPoint(spawnPosition))
            //{
            //    randomPosition = new Vector3(Random.Range(-spawnRange, spawnRange), 0, Random.Range(-spawnRange, spawnRange));
            //    spawnPosition = player.position + randomPosition;
            //}

            return spawnPosition;
        }



        IEnumerator Spawn()
        {
            while (spawning)
            {
                yield return new WaitForSeconds(delay);

                GameObject monster = _factory.CreateMonster(MonsterTypeID, GetEnemyPosition());

            }
        }



    }
}