using Scripts.UI.Services.Windows;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI.Elements
{
    public class CreateWindowButton : MonoBehaviour
    {
        private IWindowService _windowService;
        public Button Button;
        public WindowsID WindowId;


        public void Construct(IWindowService windowService) =>
            _windowService = windowService;


        private void Awake() =>
            Button.onClick.AddListener(Open);

        private void Open() =>
            _windowService.Open(WindowId);
    }
}
