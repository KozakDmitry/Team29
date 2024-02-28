using Scripts.Enemy;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Scripts.Player
{
    public class PlayerTargeting : MonoBehaviour
    {
        public TriggerObserver EnemyChecker;
        
        private List<GameObject> targets = new List<GameObject>();

        private void Start()
        {
            EnemyChecker.TriggerEnter += EnemyDetected;
        }


        private void Update()
        {
            foreach (GameObject target in targets)
            {
                CheckDistance();
            }
        }

        private void CheckDistance()
        {
            throw new NotImplementedException();
        }

        private void EnemyDetected(Collider collider)
        {
            targets.Add(collider.gameObject);
        }
    }
}
