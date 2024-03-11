
using Scripts.Infostructure.Factory;
using Scripts.Infostructure.Services.DifficultyDirector;
using Scripts.StaticData;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

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
        private IDifficultyDirectorService _difficultyDirectorService;


        private void Awake()
        {

        }

        public void Construct(IGameFactory factory, IDifficultyDirectorService directorService)
        {
            _factory = factory;
            _difficultyDirectorService = directorService;
            _difficultyDirectorService.DifficultyChanged += DifficultyChanged;
            StartSpawning();

        }

        private void DifficultyChanged(int newDifficulty)
        {
            CheckNewMonsters(newDifficulty);
        }

        private void CheckNewMonsters(int newDiff)
        {
            //if(newDiff>=)
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

            //float spawnPadding = 2f;

            //float spawnXMin = mainCamera.transform.position.x - cameraWidth / 2 - spawnPadding;
            //float spawnXMax = mainCamera.transform.position.x + cameraWidth / 2 + spawnPadding;
            //float spawnZMin = mainCamera.transform.position.z - cameraHeight / 2 - spawnPadding;
            //float spawnZMax = mainCamera.transform.position.z + cameraHeight / 2 + spawnPadding;

            //float spawnX = Random.Range(spawnXMin, spawnXMax);
            //float spawnY = Random.Range(spawnZMin, spawnZMax);

            Vector3 spawnPosition = GetRandomPointOnNavMesh(transform.position, cameraWidth);
            Debug.Log("Random point: " + spawnPosition);
            //Vector3 spawnPosition = new Vector3(spawnX,  0f, spawnY);



            return spawnPosition;
        }

        Vector3 GetRandomPointOnNavMesh(Vector3 center, float radius)
        {
            NavMeshHit hit;
            Vector3 randomPosition = center + Random.insideUnitSphere * radius;
            NavMesh.SamplePosition(randomPosition, out hit, radius, NavMesh.AllAreas);

            return hit.position;
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