using Scripts.Infostructure.Services;

namespace Scripts.UI.Services.Windows
{
    public interface IWindowService : IService
    {
        void Open(WindowsID windowId);
    }
}