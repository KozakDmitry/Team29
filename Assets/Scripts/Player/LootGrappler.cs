using Scripts.Enemy;
using System;
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
                if (loot != null)
                {
                    loot.transform.position = Vector3.MoveTowards(loot.transform.position, transform.position, 0.1f);
                }
                else
                {
                    lootToPull.Remove(loot);
                }
            }
        }

        private void TriggerExit(Collider collider)
        {

        }
        private void TriggerEnter(Collider collider)
        {
            lootToPull.Add(collider.gameObject);
        }


    }
}
