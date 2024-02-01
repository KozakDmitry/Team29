using Scripts.Infostructure.Services;
using Scripts.UI.Services.Windows;
using Scripts.UI.Windows;

namespace Scripts.UI.Services
{
    public interface IUIFactory :IService
    {
        void CreateElement<T>(WindowsID windowsID) where T : WindowBase;
        void CreateUIRoot();
    }
}