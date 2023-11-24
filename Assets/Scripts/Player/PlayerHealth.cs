using Scripts.Enemy;
using Scripts.Logic;
using System;
using UnityEngine;

namespace Scripts.Player
{
    public class PlayerHealth : MonoBehaviour, IHealth
    {
        public PlayerAnimator Animator;

        [SerializeField]
        private float _current;

        [SerializeField]
        private float _max;

        public event Action HealthChanged;

        public float Current
        {
            get => _current;
            set => _current = value;
        }

        public float Max
        {
            get => _max;
            set => _max = value;
        }

        public void TakeDamage(float damage)
        {
            Current -= damage;
            Animator.PlayHit();

            HealthChanged?.Invoke();
        }


    }
}
