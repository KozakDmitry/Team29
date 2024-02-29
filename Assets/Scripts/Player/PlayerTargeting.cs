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
        public LayerMask EnemyLayer;

        private List<GameObject> targets = new List<GameObject>();
        private float minDistance;

        private void Start()
        {
            EnemyChecker.TriggerEnter += EnemyDetected;
        }


        private void Update()
        {

            CheckDistance();

        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Debug.DrawLine(transform.position, transform.position + transform.forward);
            Gizmos.DrawWireSphere(transform.position, 15f);
        }
        private void CheckDistance()
        {
            RaycastHit hit;
            if (Physics.SphereCast(transform.position, 15f, transform.position, out hit, EnemyLayer))
            {
                Vector3 targetDirection = hit.transform.position - transform.position;
                targetDirection.y = 0f;
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
                transform.rotation = Quaternion.Euler(0f, targetRotation.eulerAngles.y, 0f);
            }
            //if (Vector3.Magnitude(target.transform.position - transform.position) < minDistance)
            //{
            //    if (Physics.Linecast(transform.position, target.transform.position, layerMask: buildingLayer))
            //    {
            //        Vector3 targetDirection = target.transform.position - transform.position;
            //        targetDirection.y = 0f;              
            //        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            //        transform.rotation = Quaternion.Euler(0f, targetRotation.eulerAngles.y, 0f);
            //    }
            //}
        }

        private void LookAtTarget(Vector3 position)
        {
            throw new NotImplementedException();
        }

        private void EnemyDetected(Collider collider)
        {

        }
    }
}
