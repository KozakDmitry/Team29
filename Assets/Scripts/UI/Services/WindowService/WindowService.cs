

using Unity.VisualScripting;

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
            //windowId switch
            //{
            //    WindowsID.Unknown => ,
            //    WindowsID.StartMenu => _UIFactory.CreateStartMenu(),
            //    WindowsID.Shop => _UIFactory.CreateShop(),
            //    WindowsID.PauseMenu => _UIFactory.CreatePauseMenu(),
            //};
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
