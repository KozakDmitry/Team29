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
            yield return null;
        }

        public void Deactivate()
        {
            throw new System.NotImplementedException();
        }
    }
}