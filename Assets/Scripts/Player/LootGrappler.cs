using Scripts.Enemy;
using System.Collections.Generic;
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
        private List<GameObject> lootToPull = new List<GameObject>();
        private void Update()
        {
            
        }
        private void FixedUpdate()
        {
            foreach (GameObject loot in lootToPull)
            {
                loot.GetComponent<Rigidbody>().AddForce((loot.transform.position - transform.position)); 
            }
        }

        private void TriggerExit(Collider collider)
        {
           
        }
        private void TriggerEnter(Collider collider)
        {
            
            if (collider.gameObject.CompareTag("Loot"))
            {
                lootToPull.Add(collider.gameObject);
            }
        }

    }
}
