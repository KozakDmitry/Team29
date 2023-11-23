
using Scripts.Infostructure.Factory;
using Scripts.Infostructure.Services;
using Scripts.StaticData;
using System.Collections;
using UnityEngine;

namespace Scripts.Logic
{
    public class EnemySpawner : MonoBehaviour
    {
        
        public GameObject enemy;
        public MoveArea area;
        public bool spawning = true;

        public float spawnRange;
        public float delay;

        public MonsterTypeID MonsterTypeID;
        private string _id;


        private IGameFactory _factory;


        private void Awake()
        {
            _factory = AllServices.Container.Single<IGameFactory>();
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



        IEnumerator Spawn()
        {
            while (spawning)
            {
                yield return new WaitForSeconds(delay);

                GameObject monster = _factory.CreateMonster(MonsterTypeID, transform);
            }
        }



    }
}