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
        private IPersistentProgressService _progressService;

        private void Start()
        {
            LootLocator.TriggerEnter += TriggerEnter;
            LootLocator.TriggerExit += TriggerExit;
        }


        public void Construct(IPersistentProgressService progressService)
        {
            _progressService = progressService;
        }

        private void TriggerExit(Collider collider)
        {
            if (collider.gameObject.CompareTag("Loot"))
            {

                Rigidbody rb = collider.gameObject.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                }
            }
        }
        private void TriggerEnter(Collider collider)
        {
            if (collider.gameObject.CompareTag("Loot"))
            {

                Rigidbody rb = collider.gameObject.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    Vector3 centerDirection = transform.position - collider.transform.position;
                    rb.AddForce(centerDirection.normalized * 5.0f, ForceMode.Force);
                }
            }
        }

    }
}
