using Scripts.Enemy;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

namespace Scripts.Player
{
    public class PlayerTargeting : MonoBehaviour
    {
        public TriggerObserver EnemyChecker;
        public LayerMask buildingLayer;

        private List<GameObject> targets = new List<GameObject>();
        private float minDistance;

        private void Start()
        {
            EnemyChecker.TriggerEnter += EnemyDetected;
        }


        private void Update()
        {
            minDistance = float.MaxValue;
            foreach (GameObject target in targets)
            {
                if (target != null)
                {
                    CheckDistance(target);
                }
                else
                {
                    targets.Remove(target);
                }

            }
        }

        private void CheckDistance(GameObject target)
        {
            if (Vector3.Magnitude(target.transform.position - transform.position) < minDistance)
            {
                if (Physics.Linecast(transform.position, target.transform.position, layerMask: buildingLayer))
                {
                    Vector3 direction = target.transform.position - transform.position;
                    Quaternion rotation = Quaternion.LookRotation(direction);
                    transform.rotation = rotation;

                }
            }
        }

        private void LookAtTarget(Vector3 position)
        {
            throw new NotImplementedException();
        }

        private void EnemyDetected(Collider collider)
        {
            Debug.Log("HERE");
            targets.Add(collider.gameObject);
        }
    }
}
