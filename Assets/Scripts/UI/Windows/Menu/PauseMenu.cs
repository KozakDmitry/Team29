using UnityEngine;

namespace Scripts.UI.Windows.Menu
{
    public class PauseMenu : WindowBase
    {
        protected override void OnAwake()
        {
            base.OnAwake();
            closeButton.onClick.AddListener(()=> Time.timeScale = 1.0f);
            Time.timeScale = 0f;
        }

        protected override void Initialize()
        {
            base.Initialize();
            
        }
    }
}
