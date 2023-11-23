using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts.StaticData
{
    public class StaticDataService : IStaticDataService
    {

        private Dictionary<MonsterTypeID, MonsterStaticData> _monsters;

        public void LoadMonsters()
        {
            _monsters = Resources
                .LoadAll<MonsterStaticData>("StaticData/Monsters")
                .ToDictionary(x => x.MonsterTypeId, x => x);
        }

        public MonsterStaticData ForMonster(MonsterTypeID typeId) =>
            _monsters.TryGetValue(typeId, out MonsterStaticData staticData)
                ? staticData
                : null;
    }
}