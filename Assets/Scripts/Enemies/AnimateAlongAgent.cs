using Scripts.Enemy;
using UnityEngine;
using UnityEngine.AI;

namespace Scripts.Enemies
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(EnemyAnimator))]
    public class AnimateAlongAgent : MonoBehaviour
    {
        public NavMeshAgent Agent;
        public float speed;
        public EnemyAnimator Animator;
        private const float MinimalVelocity = 0.1f;
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
            //Agent.velocity.magnitude > MinimalVelocity && 
            Agent.remainingDistance > Agent.radius+0.5;
    }
}