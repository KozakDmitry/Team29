

using Scripts.UI.Windows;
using Scripts.UI.Windows.Menu;
using Scripts.UI.Windows.Shop;
using UnityEngine;

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
                    _UIFactory.CreateElement<Shop>(windowId);
                    break;
                case WindowsID.StartMenu:
                    _UIFactory.CreateElement<StartMenu>(windowId);
                    break;
                case WindowsID.PauseMenu:
                    _UIFactory.CreateElement<PauseMenu>(windowId);
                    break;
            }
        }
    }
}
