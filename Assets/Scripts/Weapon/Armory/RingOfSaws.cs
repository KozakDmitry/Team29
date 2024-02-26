using Scripts.Enemy;
using Scripts.Logic;
using System;
using UnityEngine;

namespace Scripts.Weapon.Armory
{
    public class RingOfSaws : MonoBehaviour, IWeapon
    {
        private int _level;
        private float _damage;
        private float _damagePerLevel;
        private Transform _heroTransform;
        private GameObject _sawsPrefab;

        private GameObject _generatedSaws;
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
            get => _sawsPrefab;
            set => _sawsPrefab = value;
        }

        public void Activate()
        {
            CreateSaws();
        }

        private void CreateSaws()
        {
            _generatedSaws = Instantiate(attackPrefab, this.gameObject.transform);
            _generatedSaws.GetComponent<TriggerObserver>().TriggerEnter += OnTriggerEnter;
            _generatedSaws.GetComponent<TriggerObserver>().TriggerExit += OnTriggerExit;
        }

        private void OnTriggerExit(Collider collider)
        {

        }

        private void OnTriggerEnter(Collider collider)
        {
            collider.gameObject.GetComponent<IHealth>().TakeDamage(damage);
        }
        
        public void Construct()
        {
            throw new System.NotImplementedException();
        }

        public void Deactivate()
        {
            Unsubscribe();
            Destroy(_generatedSaws);
        }

        private void Unsubscribe()
        {
            _generatedSaws.GetComponent<TriggerObserver>().TriggerEnter -= OnTriggerEnter;
            _generatedSaws.GetComponent<TriggerObserver>().TriggerExit -= OnTriggerExit;
        }

        public void LevelUp()
        {
            throw new System.NotImplementedException();
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }
    }
}