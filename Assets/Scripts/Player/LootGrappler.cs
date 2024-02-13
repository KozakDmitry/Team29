using Scripts.Enemy;
using Scripts.Infostructure.Services.PersistentProgress;
using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Scripts.Player
{
    public class LootGrappler : MonoBehaviour
    {
        public TriggerObserver LootLocator;
        public float pullSpeed = 10f;
        private void Start()
        {
            LootLocator.TriggerEnter += TriggerEnter;
            LootLocator.TriggerExit += TriggerExit;
        }

        private void Update()
        {
            
        }

        private void TriggerExit(Collider collider)
        {
           
        }
        private void TriggerEnter(Collider collider)
        {
            
            if (collider.gameObject.CompareTag("Loot"))
            {
                Vector3.Lerp(collider.transform.position, transform.position,1f);
            }
        }

    }
}
