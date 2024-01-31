
using Scripts.Infostructure.AssetManagment;
using Scripts.Infostructure.Services.PersistentProgress;
using Scripts.StaticData;
using Scripts.StaticData.Windows;
using Scripts.UI.Logic;
using Scripts.UI.Services.Windows;
using Scripts.UI.Windows.Menu;
using Scripts.UI.Windows.Shop;
using UnityEditor.PackageManager.UI;
using UnityEngine;

namespace Scripts.UI.Services
{
    public class UIFactory : IUIFactory
    {
        private const string UIRootPath = "UI/UIRoot";

        private readonly IAssets _assets;
        private readonly IStaticDataService _staticData;
        private readonly IPersistentProgressService _progressService;
        //private readonly IWindowService _windowService;
        private Transform UIRoot;



      
        public UIFactory(IAssets assets, IStaticDataService staticData, IPersistentProgressService progressService)
        {
            _assets = assets;
            _staticData = staticData;
            _progressService = progressService;
        }
        public void CreateUIRoot()
        {
            GameObject root = _assets.InstantiatePrefab(UIRootPath);
            UIRoot = root.transform;
        }

        public void CreateStartMenu()
        {
            WindowConfig config = _staticData.ForWindow(WindowsID.StartMenu);
            StartMenu window = Object.Instantiate(config.windowPrefab, UIRoot) as StartMenu;
            window.Construct(_progressService);
        }

        public void CreatePauseMenu()
        {
            WindowConfig config = _staticData.ForWindow(WindowsID.PauseMenu);
            PauseMenu window = Object.Instantiate(config.windowPrefab, UIRoot) as PauseMenu;
            window.Construct(_progressService);      
        }

        public void CreateShop()
        {
            WindowConfig config = _staticData.ForWindow(WindowsID.PauseMenu);
            Shop window = Object.Instantiate(config.windowPrefab, UIRoot) as Shop;
            window.Construct(_progressService);
        }
    }
}
