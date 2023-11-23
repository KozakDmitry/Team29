using Scripts.Infostructure.Services;

namespace Scripts.StaticData
{
    public interface IStaticDataService : IService
    {
        void LoadMonsters();
        MonsterStaticData ForMonster(MonsterTypeID typeId);
    }
}