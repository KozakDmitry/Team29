using Scripts.Infostructure.Services;
using Scripts.Infostructure.Services.PersistentProgress;
using Scripts.StaticData;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Infostructure.Factory
{
    public interface IGameFactory :IService
    {
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressWriters { get; }
        public void Register(ISavedProgressReader progressReader);
        public GameObject CreatePlayer(GameObject startPoint);
        public GameObject CreateSpawner();
        public GameObject CreateMonster(MonsterTypeID monsterTypeID, Vector3 position);
        void CleanUp();
    }
}