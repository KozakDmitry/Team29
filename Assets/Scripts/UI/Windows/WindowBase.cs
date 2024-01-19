using Scripts.Data;
using Scripts.Infostructure.Services.PersistentProgress;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI.Windows
{
    public class WindowBase : MonoBehaviour
    {
        public Button closeButton;


        protected IPersistentProgressService _progressService;
        protected PlayerProgress Progress =>_progressService.Progress;

        public void Construct(IPersistentProgressService progressService)
        {
            _progressService = progressService;
        }


        private void Awake() =>
            OnAwake();

        protected virtual void OnAwake() =>
            closeButton.onClick.AddListener(() => Destroy(gameObject));


        private void OnDestroy() =>
            CleanUp();

        protected virtual void Initialize()
        {

        }

        protected virtual void SubscribeUpdates()
        {

        }

        protected virtual void CleanUp()
        {
            
        }
    }
}