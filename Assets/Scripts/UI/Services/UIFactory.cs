
using Scripts.Infostructure.AssetManagment;
using Scripts.Infostructure.Services.PersistentProgress;
using Scripts.StaticData;
using UnityEditor.PackageManager.UI;
using UnityEngine;

namespace Scripts.UI.Services
{
    public class UIFactory : IUIFactory
    {
        private const string UIRootPath = "UIRoot";

        private readonly IAssets _assets;
        private Transform UIRoot;



        public void CreateStartMenu()
        {

        }

        public UIFactory(IAssets assets)
        {
            _assets = assets;
        }
        public void CreateUIRoot()
        {
            GameObject root = _assets.InstantiatePrefab(UIRootPath);
            UIRoot = root.transform;
        }

        public void CreatePauseMenu()
        {
            throw new System.NotImplementedException();
        }

        public void CreateShop()
        {
            throw new System.NotImplementedException();
        }
    }
}
