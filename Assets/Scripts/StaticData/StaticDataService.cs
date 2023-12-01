using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts.StaticData
{
    public class StaticDataService : IStaticDataService
    {

        private Dictionary<MonsterTypeID, MonsterStaticData> _monsters;

        private Dictionary<WeaponTypeID, WeaponStaticData> _weapons;

        public void LoadMonsters()
        {
            _monsters = Resources
                .LoadAll<MonsterStaticData>("StaticData/Monsters")
                .ToDictionary(x => x.MonsterTypeId, x => x);
        }
        public void LoadWeapons()
        {
            _weapons = Resources
                .LoadAll<WeaponStaticData>("StaticData/Weapons")
                .ToDictionary(x => x.WeaponTypeID, x => x);
        }

        public WeaponStaticData ForWeapon(WeaponTypeID typeId) =>
            _weapons.TryGetValue(typeId, out WeaponStaticData staticData)
                ? staticData
                : null;

        public MonsterStaticData ForMonster(MonsterTypeID typeId) =>
            _monsters.TryGetValue(typeId, out MonsterStaticData staticData)
                ? staticData
                : null;

    }
}