using Scripts.Infostructure.Services;

namespace Scripts.UI.Services
{
    public interface IUIFactory :IService
    {
        void CreatePauseMenu();
        void CreateShop();
        void CreateStartMenu();
        void CreateUIRoot();
    }
}