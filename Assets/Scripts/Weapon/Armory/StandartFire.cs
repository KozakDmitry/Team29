using Scripts.Logic;
using System.Collections;
using UnityEngine;

namespace Scripts.Weapon.Armory
{
    public class StandartFire : MonoBehaviour, IWeapon
    {
        private int _level;
        private float _damage;
        private float _damagePerLevel;

        private Transform _heroTransform;
        private float _attackInterval=0.4f;
        private GameObject _bulletPrefab;
        private Vector3 _firePosition;
        public int level {
            get => _level;
            set => _level = value; }
        public float damage { 
            get => _damage; 
            set => _damage = value; }
        public float damagePerLevel {  
            get => _damagePerLevel;
            set => _damagePerLevel = value; }
        public Transform heroTransform {
            get => _heroTransform;
            set => _heroTransform = value; }
        public GameObject attackPrefab {
            get => _bulletPrefab;
            set => _bulletPrefab = value; }

        public void LevelUp()
        {
            _level++;
            _damage += _damagePerLevel;
            UpdateBulletDmg();
        }
        private void UpdateBulletDmg()
        {
            _bulletPrefab.GetComponent<Bullet>().damage = _damage;
        }
        public void Activate()
        {
            UpdateBulletDmg();
            StartCoroutine(Fire());
        }

        IEnumerator Fire()
        {
            while(true)
            {
                yield return new WaitForSeconds(_attackInterval);
                _firePosition = _heroTransform.position;          
                Instantiate(_bulletPrefab,new Vector3(_firePosition.x,1.25f,_firePosition.z),heroTransform.rotation);
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