using Scripts.Enemy;
using UnityEngine;
using UnityEngine.AI;

namespace Scripts.Enemies
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(EnemyAnimator))]
    [RequireComponent(typeof(Attack))]
    public class AnimateAlongAgent : MonoBehaviour
    {
        public NavMeshAgent Agent;
        public float speed;
        public EnemyAnimator Animator;
        public Attack Attack;

        //private const float MinimalVelocity = 0.1f;
        private void Update()
        {
            if (ShouldMove())
            {
                Animator.Move();
                Agent.speed = speed;
            }
            else
            {
                Animator.StopMoving();
                Agent.speed = 0;
            }
        }

        private bool ShouldMove() =>
            Agent.remainingDistance > Agent.radius+0.5 & !Attack.IsAttacking();
    }
}