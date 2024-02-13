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


        private void TriggerExit(Collider collider)
        {
           
        }
        private void TriggerEnter(Collider collider)
        {
            
            if (collider.gameObject.CompareTag("Loot"))
            {
                Debug.Log("Entered Area");
                Vector3 directionToCenter = (transform.position - collider.transform.position).normalized;

                Vector3 newPosition = collider.transform.position + directionToCenter * pullSpeed * Time.deltaTime;
                collider.transform.position = newPosition;
            }
        }

    }
}
