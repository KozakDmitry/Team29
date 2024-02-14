using System;
using UnityEngine;

namespace Scripts.Weapon.Armory
{
    public class Saws : MonoBehaviour, IWeapon
    {
        private int _level;
        private float _damage;
        private float _damagePerLevel;
        private Transform _heroTransform;
        private GameObject _bulletPrefab;

        public int level
        {
            get => _level;
            set => _level = value;
        }
        public float damage
        {
            get => _damage;
            set => _damage = value;
        }
        public float damagePerLevel
        {
            get => _damagePerLevel;
            set => _damagePerLevel = value;
        }
        public Transform heroTransform
        {
            get => _heroTransform;
            set => _heroTransform = value;
        }
        public GameObject attackPrefab
        {
            get => _bulletPrefab;
            set => _bulletPrefab = value;
        }

        public void Activate()
        {
            CreateSaws();
        }

        private void CreateSaws()
        {
             
        }

        public void Construct()
        {
            throw new System.NotImplementedException();
        }

        public void Deactivate()
        {
            throw new System.NotImplementedException();
        }

        public void LevelUp()
        {
            throw new System.NotImplementedException();
        }
    }
}