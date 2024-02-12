
using Scripts.Infostructure.AssetManagement;
using Scripts.Infostructure.Services.PersistentProgress;
using Scripts.StaticData;
using Scripts.StaticData.Windows;
using Scripts.UI.Services.Windows;
using Scripts.UI.Windows;
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


        public void CreateElement<T>(WindowsID windowsID) where T : WindowBase
        {
            
            WindowConfig config = _staticData.ForWindow(windowsID);
            T window = Object.Instantiate(config.windowPrefab, UIRoot) as T;
            window.Construct(_progressService);
            
        }


    }
}
