using Scripts.Enemy;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;
using static UnityEngine.GraphicsBuffer;

namespace Scripts.Player
{
    public class PlayerTargeting : MonoBehaviour
    {
        public LayerMask EnemyLayer, BuildingLayer;
        private float minDistance;

        private void Start()
        {
            //InvokeRepeating(nameof(SearchingTarget), 1.0f,1.0f);
        }

        private void SearchingTarget()
        {
            Collider[] results = new Collider[10];
            minDistance = float.MaxValue;
            int hits = Physics.OverlapSphereNonAlloc(transform.position, 15f, results, EnemyLayer);
            for (int i = 0; i < hits; i++)
            {
                Vector3 targetDirection = results[i].transform.position - transform.position;
                if (targetDirection.sqrMagnitude < minDistance * minDistance)
                {
                    if (!Physics.Linecast(transform.position, results[i].transform.position, layerMask: BuildingLayer))
                    {
                        targetDirection = results[i].transform.position - transform.position;
                        targetDirection.y = 0f;
                        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
                        transform.rotation = Quaternion.Euler(0f, targetRotation.eulerAngles.y, 0f);
                    }

                }
            }

        }

        private void Update()
        {

           CheckDistance();

        }

        private void CheckDistance()
        {
            Collider[] results = new Collider[10];
            minDistance = float.MaxValue;
            int hits = Physics.OverlapSphereNonAlloc(transform.position, 15f, results, EnemyLayer);
            for (int i = 0; i < hits; i++)
            {
                Vector3 targetDirection = results[i].transform.position - transform.position;
                if (targetDirection.sqrMagnitude < minDistance * minDistance)
                {
                    if (!Physics.Linecast(transform.position, results[i].transform.position, layerMask: BuildingLayer))
                    {
                        targetDirection = results[i].transform.position - transform.position;
                        targetDirection.y = 0f;
                        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
                        transform.rotation = Quaternion.Euler(0f, targetRotation.eulerAngles.y, 0f);
                    }

                }
            }

        }

    }
}
