

using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI.Windows.Menu
{
    public class Menu : WindowBase
    {
        public Button ExitButton;
        protected override void Initialize()
        {
            ExitButton.onClick.AddListener(()=> Application.Quit());   
        }

        protected override void CleanUp()
        {
            base.CleanUp();

        }
    }
}
