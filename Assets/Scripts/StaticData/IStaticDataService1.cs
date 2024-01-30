using Scripts.StaticData.Windows;
using Scripts.UI.Services.Windows;

namespace Scripts.StaticData
{
    public interface IStaticDataService1
    {
        MonsterStaticData ForMonster(MonsterTypeID typeId);
        WeaponStaticData ForWeapon(WeaponTypeID typeId);
        WindowConfig ForWindow(WindowsID windowId);
        void LoadMonsters();
        void LoadWeapons();
        void LoadWindows();
    }
}