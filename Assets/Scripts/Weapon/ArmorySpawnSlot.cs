using Scripts.StaticData;
using System;
using System.Collections;
using UnityEngine;

namespace Scripts.Weapon
{
    public class ArmorySpawnSlot : MonoBehaviour
    {
        [SerializeField]
        private WeaponTypeID weaponType;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.GetComponent<WeaponManager>().AddWeapon(weaponType);      
                Destroy(this.gameObject);
            }
        }


        private void FixedUpdate()
        {
            Rotating();
        }

        private void Rotating()
        {
            transform.Rotate(Vector3.up, 1f);
        }
    }
}