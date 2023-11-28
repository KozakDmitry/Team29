using System.Collections;
using UnityEngine;

namespace Scripts.Weapon.Armory
{
    public class StandartFire : MonoBehaviour, IWeapon
    {
        public int level {
            get => level;
            set => level = value; }

        private Transform HeroTransform;
        private float attackInterval;
        private GameObject bulletPrefab;
        public void LevelUp()
        {
            throw new System.NotImplementedException();
        }
        public void Activate()
        {
            StartCoroutine(Fire());
        }

        IEnumerator Fire()
        {
            Vector3 firePosition = HeroTransform.position + transform.forward;
            while(true)
            {
                yield return new WaitForSeconds(attackInterval);
                Instantiate(bulletPrefab);
            }
        }

        public void Deactivate()
        {
            throw new System.NotImplementedException();
        }

        public void Construct()
        {
            throw new System.NotImplementedException();
        }
    }
}