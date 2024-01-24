using Scripts.Enemies;
using Scripts.Enemy;
using Scripts.Infostructure.AssetManagment;
using Scripts.Infostructure.Services.DifficultyDirector;
using Scripts.Infostructure.Services.PersistentProgress;
using Scripts.Logic;
using Scripts.StaticData;
using Scripts.UI.Logic;
using Scripts.Weapon;
using Scripts.Weapon.Armory;
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
        private readonly IDifficultyDirectorService _difficultyService;

        public List<ISavedProgressReader> ProgressReaders { get; } = new List<ISavedProgressReader>();
        public List<ISavedProgress> ProgressWriters { get; } = new List<ISavedProgress>();

        private GameObject PlayerGameObject { get; set; }
        public GameFactory(IAssets assets, IStaticDataService staticData, IDifficultyDirectorService directorService)
        {
            _assets = assets;
            _staticData = staticData;
            _difficultyService = directorService;
        }
        public GameObject CreateHUD()
        {
            GameObject hud = InstantiateRegistered("UI/HUD");
            hud.GetComponentInChildren<SurviveTimer>().Construct(_difficultyService);
            return hud;
        }

        public GameObject CreateSpawner()
        {
            GameObject spawner = InstantiateRegistered("Enemies/EnemySpawner/Spawner");
            spawner.GetComponent<EnemySpawner>().Construct();
            return spawner; 
        }
        public GameObject ReturnPlayer()
        {
            return PlayerGameObject;
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

        public GameObject CreateMonster(MonsterTypeID monsterTypeID, Vector3 position)
        {
            MonsterStaticData monsterData = _staticData.ForMonster(monsterTypeID);
            GameObject monster = Object.Instantiate(monsterData.Prefab, position, Quaternion.identity);
            var health = monster.GetComponent<IHealth>();
            health.Current = monsterData.Hp;
            health.Max = monsterData.Hp;
            monster.GetComponent<Attack>().Construct(PlayerGameObject.transform);
            monster.GetComponent<AgentMoveToPlayer>().Construct(PlayerGameObject.transform);
            monster.GetComponent<RotateToPlayer>().Construct(PlayerGameObject.transform);
            monster.GetComponent<NavMeshAgent>().speed = monsterData.MoveSpeed;
            return monster;
        }

        public GameObject AddWeapon(WeaponTypeID weaponTypeID)
        {
            WeaponStaticData WeaponData = _staticData.ForWeapon(weaponTypeID);
            GameObject weapon = InstantiateRegistered($"Weapon/Armory/{weaponTypeID}");
            IWeapon weaponStats = weapon.GetComponent<IWeapon>();
            weaponStats.name = WeaponData.name;
            weaponStats.damage = WeaponData.StartDamage;
            weaponStats.damagePerLevel = WeaponData.DamagePerLevel;
            weaponStats.heroTransform = PlayerGameObject.transform;
            weaponStats.attackPrefab = WeaponData.attackObject;
            return weapon;
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