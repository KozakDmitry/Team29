using Scripts.Infostructure.Services;
using Scripts.StaticData.Windows;
using Scripts.UI.Services.Windows;

namespace Scripts.StaticData
{
    public interface IStaticDataService : IService
    {
        void LoadMonsters();

        void LoadWeapons();

        void LoadWindows();
        MonsterStaticData ForMonster(MonsterTypeID typeId);
        WeaponStaticData ForWeapon(WeaponTypeID typeId);

        WindowConfig ForWindow(WindowsID windowId);
    }
}