using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Enemy
{
    [RequireComponent(typeof(EnemyHealth), typeof(EnemyAnimator))]
    public class EnemyDeath : MonoBehaviour
    {
        public EnemyHealth Health;
        public EnemyAnimator Animator;

       
        public event Action Happened;


        private void Start() =>
            Health.HealthChanged += HealthChanged;

        private void OnDestroy() =>
            Health.HealthChanged -= HealthChanged;

        private void HealthChanged()
        {
            if (Health.Current <= 0)
                Die();
        }

        private void Die()
        {
            Animator.PlayDeath();
            StartCoroutine(DestroyTimer());
            Health.HealthChanged -= HealthChanged;
            Happened?.Invoke();
        }



        private IEnumerator DestroyTimer()
        {
            yield return new WaitForSeconds(0f);
            Destroy(gameObject);
        }
    }
}
