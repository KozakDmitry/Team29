
using Scripts.Infostructure.AssetManagment;
using UnityEngine;

namespace Scripts.UI.Services
{
    public class UIFactory : IUIFactory
    {
        private const string UIRootPath = "UIRoot";

        private readonly IAssets _assets;
        private Transform UIRoot;



        public UIFactory(IAssets assets)
        {
            _assets = assets;
        }
        public void CreateUIRoot()
        {
            GameObject root = _assets.InstantiatePrefab(UIRootPath);
            UIRoot = root.transform;
        }
    }
}
