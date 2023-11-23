﻿using Scripts.Infostructure.AssetManagment;
using Scripts.Infostructure.Services.PersistentProgress;
using Scripts.StaticData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Scripts.Infostructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssets _assets;
        private readonly IStaticDataService _staticData;

        public List<ISavedProgressReader> ProgressReaders { get; } = new List<ISavedProgressReader>();
        public List<ISavedProgress> ProgressWriters { get; } = new List<ISavedProgress>();

        private GameObject PlayerGameObject { get; set; }
        public GameFactory(IAssets assets, IStaticDataService staticData)
        {
            _assets = assets;
            _staticData = staticData;
        }

        public GameObject CreatePlayer(GameObject startPoint)
        {
            PlayerGameObject = InstantiateRegistered("Player/Player", startPoint.transform.position);
            return PlayerGameObject;
        }
        private GameObject InstantiateRegistered(string path, Vector3 position)
        {
            GameObject gameObject = _assets.InstantiatePrefab(path, position);
            RegisterProgressWatchers(gameObject);
            return gameObject;
        }
        private GameObject InstantiateRegistered(string path)
        {
            GameObject gameObject = _assets.InstantiatePrefab(path);
            RegisterProgressWatchers(gameObject);
            return gameObject;
        }

        private void RegisterProgressWatchers(GameObject gameObject)
        {
            foreach (ISavedProgressReader progressReader in gameObject.GetComponentsInChildren<ISavedProgressReader>())
            {
                Register(progressReader);
            }
        }

        public GameObject CreateMonster(MonsterTypeID monsterTypeID, Transform parent)
        {
            MonsterStaticData monsterData = _staticData.ForMonster(monsterTypeID);
            GameObject monster = Object.Instantiate(monsterData.Prefab, parent.position, Quaternion.identity);
            //var health = monster.GetComponent<IHealth>();
            //health.Current = monsterData.Hp;
            //health.Max = monsterData.Hp;
            monster.GetComponent<NavMeshAgent>().speed = monsterData.MoveSpeed;
            return monster;
        }



        public void CleanUp()
        {
            ProgressReaders.Clear();
            ProgressWriters.Clear();
        }


        public void Register(ISavedProgressReader progressReader)
        {
            if (progressReader is ISavedProgress progressWriter)
            {
                ProgressWriters.Add(progressWriter);

            }
            ProgressReaders.Add(progressReader);

        }

    }
}