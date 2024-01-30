using Scripts.StaticData.Windows;
using Scripts.UI.Services.Windows;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.PackageManager.UI;
using UnityEngine;

namespace Scripts.StaticData
{
    public class StaticDataService : IStaticDataService
    {

        private Dictionary<MonsterTypeID, MonsterStaticData> _monsters;

        private Dictionary<WeaponTypeID, WeaponStaticData> _weapons;
        private Dictionary<WindowsID, WindowConfig> _windowConfigs;

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

        public void LoadWindows()
        {
            _windowConfigs = Resources
               .Load<WindowStaticData>("StaticData/UI/WindowsData")
               .Configs
               .ToDictionary(x => x.windowsID, x => x);
        }

        public WeaponStaticData ForWeapon(WeaponTypeID typeId) =>
            _weapons.TryGetValue(typeId, out WeaponStaticData staticData)
                ? staticData
                : null;

        public MonsterStaticData ForMonster(MonsterTypeID typeId) =>
            _monsters.TryGetValue(typeId, out MonsterStaticData staticData)
                ? staticData
                : null;
        public WindowConfig ForWindow(WindowsID windowId) =>
          _windowConfigs.TryGetValue(windowId, out WindowConfig staticData)
           ? staticData
           : null;
    }
}