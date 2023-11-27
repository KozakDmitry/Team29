using Scripts.Infostructure.Services;

namespace Scripts.StaticData
{
    public interface IStaticDataService : IService
    {
        void LoadMonsters();

        void LoadWeapons();
        MonsterStaticData ForMonster(MonsterTypeID typeId);
    }
}