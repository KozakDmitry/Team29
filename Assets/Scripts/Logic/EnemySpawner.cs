
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
        public bool spawning = true;

        public float spawnRange;
        public float delay;

        public MonsterTypeID MonsterTypeID;


        private IGameFactory _factory;


        private void Awake()
        {
            _factory = AllServices.Container.Single<IGameFactory>();
        }

        public void Construct()
        {
            StartSpawning();
        }
        public void StartSpawning()
        { 
            StartCoroutine(Spawn());
        }


        private Vector3 GetEnemyPosition()
        {
            Camera mainCamera = Camera.main;
            float cameraHeight = 2f * mainCamera.orthographicSize;
            float cameraWidth = cameraHeight * mainCamera.aspect;

            float spawnPadding = 2f;

            float spawnXMin = mainCamera.transform.position.x - cameraWidth / 2 - spawnPadding;
            float spawnXMax = mainCamera.transform.position.x + cameraWidth / 2 + spawnPadding;
            float spawnZMin = mainCamera.transform.position.z - cameraHeight / 2 - spawnPadding;
            float spawnZMax = mainCamera.transform.position.z + cameraHeight / 2 + spawnPadding;

            float spawnX = Random.Range(spawnXMin, spawnXMax);
            float spawnY = Random.Range(spawnZMin, spawnZMax);

            Vector3 spawnPosition = new Vector3(spawnX,  0f, spawnY);

            //Vector3 spawnPosition = player.position;
            //Vector3 randomPosition = new Vector3(Random.Range(-spawnRange, spawnRange), 0, Random.Range(-spawnRange, spawnRange));

            //spawnPosition += randomPosition;

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