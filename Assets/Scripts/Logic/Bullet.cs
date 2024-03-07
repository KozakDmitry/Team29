using Scripts.Enemy;
using Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Logic
{
    public class Bullet : MonoBehaviour
    {

        public float force;
        public float lifetime;
        public float damage;
        [HideInInspector]
        public PlayerMove player;

        void OnEnable()
        {
            StartCoroutine(DestroySelf());
        }

        void Update()
        {
            transform.Translate(Vector3.forward * Time.deltaTime * force);
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
                Destroy(this.gameObject);
            }
                
        }

        IEnumerator DestroySelf()
        {
            yield return new WaitForSeconds(lifetime);

            //player.DisableBullet(gameObject);
        }
    }

}