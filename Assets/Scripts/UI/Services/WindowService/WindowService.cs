

namespace Scripts.UI.Services.Windows
{
    public class WindowService : IWindowService
    {
        private IUIFactory _UIFactory;

        public WindowService(IUIFactory UIFactory)
        {
            _UIFactory = UIFactory;
        }
        public void Open(WindowsID windowId)
        {
            switch (windowId)
            {
                case WindowsID.Unknown:
                    break;
                case WindowsID.Shop:
                    _UIFactory.CreateShop();
                    break;
                case WindowsID.StartMenu:
                    _UIFactory.CreateStartMenu();
                    break;
                case WindowsID.PauseMenu:
                    _UIFactory.CreatePauseMenu();
                    break;
            }
        }
    }
}
