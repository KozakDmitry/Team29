using Scripts.Data;

namespace Scripts.Infostructure.Services.SaveLoad
{
    public interface ISaveLoadService :IService
    {
        void SaveProgress();
        PlayerProgress LoadProgress();
    }
}