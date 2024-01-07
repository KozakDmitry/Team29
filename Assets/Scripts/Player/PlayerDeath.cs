using System;
using System.Collections;
using UnityEngine;

namespace Scripts.Player 
{ 
    [RequireComponent(typeof(PlayerHealth))]
    public class PlayerDeath : MonoBehaviour
    {
        public PlayerHealth Health;

        public PlayerMove Move;
        public PlayerAnimator Animator;

        public event Action Dying;
        private bool _isDead;

        private void Start()
        {
            Health.HealthChanged += HealthChanged;
        }

        private void OnDestroy() =>
            Health.HealthChanged -= HealthChanged;

        private void HealthChanged()
        {
            if (!_isDead && Health.Current <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            _isDead = true;
            
            Move.enabled = false;
            Animator.PlayDeath();
            Dying?.Invoke();
        }
    }
}
